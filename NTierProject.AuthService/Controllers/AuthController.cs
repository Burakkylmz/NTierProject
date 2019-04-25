using NTierProject.AuthService.Models;
using NTierProject.Model.Option;
using NTierProject.Service.Option;
using NTierProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace NTierProject.AuthService.Controllers
{
    public class AuthController : ApiController
    {

        AppUserService _appUserService;

        public AuthController()
        {
            _appUserService = new AppUserService();
        }

        [HttpPost]
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Login(Credentials model)
        {
            var url = "";

            model.Password = Cryptography.ToMD5(model.Password);

            if (model.User == null || model.Password == null)
            {
                url = "http://localhost:63724/Home/login";
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
            }
            if (_appUserService.CheckCredentialsFromWebSerice(model.User, model.Password))
            {
                AppUser u = new AppUser();
                u = _appUserService.FindByUserNameOrEmail(model.User);

                if (u.Role == Role.Admin || u.Role == Role.Member)
                {
                    url = "http://localhost:63724/Home/Index/" + u.ID;
                    return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = url });
                }
                else
                {
                    url = "http://localhost:63724/Home/Index";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Success = true, RedirectUrl = url });
                }
            }

            url = "http://localhost:63724/Home/login";
            return Request.CreateResponse(HttpStatusCode.BadRequest, new { Success = true, RedirectUrl = url });
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            var newUrl = "http://localhost:57210/Home/logout";
            return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
        }

    }
}