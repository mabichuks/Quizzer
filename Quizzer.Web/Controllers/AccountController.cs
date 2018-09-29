using Microsoft.AspNet.Identity;
using Quizzer.Web.Models;
using Microsoft.Owin.Host.SystemWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.Owin.Security;
using Quizzer.Domain.Repository_Interfaces;
using Quizzer.Domain.Entities;
using Quizzer.Infrastructure.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using static Quizzer.Infrastructure.Identity.IdentityModel;
using Facebook;
using System.IO;

namespace Quizzer.Web.Controllers
{
    [RoutePrefix("api/account")]
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        private readonly IUserRepository _repo;
        public IAuthenticationManager Authentication => HttpContext.Current.GetOwinContext().Authentication;

        public AccountController(IUserRepository repo)
        {
            this._repo = repo;
        }

        
        [HttpPost, Route("login")]
        public async Task<HttpResponseMessage> Login(LoginViewModel lvm)
        {
            try
            {
                if(!this.ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Fields");
                }

                var user = await _repo.SignIn(lvm.Email, lvm.Password);

                
                if(user != null)
                {
                    ClaimsIdentity claimsIdentity = await _repo.FindUserAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                    Authentication.SignIn(claimsIdentity);
                    var response = this.Request.CreateResponse(HttpStatusCode.Accepted, "Successfully Signed In");
                    return response;
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.NotFound, "User Not Found");
                }

            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost, Route("register")]
        public async Task<HttpResponseMessage> Register(RegisterViewModel rvm)
        {
            try
            {
                if(!this.ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Fields");
                }

                string fileName = Path.GetFileNameWithoutExtension(rvm.ImageFile.FileName);
                string fileExtension = Path.GetExtension(rvm.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                rvm.ImageUrl = fileName;
                fileName = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images/"), fileName);

                rvm.ImageFile.SaveAs(fileName);

                var result = await _repo.CreateUser(rvm.Email, rvm.Password,rvm.ImageUrl);

                if(!result.Succeeded)
                {
                    var errors = new List<string>();
                    foreach(var error in result.Errors)
                    {
                        errors.Add(error);
                    }

                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, errors.FirstOrDefault());

                }

                return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");

            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                
            }
        }

        public async Task<HttpResponseMessage> FacebookAuthenticationn()
        {
            var loginInfo = Request.GetOwinContext().Authentication.GetExternalLoginInfo();
            ExternalAuthViewModel exrvm = new ExternalAuthViewModel();

            if (loginInfo == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Facebook Login Failed");
            }
            UserLoginInfo lg = loginInfo == null ? null : new UserLoginInfo(loginInfo.Login.LoginProvider, loginInfo.Login.ProviderKey);

            if(lg != null)
            {
                var user = await _repo.SignIn(lg);

                if(user == null)
                {
                    var identity = Request.GetOwinContext().Authentication.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
                    var AccessToken = identity.FindFirstValue("FacebookAccessToken");
                    var FbClient = new FacebookClient(AccessToken);
                    dynamic Email = FbClient.Get("/me?fields=email");
                    dynamic FirstName = FbClient.Get("/me?fields=first_name");
                    dynamic LastName = FbClient.Get("/me?fields=last_name");

                    string firstname = FirstName.first_name;
                    string lastname = LastName.last_name;
                    exrvm.Email = Email.email;
                    exrvm.FirstName = firstname;
                    exrvm.LastName = lastname;

                }
                else
                {
                    var identity = await _repo.FindUserAsync(user, DefaultAuthenticationTypes.ExternalCookie);
                    Request.GetOwinContext().Authentication.SignIn(identity);
                }


            }
            return Request.CreateResponse(HttpStatusCode.Accepted, "Successfully Authenticated");

        }

        [HttpPost, Route("logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                return Request.CreateResponse(HttpStatusCode.Accepted, "Signed Out");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }



    }
}
