using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Data.Mapping
{
    public class AsignaturaSeccionGradoMap: EntityTypeConfiguration<AsignaturaSeccionGrado>
    {
        public AsignaturaSeccionGradoMap()
        {
            HasKey(t => new {t.IdAsignatura, t.IdSeccionGrado});

            Property(t => t.Activo).IsRequired();

            HasRequired(t => t.Profesor).WithMany().HasForeignKey(f => f.IdProfesor);
            HasRequired(t => t.Asignatura).WithMany().HasForeignKey(f => f.IdAsignatura);
            HasRequired(t => t.SeccionGrado).WithMany(m => m.AsignaturaSeccionGrados).HasForeignKey(f => f.IdSeccionGrado);

            ToTable("AsignaturaSeccionGrado");


        }
    }
}
