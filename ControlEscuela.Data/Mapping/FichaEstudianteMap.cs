using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Data.Mapping
{
    class FichaEstudianteMap:EntityTypeConfiguration<FichaEstudiante>
    {
        public FichaEstudianteMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FechaIngreso).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(t => t.Razon).IsRequired().HasMaxLength(5000).HasColumnType("varchar");
            Property(t => t.TipoFalta).IsRequired();
            Property(t => t.TextoTipoFalta).IsRequired().HasMaxLength(500).HasColumnType("varchar");

            HasRequired(t => t.Estudiante).WithMany().HasForeignKey(f => f.IdEstudiante);
            HasRequired(t => t.SeccionGrado).WithMany().HasForeignKey(f => f.IdSeccionGrado);
            HasRequired(t => t.Profesor).WithMany().HasForeignKey(f => f.IdProfesor);

            ToTable("FichaEstudiante");
        }
    }
}
