using System;

namespace ControlEscuela.Core.Model.Usuarios
{
    public class Usuario
    {
        /// <summary>
        /// Nombre de usuario y llave del campo
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Contraseña encriptada del usuario
        /// </summary>
        public byte[] Password { get; set; }

        /// <summary>
        /// codigo del usuario
        /// </summary>
        public int IdRol { get; set; }

        public int? IdPersona { get; set; }

        /// <summary>
        /// Fecha de ingreso de este rol
        /// </summary>
        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// Indica si el usuario está activo, solo se pueden loguear los usurios activos
        /// </summary>
        public bool Activo { get; set; }

        public Rol Rol { get; set; }

        /// <summary>
        /// Objeto persona Usuario
        /// </summary>
        public PersonaUsuario PersonaUsuario { get; set; }
    }
}
