using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Notas;

namespace ControlEscuela.Services
{
    public class GestionService: IGestionService
    {
        private readonly IRepository<Actividad> _actividadRepository;
        private readonly IRepository<Periodo> _periodoRepository;
        private readonly IRepository<Calificacion> _calificacionRepository;

        public GestionService(IRepository<Actividad> actividadRepository,
            IRepository<Periodo> periodoRepository,
            IRepository<Calificacion> calificacionRepository)
        {
            _actividadRepository = actividadRepository;
            _periodoRepository = periodoRepository;
            _calificacionRepository = calificacionRepository;
        }

        public void Dispose()
        {
            _actividadRepository.Dispose();
            _calificacionRepository.Dispose();
            _periodoRepository.Dispose();
        }

        public List<Actividad> GetListaActividades(DateTime fechaInicio, DateTime fechaFin, string nombre = "", int idSeccionGrado = 0)
        {
            List<Actividad> actividades =
                _actividadRepository.GetList(
                    x => (x.FechaRealizacion >= fechaInicio && x.FechaRealizacion <= fechaFin) &&
                         (x.Nombre.Contains(nombre) || nombre == "") &&
                         (x.IdSeccionGrado == idSeccionGrado || idSeccionGrado == 0));

            return actividades;
        }

        public Actividad AgregarEditarActividad(Actividad actividad)
        {
            if (actividad.Codigo == 0)
            {
                _actividadRepository.Insert(actividad);
            }
            else
            {
                _actividadRepository.Update(actividad);
            }

            return actividad;
        }

        public void EliminarActividad(int idActividad)
        {
            if (ActividadPuedeEliminarse(idActividad))
            {
                Actividad actividad = new Actividad()
                {
                    Codigo = idActividad
                };

                _actividadRepository.Delete(actividad);
            }
        }

        public bool ActividadPuedeEliminarse(int idActvidad)
        {
            if (_calificacionRepository.Table.Any(x => x.IdActividad == idActvidad))
            {
                return false;
            }

            return true;
        }

        public List<Periodo> GetPeriodos()
        {
            return _periodoRepository.GetList(x => true);
        }

        public Periodo AgregarEditarPeriodo(Periodo periodo)
        {
            if (periodo.Codigo == 0)
            {
                _periodoRepository.Insert(periodo);
            }
            else
            {
                _periodoRepository.Update(periodo);
            }

            return periodo;
        }

        public List<Calificacion> GetCalificaciones(int idSeccionGrado, int idActividad)
        {
            return _calificacionRepository.GetList(x => x.Actividad.Codigo == idActividad &&
                                                        x.Actividad.IdSeccionGrado == idSeccionGrado);
            
        }
    }
}
