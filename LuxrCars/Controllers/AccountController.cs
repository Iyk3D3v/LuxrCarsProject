using LuxrCars.Domain.Managers;
using LuxrCars.Domain.Models;
using LuxrCars.Infrastructure;
using LuxrCars.Infrastructure.Repositories;
using LuxrCars.Infrastructure.Utilities;
using LuxrCars.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LuxrCars.Controllers
{
    public class AccountController : Controller
    {

        private UserManager _user;
        public AccountController()
        {
            _user = new UserManager(new UserRepository(), new MD5EncryptionService());
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl )
        {
            if(ModelState.IsValid)
            {
                var user = _user.Login(model.Emailing, model.Password);
                if(_user != null)
                {
                    if (true)
                    {
                        var auth = HttpContext.GetOwinContext().Authentication;

                       
                        var claims = new List<Claim>
                        {
                                    new Claim(ClaimTypes.Email,user.Email),
                                    new Claim(ClaimTypes.Name,user.Email),
                                    new Claim(ClaimTypes.GivenName, user.firstName),
                                    new Claim(ClaimTypes.Surname,user.lastName),
                                    //username
                                    new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString())
                       };
                      
                        
                        var roleClaims =  user.Role.Select(r => new Claim(ClaimTypes.Role, r));

                        claims.AddRange(roleClaims);
                       
                        var identity = new ClaimsIdentity(claims, Constants.AuthenticationType);

                        auth.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                        if(Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        return RedirectToAction("Place","Order");
                    }
                }
                else
                {
                    ModelState.AddModelError("Invalid Error", "Invalid Username or password");
                    return View(model);
                }
                
            }
            return View(model);




        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel r)
        {
            if(ModelState.IsValid)
            {
                //register user
                //return to login

                try
                {
                    var user = new UserModel
                    {
                        Email = r.Email,
                        firstName = r.firstName,
                        lastName = r.lastName

                    };

                    _user.RegisterUser(user, r.passWord);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("RegistrationError", ex);
                }
                return RedirectToAction("Login", "Account");
            }
            return View(r);
        }
           
      }




    }
