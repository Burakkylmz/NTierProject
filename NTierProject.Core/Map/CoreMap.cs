using NTierProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Core.Map
{
    public class CoreMap<T>:EntityTypeConfiguration<T> where T: CoreEntity
    {
        //Fluent API'ye bakınız
        public CoreMap()
        {
            Property(x => x.ID).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CreatedUserName).HasColumnName("CreatedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedComputerName).HasColumnName("CreatedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedIP).IsOptional();
            Property(x => x.CreatedBy).IsOptional();

            Property(x => x.ModifiedUserName).HasColumnName("ModifiedUserName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedComputerName).HasColumnName("ModifiedComputerName").HasMaxLength(50).IsOptional();
            Property(x => x.ModifiedDate).HasColumnName("ModifiedDate").IsOptional();
            Property(x => x.ModifiedIP).HasColumnName("ModifiedIP").IsOptional();
            Property(x => x.ModifiedBy).IsOptional();
        }
    }
}
