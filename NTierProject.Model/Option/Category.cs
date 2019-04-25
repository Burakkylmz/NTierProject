using NTierProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Model.Option
{
    public class Category:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
