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
    public class PersonaMap: EntityTypeConfiguration<Persona>
    {
        public PersonaMap()
        {
            ToTable("Persona");

            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Nombres).IsRequired().HasColumnType("varchar").HasMaxLength(500);
            Property(t => t.Apellidos).IsRequired().HasColumnType("varchar").HasMaxLength(500);
            Property(t => t.Edad).IsRequired();
            Property(t => t.FechaNacimiento).IsRequired();
            Property(t => t.Activo).IsRequired();

        }
    }
}
