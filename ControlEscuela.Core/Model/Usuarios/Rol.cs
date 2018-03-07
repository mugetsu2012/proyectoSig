using System.Collections.Generic;

namespace ControlEscuela.Core.Model.Usuarios
{
    public class Rol
    {
        /// <summary>
        /// Llave del rol
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Nombre del rol
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del rol
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Usuarios de este rol
        /// </summary>
        public List<Usuario> Usuarios { get; set; }
    }
}
