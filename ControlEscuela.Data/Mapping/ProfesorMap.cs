using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Data.Mapping
{
    public class ProfesorMap:EntityTypeConfiguration<Profesor>
    {
        public ProfesorMap()
        {
            ToTable("Profesor");

            Property(t => t.NumeroIdentificacion).IsRequired().HasMaxLength(50);
            Property(t => t.Telefono).IsRequired().HasMaxLength(20);

        }
    }
}
