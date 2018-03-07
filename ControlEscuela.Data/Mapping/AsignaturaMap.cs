using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Data.Mapping
{
    public class AsignaturaMap: EntityTypeConfiguration<Asignatura>
    {
        public AsignaturaMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Nombre).IsRequired().HasColumnType("varchar").HasMaxLength(500);

            ToTable("Asignatura");
        }
    }
}
