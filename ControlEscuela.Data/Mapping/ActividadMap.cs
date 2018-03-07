using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Notas;

namespace ControlEscuela.Data.Mapping
{
    public class ActividadMap: EntityTypeConfiguration<Actividad>
    {
        public ActividadMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Ponderacion).IsRequired();
            Property(t => t.FechaRealizacion).IsRequired();

            HasRequired(t => t.Periodo).WithMany().HasForeignKey(f => f.IdPeriodo);
            HasRequired(t => t.SeccionGrado).WithMany(m => m.Actividades).HasForeignKey(f => f.IdSeccionGrado);

            ToTable("Actividad");

        }
    }
}
