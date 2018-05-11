using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Core
{
    public interface IAsignaturaService:IDisposable
    {
        /// <summary>
        /// Obtiene una lista de asignaturas
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        List<Asignatura> GetAsignaturas(string nombre ="");

        /// <summary>
        /// Recupera una asignatura
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Asignatura GetAsignatura(int codigo);

        /// <summary>
        /// Inserta o edita una asignatura
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        Asignatura IngresarEditarAsignatura(int codigo, string nombre);

        /// <summary>
        /// Permite eliminar una asignatura, solo si no tiene nada asociado
        /// </summary>
        /// <param name="codigo"></param>
        void EliminarAsignatura(int codigo);
    }
}
