using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProject.UI.Areas.Admin.Models.DTO
{
    public class CategoryDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}