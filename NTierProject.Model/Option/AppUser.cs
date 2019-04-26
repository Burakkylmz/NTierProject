using NTierProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Model.Option
{
    public enum Role
    {
        [Display(Name = "Belirtilmiyor")]
        None=0,
        [Display(Name = "Sistem Yöneticisi")]
        Admin=1,
        [Display(Name = "Çalışan")]
        Member =2
    }

    public class AppUser: CoreEntity
    {
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
