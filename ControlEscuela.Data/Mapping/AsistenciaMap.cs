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
    public class AsistenciaMap: EntityTypeConfiguration<Asistencia>
    {
        public AsistenciaMap()
        {
            ToTable("Asistencia");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FechaIngreso).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            HasRequired(t => t.Profesor).WithMany().HasForeignKey(t => t.IdProfesor);
            HasRequired(t => t.SeccionGrado).WithMany().HasForeignKey(t => t.IdSeccionGrado);


        }
    }
}
