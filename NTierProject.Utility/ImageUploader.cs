using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NTierProject.Utility
{
    public class ImageUploader
    {
        /* Kullanıcı varsayılan resim yolları */

        public static string DefaultProfileImagePath = "/Content/Uploads/UserImages/OriginalImages/user_default_image.png";

        public static string DefaultXSmallProfileImage = "/Content/Uploads/UserImages/XSmallImages/user_default_image.png";

        public static string DefaulCruptedProfileImage = "/Content/Uploads/UserImages/CruptedImages/user_default_image.png";

        public static string OriginalProfileImagePath = "~/Content/Uploads/UserImages/OriginalImages/";

        public static List<string> UploadSingleImage(string serverPath, HttpPostedFileBase file, int saveAsParam)
        {
            string OriginalImagePath = "~/Content/Uploads/UserImages/OriginalImages/";
            string XSmallImagePath = "~/Content/Uploads/UserImages/XSmallImages/";
            string CruptedImagePath = "~/Content/Uploads/UserImages/CruptedImages/";

            List<string> ImagePaths = new List<string>();

            if (file != null)
            {
                var uniqueName = Guid.NewGuid();

                serverPath = serverPath.Replace("~", string.Empty);

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();

                var fileName = uniqueName + "." + extension;

                if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        ImagePaths.Add("1");

                        return ImagePaths;
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);


                        file.SaveAs(filePath);

                        /* Görselleri boyutlandırmak için ImageResizer namespace`ini kullanıyorum. Bu işlemin dökümantasyonu imageresizing.net adresinde var(Package Manager Console ile hallettim). */

                        ImageResizer.ResizeSettings ImageSetting = new ImageResizer.ResizeSettings();
                        ImageSetting.Width = 29;
                        ImageSetting.Height = 29;
                        ImageSetting.Mode = ImageResizer.FitMode.Crop;


                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, XSmallImagePath + fileName, ImageSetting);


                        if (saveAsParam == 1)
                        {
                            ImageSetting.Width = 150;
                            ImageSetting.Height = 150;
                            ImageSetting.Mode = ImageResizer.FitMode.Crop;
                        }
                        else
                        {
                            ImageSetting.Width = 213;
                            ImageSetting.Height = 133;
                            ImageSetting.Mode = ImageResizer.FitMode.Crop;
                        }

                        ImageResizer.ImageBuilder.Current.Build(OriginalImagePath + fileName, CruptedImagePath + fileName, ImageSetting);

                        ImagePaths.Add(serverPath + fileName);
                        ImagePaths.Add(XSmallImagePath.Replace("~", string.Empty) + fileName);
                        ImagePaths.Add(CruptedImagePath.Replace("~", string.Empty) + fileName);

                        return ImagePaths;
                    }
                }
                else
                {
                    ImagePaths.Add("2");

                    return ImagePaths;
                }


            }
            ImagePaths.Add("0");

            return ImagePaths;
        }
    }
}
