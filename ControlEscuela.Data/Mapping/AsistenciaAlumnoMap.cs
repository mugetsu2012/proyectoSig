using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Data.Mapping
{
    public class AsistenciaAlumnoMap: EntityTypeConfiguration<AsistenciaAlumno>
    {
        public AsistenciaAlumnoMap()
        {
            HasKey(t => new {t.IdAsistencia, t.IdEstudiante});

            Property(t => t.Asistio).IsRequired();

            HasRequired(t => t.Estudiante).WithMany().HasForeignKey(f => f.IdEstudiante);
            HasRequired(t => t.Asistencia).WithMany().HasForeignKey(f => f.IdAsistencia);

            ToTable("AsistenciaAlumno");
        }
    }
}
