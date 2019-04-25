using NTierProject.Model.Option;
using NTierProject.Service.Option;
using NTierProject.UI.Areas.Admin.Models.DTO;
using NTierProject.UI.Authorize;
using NTierProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {

        AppUserService _appUserService;
        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [UserAuthorize(Role.Admin)]
        public ActionResult Add(AppUser data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
            }

            data.Status = Core.Enum.Status.Active;

            _appUserService.Add(data);

            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult List()
        {
            List<AppUser> model = _appUserService.GetActive();
            return View(model);
        }


        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
    }
}