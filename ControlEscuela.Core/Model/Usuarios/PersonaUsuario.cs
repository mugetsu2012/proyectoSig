using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Core.Model.Usuarios
{
    /// <summary>
    /// Tabla que permite crear un usuario para una Persona (Maestro o alumno)
    /// </summary>
    public class PersonaUsuario
    {
        public int IdPersona { get; set; }

        public string IdUsuario { get; set; }

        public Persona Persona { get; set; }

        public Usuario Usuario { get; set; }
    }
}
