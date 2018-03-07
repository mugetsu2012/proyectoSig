using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Data.Mapping
{
    public class PersonaUsuarioMap: EntityTypeConfiguration<PersonaUsuario>
    {
        public PersonaUsuarioMap()
        {
            HasKey(t => new {t.IdPersona, t.IdUsuario});

            HasRequired(t => t.Persona).WithMany().HasForeignKey(f => f.IdPersona);
            HasRequired(t => t.Usuario).WithMany().HasForeignKey(f => f.IdUsuario);

            ToTable("PersonaUsuario");
        }
    }
}
