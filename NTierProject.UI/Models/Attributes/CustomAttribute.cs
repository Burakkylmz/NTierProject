using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.UI.Models.Attributes
{
    //public class CustomAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        int Id;

    //        Dictionary<string, object> decryptedParameters = new Dictionary<string, object>();
    //        if (HttpContext.Current.Request.QueryString.Get("q") != null)
    //        {
    //            string encryptedQueryString = HttpContext.Current.Request.QueryString.Get("q");
    //            //string decrptedString = Decrypt(encryptedQueryString.ToString());
    //            string decrptedString = Decrypt(encryptedQueryString.ToString());
    //            string[] paramsArrs = decrptedString.Split('?');

    //            for (int i = 0; i < paramsArrs.Length; i++)
    //            {
    //                string[] paramArr = paramsArrs[i].Split('=');
    //                decryptedParameters.Add(paramArr[0], Convert.ToInt32(paramArr[1]));
    //            }
    //        }
    //        else if (!HttpContext.Current.Request.Url.ToString().Contains("?"))
    //        {
    //            //if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last()), out Id))
    //            if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last()), out Id))
    //            {
    //                string id = Id.ToString();
    //                decryptedParameters.Add("id", id);
    //            }
    //        }
    //        else if (HttpContext.Current.Request.Url.ToString().Contains("?"))
    //        {
    //            //if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last().Split('?')[0]), out Id))
    //            if (int.TryParse(Decrypt(HttpContext.Current.Request.Url.ToString().Split('/').Last().Split('?')[0]), out Id))
    //            {
    //                string id = Id.ToString();
    //                if (id.Contains('?'))
    //                {
    //                    id = id.Split('?')[0];
    //                }
    //                decryptedParameters.Add("id", id);
    //            }

    //            string[] paramsArrs = HttpContext.Current.Request.Url.ToString().Split('/').Last().Split('?');
    //            for (int i = 1; i < paramsArrs.Length; i++)
    //            {
    //                string[] paramArr = paramsArrs[i].Split('=');
    //                decryptedParameters.Add(paramArr[0], Convert.ToInt32(paramArr[1]));
    //            }
    //        }

    //        for (int i = 0; i < decryptedParameters.Count; i++)
    //        {
    //            filterContext.ActionParameters[decryptedParameters.Keys.ElementAt(i)] = decryptedParameters.Values.ElementAt(i);
    //        }
    //        base.OnActionExecuting(filterContext);

    //    }
    //}
}