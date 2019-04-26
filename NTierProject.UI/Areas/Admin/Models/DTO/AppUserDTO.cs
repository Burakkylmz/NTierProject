using NTierProject.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProject.UI.Areas.Admin.Models.DTO
{
    public class AppUserDTO
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

    }
}