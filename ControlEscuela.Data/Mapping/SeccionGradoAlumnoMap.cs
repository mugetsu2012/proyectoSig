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
    public class SeccionGradoAlumnoMap:EntityTypeConfiguration<SeccionGradoAlumno>
    {
        public SeccionGradoAlumnoMap()
        {
            HasKey(t => new {t.IdSeccionGrado, t.IdEstudiante});

            Property(t => t.FechaIngreso).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            HasRequired(t => t.Estudiante).WithMany().HasForeignKey(t => t.IdEstudiante);
            HasRequired(t => t.SeccionGrado).WithMany(m => m.SeccionesGradoAlumnos).HasForeignKey(t => t.IdSeccionGrado);

            ToTable("SeccionGradoAlumno");
        }
    }
}
