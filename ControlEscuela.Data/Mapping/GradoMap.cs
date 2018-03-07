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
    public class GradoMap: EntityTypeConfiguration<Grado>
    {
        public GradoMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.NombreGrado).IsRequired();
            Property(t => t.TextoGrado).IsRequired().HasMaxLength(500);

            ToTable("Grado");
        }
    }
}
