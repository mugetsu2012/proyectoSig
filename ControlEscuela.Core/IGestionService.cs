using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Notas;

namespace ControlEscuela.Core
{
    public interface IGestionService:IDisposable
    {
        /// <summary>
        /// Trae las actividades con ssu includes
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="nombre"></param>
        /// <param name="idSeccionGrado"></param>
        /// <returns></returns>
        List<Actividad> GetListaActividades(DateTime fechaInicio, DateTime fechaFin, string nombre = "",
            int idSeccionGrado = 0);

        Actividad AgregarEditarActividad(Actividad actividad);

        /// <summary>
        /// Permite eliminar una actividad. Solo se elimina si no se ha realizado o calificado
        /// </summary>
        /// <param name="idActividad"></param>
        void EliminarActividad(int idActividad);

        /// <summary>
        /// Verifica si una actividad puede eliminarse
        /// </summary>
        /// <param name="idActvidad"></param>
        /// <returns></returns>
        bool ActividadPuedeEliminarse(int idActvidad);

        /// <summary>
        /// Extrae una lista de periodos
        /// </summary>
        /// <returns></returns>
        List<Periodo> GetPeriodos();

        /// <summary>
        /// Permite agregar o editar un periodo
        /// </summary>
        /// <param name="periodo"></param>
        /// <returns></returns>
        Periodo AgregarEditarPeriodo(Periodo periodo);


        /// <summary>
        /// Regresa una lista de calificaciones de una actividad para un grado
        /// </summary>
        /// <param name="idSeccionGrado"></param>
        /// <param name="idActividad"></param>
        /// <returns></returns>
        List<Calificacion> GetCalificaciones(int idSeccionGrado, int idActividad);


    }
}
