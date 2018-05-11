using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core
{
    public interface ICatalogosService: IDisposable
    {
        /// <summary>
        /// Regresa 
        /// </summary>
        /// <returns></returns>
        List<SeccionGrado> GetSeccionesGrados();

        /// <summary>
        /// Regresa una lista de asignaturas
        /// </summary>
        /// <returns></returns>
        List<Asignatura> GetAsignaturas();

        /// <summary>
        /// Me trae todos los grados
        /// </summary>
        /// <returns></returns>
        List<Grado> GetGrados();


    }
}
