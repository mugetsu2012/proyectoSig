using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Notas;

namespace ControlEscuela.Data.Mapping
{
    public class CalificacionMap: EntityTypeConfiguration<Calificacion>
    {
        public CalificacionMap()
        {
            HasKey(t => new {t.IdActividad, t.IdEstudiante});

            Property(t => t.Nota).IsRequired();
            Property(t => t.Comentario).IsOptional().HasMaxLength(1000).HasColumnType("varchar");

            HasRequired(t => t.Actividad).WithMany().HasForeignKey(f => f.IdActividad);
            HasRequired(t => t.Estudiante).WithMany().HasForeignKey(f => f.IdEstudiante);
            HasRequired(t => t.Profesor).WithMany().HasForeignKey(f => f.IdProfesor);

            ToTable("Calificacion");
        }
    }
}
