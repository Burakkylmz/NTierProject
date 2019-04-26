using NTierProject.Model.Option;
using NTierProject.Service.Option;
using NTierProject.UI.Areas.Admin.Models.DTO;
using NTierProject.UI.Authorize;
using NTierProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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

        public ActionResult Update(Guid id)
        {

            AppUser user = _appUserService.GetByID(id);

            AppUserDTO model = new AppUserDTO();

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Address = user.Address;
            model.PhoneNumber = user.PhoneNumber;
            model.UserImage = user.UserImage;
            model.XSmallUserImage = user.XSmallUserImage;
            model.CruptedUserImage = user.CruptedUserImage;
            model.Role = user.Role;

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(AppUserDTO data, HttpPostedFileBase Image)
        {

            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];


            AppUser update = _appUserService.GetByID(data.ID);

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {

                if (update.UserImage == null || update.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    update.UserImage = ImageUploader.DefaultProfileImagePath;
                    update.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    update.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.UserImage = update.UserImage;
                    update.XSmallUserImage = update.XSmallUserImage;
                    update.CruptedUserImage = update.CruptedUserImage;
                }

            }
            else
            {
                update.UserImage = UploadedImagePaths[0];
                update.XSmallUserImage = UploadedImagePaths[1];
                update.CruptedUserImage = UploadedImagePaths[2];
            }

            update.FirstName = data.FirstName;
            update.LastName = data.LastName;
            update.UserName = data.UserName;
            update.Email = data.Email;
            update.Address = data.Address;
            update.PhoneNumber = data.PhoneNumber;
            update.Birthdate = data.Birthdate;
            update.Role = data.Role;

            _appUserService.Update(update);

            return Redirect("/Admin/AppUser/List");


        }

        public RedirectResult Delete(Guid id)
        {
            _appUserService.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }
    }
}