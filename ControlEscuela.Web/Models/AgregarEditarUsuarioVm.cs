using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Web.Models
{
    public class AgregarEditarUsuarioVm
    {
        public AgregarEditarUsuarioVm()
        {
            EsEditar = false;
            Activo = true;
        }

        public string NombreUsuario { get; set; }

        public int IdRol { get; set; }

        public string Password { get; set; }

        public bool Activo { get; set; }

        public bool EsEditar { get; set; }

        /// <summary>
        /// Lista de roles
        /// </summary>
        public List<Rol> Roles { get; set; }
    }
}