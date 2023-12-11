using AngleSharp.Dom;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;
using Web.Models.Database;
using Web.Models.Database.Context;
using Web.WebScraping;

namespace Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly DatabaseContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        private readonly IFoodFind _wsFoodFind;

        public DashboardController(ILogger<DashboardController> logger, DatabaseContext dbContext, IWebHostEnvironment environment, IFoodFind wsFoodFind)
        {
            _logger = logger;
            _dbContext = dbContext;
            _environment = environment;
            _wsFoodFind = wsFoodFind;
        }
        public IActionResult Index()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var foods = _dbContext.Foods.OrderByDescending(o =>o.Id).ToList();

            return View(foods);
        }

        public IActionResult Logout()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            Response.Cookies.Delete("userID");
            Response.Cookies.Delete("loginCookie");

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Food(int id)
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var food = _dbContext.Foods.FirstOrDefault(f => f.Id == id);

            dynamic model = new ExpandoObject();
            model.Food = food;
            model.dbContext = _dbContext;
            model.userId = Request.Cookies["userId"];
            return View(model);
        }

        public IActionResult LikeFood(int id)
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);
            var getLike = _dbContext.FavoriteFoods.FirstOrDefault(x => x.FoodId == id && x.UserId == userId);
            if (getLike != null)
            {
                _dbContext.FavoriteFoods.Remove(getLike);
                _dbContext.SaveChanges();
            }
            else
            {
                FavoriteFoods favoriteFoods = new FavoriteFoods()
                {
                    FoodId = id,
                    UserId = userId
                };
                _dbContext.FavoriteFoods.Add(favoriteFoods);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Food", "Dashboard", new { id = id });
        }

        public IActionResult FavoriteFoods()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);
            var favoriteFoods = _dbContext.FavoriteFoods.Where(x => x.UserId == userId).OrderByDescending(o =>o.Id).ToList();
            List<Foods> foods = new List<Foods>();
            foreach (var item in favoriteFoods)
            {
                foods.Add(_dbContext.Foods.FirstOrDefault(x => x.Id == item.FoodId));
            }
          
            return View(foods);
        }

        public IActionResult FoodBook()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);
            var foods = _dbContext.Foods.Where(x => x.Creator == userId && !x.FoodImage.Contains("http")).OrderByDescending(o => o.Id).ToList();

            
             return View(foods);

        }
  

        [HttpPost]
        public IActionResult DeleteFood(int Id)
        {

            Foods foods = _dbContext.Foods.FirstOrDefault(f => f.Id == Id);



            if (foods != null)
            {
                _dbContext.Foods.Remove(foods);
                _dbContext.SaveChanges();

                TempData["SuccessMessage"] = "Yemek tarifi başarıyla silindi.";
            }



            return RedirectToAction("FoodBook", "Dashboard");
        }



        [HttpGet]
        public IActionResult NewFood()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);

            dynamic model = new ExpandoObject();
            model.userId = userId;
            return View(model);
        }

        [HttpPost]
        public IActionResult NewFood(string foodName, string foodCountForPeople, string foodCountForPeopleText, string foodPreparingTime, string foodPreparingTimeText, string foodCookingTime, string foodCookingTimeText, string[] foodMaterialName, string[] foodMaterialCount, IFormFile foodImage, string foodRecipe, string remoteImage = "")
        {
            if (!string.IsNullOrEmpty(foodName) && !string.IsNullOrEmpty(foodCountForPeople) && !string.IsNullOrEmpty(foodCountForPeopleText) && !string.IsNullOrEmpty(foodPreparingTime) && !string.IsNullOrEmpty(foodPreparingTimeText) && !string.IsNullOrEmpty(foodCookingTime) && !string.IsNullOrEmpty(foodCookingTimeText) && !string.IsNullOrEmpty(foodRecipe))
            {
                int userId = Convert.ToInt32(Request.Cookies["userId"]);

                Foods food = new Foods();
                food.FoodName = foodName;
                food.FoodCountForPeople = Convert.ToInt32(foodCountForPeople);
                food.FoodCountForPeopleText = foodCountForPeopleText;
                food.FoodPreparingTime = Convert.ToInt32(foodPreparingTime);
                food.FoodPreparingTimeText = foodPreparingTimeText;
                food.FoodCookingTime = Convert.ToInt32(foodCookingTime);
                food.FoodCookingTimeText = foodCookingTimeText;
                food.FoodRecipe = foodRecipe;

                if (foodImage != null)
                {
                    string filename = "/images/" + Guid.NewGuid().ToString() + Path.GetExtension(foodImage.FileName);
                    var wwwroot = _environment.WebRootPath;
                    string path = wwwroot + filename;
                    if (!System.IO.File.Exists(path))
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            foodImage.CopyTo(stream);
                        }
                        food.FoodImage = filename;
                    }
                }
                else if (!string.IsNullOrEmpty(remoteImage))
                    food.FoodImage = remoteImage;
                else //eğer fotoğraf yüklenmemişse bir şey yapmaz
                {
                    return View(); // Eğer bu kod bir Controller içinde ise, dönüş değeri View() olmalıdır.
                }

                food.Creator = userId;

                _dbContext.Foods.Add(food);
                _dbContext.SaveChanges();

                List<Materials> materials = new List<Materials>();

                if (foodMaterialName != null)
                {
                    foreach (string item in foodMaterialName)
                    {
                        var findMaterial = _dbContext.Materials.FirstOrDefault(x => x.MaterialName == item);
                        if (findMaterial == null)
                        {
                            Materials mItem = new Materials
                            {
                                MaterialName = item,
                                MaterialImage = ""
                            };
                            _dbContext.Materials.Add(mItem);
                            _dbContext.SaveChanges();

                            materials.Add(mItem);
                        }
                        else
                        {
                            materials.Add(findMaterial);
                        }
                    }
                }

                for (int i = 0; i < materials.Count; i++)
                {
                    FoodMaterials fmItem = new FoodMaterials()
                    {
                        FoodId = food.Id,
                        MaterialId = materials[i].Id,
                        MaterialCount = foodMaterialCount[i]
                    };

                    _dbContext.FoodMaterials.Add(fmItem);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("FoodBook", "Dashboard");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

            dynamic model = new ExpandoObject();
            model.userId = userId;
            model.user = user;
            return View(model);
        }

        [HttpPost]
        public IActionResult Profile(string firstName, string lastName, string email, string password, IFormFile profileImage)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(email))
            {
                int userId = Convert.ToInt32(Request.Cookies["userId"]);
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    var findEmail = _dbContext.Users.FirstOrDefault(x => x.Email == email);
                    if (findEmail == null)
                    {
                        user.Email = email;
                    }

                    user.Firstname = firstName;
                    user.Lastname = lastName ?? "";

                    if (!string.IsNullOrEmpty(password))
                    {
                        user.Password = password;
                    }

                    if (profileImage != null)
                    {
                        string filename = Guid.NewGuid().ToString() + Path.GetExtension(profileImage.FileName);
                        var wwwroot = _environment.WebRootPath;
                        string path = Path.Combine(wwwroot + "/images/", filename);
                        if (!System.IO.File.Exists(path))
                        {
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                profileImage.CopyTo(stream);
                            }
                            user.ProfileImage = filename;
                        }
                    }

                    _dbContext.SaveChanges();
                }
            }
            return RedirectToAction("Profile", "Dashboard");
        }

        [HttpGet]
        public IActionResult DetailedSearch() //sayfanın ilk çağrıldığı yer
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);

            dynamic model = new ExpandoObject();
            model.searchedMaterial = null;
            model.userId = userId;
            return View(model);
        }

        [HttpPost]
        public IActionResult DetailedSearch(string[] foodMaterialName, bool checkWS)
        {
            if (Request.Cookies["loginCookie"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            int userId = Convert.ToInt32(Request.Cookies["userId"]);

            List<Materials> materials = new List<Materials>();
            List<Foods> foods = new List<Foods>();


            #region WebScraping
            if (checkWS)
            {
                try
                {
                    var result = _wsFoodFind.DataScraping(String.Join(" ", foodMaterialName), userId).Result;
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {

                            var findMaterial = _dbContext.Foods.FirstOrDefault(x => x.FoodImage == item.Foods.FoodImage);

                            if (findMaterial == null)
                            {
                                NewFood(item.Foods.FoodName
                                    , item.Foods.FoodCountForPeople.ToString()
                                    , item.Foods.FoodCountForPeopleText
                                    , item.Foods.FoodPreparingTime.ToString()
                                    , item.Foods.FoodPreparingTimeText
                                    , item.Foods.FoodCookingTime.ToString()
                                    , item.Foods.FoodPreparingTimeText
                                    , item.Materials.Select(s => s.MaterialName).ToArray()
                                    , item.Materials.Select(s => s.MaterialName).ToArray()
                                    , null
                                    , item.Foods.FoodRecipe
                                    , item.Foods.FoodImage);
                            }
                        }
                    }
                    dynamic wsModel = new ExpandoObject();
                    wsModel.searchedMaterial = foodMaterialName;
                    wsModel.userId = userId;
                    wsModel.checkWS = checkWS;
                    if (result.Count > 0)
                    {
                        foreach (var item in result.Select(s => s.Foods.FoodImage))
                        {
                            var findFood = _dbContext.Foods.Where(x => x.FoodImage == item).FirstOrDefault();
                            if (findFood != null)
                            {
                                foods.Add(findFood);
                            }

                        }
                    }
                    wsModel.foods = foods.ToList();

                    return View(wsModel);
                }
                catch (Exception)
                {
                    dynamic wsModel = new ExpandoObject();
                    wsModel.searchedMaterial = foodMaterialName;
                    wsModel.userId = userId;
                    wsModel.checkWS = checkWS;
                    wsModel.foods = foods.ToList();
                    return View(wsModel);
                }

            }
            #endregion

            if (foodMaterialName != null)
            {
                foreach (string item in foodMaterialName)
                {
                    var findMaterial = _dbContext.Materials.Where(x => x.MaterialName.Contains(item));
                    if (findMaterial != null)
                        findMaterial.ToList().ForEach(f => materials.Add(f));
                }
            }


            if (materials.Count > 0)
            {
                // tüm malzemeleri içeren yemeklerin tespiti
                var foodsMaterials = _dbContext.FoodMaterials
                .AsEnumerable()
                .Where(x => materials.Any(y => y.Id == x.MaterialId))
                .GroupBy(x => x.FoodId)
                //.Where(g => g.Count() == materials.Count)
                .Select(g => g.Key)
                .ToList();

                foods = _dbContext.Foods
                   .Where(x => foodsMaterials.Contains(x.Id))
                   .ToList();

                //aratilan malzemelerin beraber olmamasi durumunda kaldirilacak liste icin yazilmis kod blogu
                #region Yeni Eklenenler

                //kaldirilacak yemeklerin listesi
                List<Foods> lstRemove = new List<Foods>();

                foreach (var item in foods)
                {
                    //
                    //foods listesi uzerinden materials tablosundaki malzeme listesine erismek icin izlenen yol
                    //
                    var materialsForFood = _dbContext.FoodMaterials.Where(w => w.FoodId == item.Id).ToList();
                    bool isSearched = true;

                    foreach (string fmn in foodMaterialName)
                    {
                        var getList = _dbContext.Materials.Where(w => materialsForFood.Select(s => s.MaterialId).Contains(w.Id));
                        if (!getList.Where(w => w.MaterialName.Contains(fmn)).Any())
                            isSearched = false;
                    }

                    if (!isSearched)
                        lstRemove.Add(item);
                }

                lstRemove.ForEach(f => foods.Remove(f));

                #endregion
            }

            dynamic model = new ExpandoObject();
            model.searchedMaterial = foodMaterialName;
            model.userId = userId;
            model.checkWS = checkWS;
            model.foods = foods.ToList().DistinctBy(x => x.Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string searchFood, List<int> foodId)
        {
            if (string.IsNullOrEmpty(searchFood))
            {
                var result1 = _dbContext.Foods.Where(w => foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();

                return View(result1);

            }

            var result = _dbContext.Foods.Where(w => w.FoodName.Contains(searchFood) && foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();

            return View(result);


        }


        [HttpPost]
        public IActionResult FoodBook(string searchFood, List<int> foodId)
        {
            if(string.IsNullOrEmpty(searchFood))
            {
                var result1 = _dbContext.Foods.Where(w =>foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();

                return View(result1);

            }

            var result = _dbContext.Foods.Where(w => w.FoodName.Contains(searchFood) && foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();

            return View(result);

        }

        [HttpPost]
        public IActionResult FavoriteFoods(string searchFood, List<int> foodId)
        {
            if (string.IsNullOrEmpty(searchFood))
            {
                var result1 = _dbContext.Foods.Where(w => foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();


                return View(result1);

            }

            var result = _dbContext.Foods.Where(w => w.FoodName.Contains(searchFood) && foodId.Contains(w.Id)).OrderByDescending(o => o.Id).ToList();


            return View(result);
        }
    }
}