using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Mail;
using Web.Models;
using Web.Models.Database;
using Web.Models.Database.Context;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, DatabaseContext dbContext, IWebHostEnvironment environment)
        {
            _logger = logger;
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["loginCookie"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var checkUser = _dbContext.Users.Where(s => s.Email == email && s.Password == password).FirstOrDefault();
                if (checkUser != null)
                {
                    CookieOptions login = new CookieOptions();
                    login.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("userID", checkUser.Id.ToString(), login);
                    Response.Cookies.Append("loginCookie", "Basarili", login);

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen eksik kısımları doldurun!!");
            }

            return View(); // veya istediğiniz sayfaya yönlendirme yapabilirsiniz
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (Request.Cookies["loginCookie"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(string firstname, string lastname, string email, string password)
        {
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var checkUser = _dbContext.Users.Where(s => s.Email == email).FirstOrDefault();
                if (checkUser == null)
                {
                    Users user = new Users()
                    {
                        Firstname = firstname,
                        Lastname = lastname,
                        Email = email,
                        Password = password
                    };
                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen eksik kısımları doldurun!!");
            }

            return View(); // veya istediğiniz sayfaya yönlendirme yapabilirsiniz
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            if (Request.Cookies["loginCookie"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }


            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            
            if (!string.IsNullOrEmpty(email))
            {
                var findUser = _dbContext.Users.FirstOrDefault(x => x.Email == email);
                if (findUser != null)
                {
                    Random rnd = new Random();
                    int code = rnd.Next(100000, 999999);
                    findUser.ForgotPassword = code;
                    _dbContext.SaveChanges();
                    Send(code, email);
                }

                return RedirectToAction("VerifyCode", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen eksik kısımları doldurun!!");
            }

            return View(); // veya istediğiniz sayfaya yönlendirme yapabilirsiniz

        }  

        public string Send(int Code, string To)
        {
            try
            {
                string GmailAccount = "tarifimigetir@outlook.com";
                string GmailPassword = "m!5Xnw%Fr5"; 
                string ToEmails = To; 


                MailMessage mail = new MailMessage(GmailAccount, ToEmails);
                mail.Subject = "Şifre Sıfırlama Bildirimi";
                mail.IsBodyHtml = true;
                mail.Body = "Merhaba, <br/> Şifre sıfırlama bildirimini tamamlamak için kodunuz: " + Code;
 
                SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(GmailAccount, GmailPassword);
                smtp.Send(mail);
                return ""; 
            }
            catch (Exception ex)
            {
                return "An error occured while sending your message. " + ex.Message;
            }
        }

        [HttpGet]
        public IActionResult VerifyCode()
        {
            if (Request.Cookies["loginCookie"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        [HttpPost]
        public IActionResult VerifyCode(string code, string password)
        {
            if (Request.Cookies["loginCookie"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            int _code = Convert.ToInt32(code);
            var findUser = _dbContext.Users.FirstOrDefault(x => x.ForgotPassword == _code);
            if (findUser != null)
            {
                findUser.ForgotPassword = null;
                findUser.Password = password;
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Login", "Home");
        }

    }
}