using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Data.Mapping
{
    public class SeccionGradoMap:EntityTypeConfiguration<SeccionGrado>
    {
        public SeccionGradoMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.LetraCorrelativo).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(t => t.Turno).IsRequired();
            Property(t => t.TextoTurno).IsRequired().HasMaxLength(100).HasColumnType("varchar");

            HasRequired(t => t.Grado).WithMany(m => m.SeccionesGrados).HasForeignKey(f => f.IdGrado);
            HasRequired(t => t.Profesor).WithMany().HasForeignKey(f => f.IdProfesor);

            ToTable("SeccionGrado");
        }
    }
}
