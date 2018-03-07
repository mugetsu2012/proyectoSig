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
    public class PeriodoMap: EntityTypeConfiguration<Periodo>
    {
        public PeriodoMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FechaInicio).IsRequired();
            Property(t => t.FechaFin).IsRequired();

            ToTable("Periodo");

        }
    }
}
