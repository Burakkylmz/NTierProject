using NTierProject.Core.Enum;
using NTierProject.Model.Option;
using NTierProject.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Service.Option
{
    public class AppUserService:ServiceBase<AppUser>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }

        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

        public AppUser FindByUserNameOrEmail(string user)
        {
            return GetFirstOrDefault(x => (x.UserName == user || x.Email == user) && x.Status != Status.Deleted);
        }

        public bool CheckCredentialsFromWebSerice(string user, string password)
        {
            return Any(x => (x.UserName == user || x.Email == user) && (x.Password == password && x.Status != Status.Deleted));
        }
    }
}
