using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Data.Mapping
{
    public class RolMap: EntityTypeConfiguration<Rol>
    {
        public RolMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Nombre).IsRequired().HasMaxLength(100).HasColumnType("varchar");
            Property(t => t.Descripcion).IsRequired().HasMaxLength(5000).HasColumnType("varchar");

            ToTable("Rol");
        }
    }
}
