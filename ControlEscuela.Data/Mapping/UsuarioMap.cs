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
    public class UsuarioMap: EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            HasKey(t => t.IdUsuario);

            Property(t => t.IdUsuario).HasMaxLength(50).HasColumnType("varchar");
            Property(t => t.FechaIngreso).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(t => t.Activo).IsRequired();
            Property(t => t.Password).IsRequired();

            HasRequired(t => t.Rol).WithMany(m => m.Usuarios).HasForeignKey(f => f.IdRol);

            ToTable("Usuario");
        }
    }
}
