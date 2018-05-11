using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Web.Models
{
    public class UsuariosVm
    {
        public string NombreUsuario { get; set; }

        public int IdRol { get; set; }

        public Enums.Estado Estado { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public AgregarEditarUsuarioVm AgregarEditarUsuarioVm { get; set; }
    }
}