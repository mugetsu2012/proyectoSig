using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Data.Mapping
{
    public class EstudianteMap: EntityTypeConfiguration<Estudiante>
    {
        public EstudianteMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.NombreEncargado).IsRequired().HasMaxLength(500);
            Property(t => t.TelefonoEncargado).IsRequired().HasMaxLength(20);
            Property(t => t.Direccion).IsRequired().HasMaxLength(1000);

            HasRequired(t => t.SeccionGrado).WithMany().HasForeignKey(f => f.IdSeccionGrado);

            ToTable("Estudiante");
        }
    }
}
