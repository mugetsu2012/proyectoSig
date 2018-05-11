using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Dtos;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Services
{
    public class AlumnosService: IAlumnosService
    {
        private readonly IRepository<Estudiante> _estudianteRepository;
        private readonly IRepository<AsistenciaAlumno> _asistenciaAlumnoRepository;
        private readonly IRepository<Asistencia> _asistenciaRepository;

        public AlumnosService(IRepository<Estudiante> estudianteRepository, 
            IRepository<AsistenciaAlumno> asistenciaAlumnoRepository,
            IRepository<Asistencia> asistenciaRepository)
        {
            _estudianteRepository = estudianteRepository;
            _asistenciaAlumnoRepository = asistenciaAlumnoRepository;
            _asistenciaRepository = asistenciaRepository;
        }

        public void Dispose()
        {
            _estudianteRepository.Dispose();
            _asistenciaAlumnoRepository.Dispose();
            _asistenciaRepository.Dispose();
        }

        public void AgregarEditarEstudiante(Estudiante estudiante, bool esNuevo)
        {
            if (esNuevo)
            {
                _estudianteRepository.Insert(estudiante);
            }
            else
            {
                _estudianteRepository.Update(estudiante);
            }
        }

        public List<Estudiante> GetListaEstudiantes(string nombre = "", string nie = "", int seccionGrado = 0, Enums.Estado estado = Enums.Estado.Todos)
        {
            List<Estudiante> estudiantes = _estudianteRepository.GetList(
                x => (x.Nombres.Contains(nombre) || nombre == "") && (x.Nie == nie || nie == "") &&
                     (x.IdSeccionGrado == seccionGrado || seccionGrado == 0) &&
                     ((estado == Enums.Estado.Activo && x.Activo) ||
                      (estado == Enums.Estado.Inactivo && x.Activo == false) || (estado == Enums.Estado.Todos)),
                new Expression<Func<Estudiante, object>>[]
                {
                    x => x.SeccionGrado.Grado
                });

            return estudiantes;
        }

        public Estudiante GetEstudiante(int idEstudiante)
        {
            return _estudianteRepository.FindBy(x => x.Codigo == idEstudiante);
        }

        public void ActivarDesactivarEstudiante(int idEstudiante)
        {
            Estudiante estudiante = _estudianteRepository.FindByTracking(x => x.Codigo == idEstudiante);
            estudiante.Activo = !estudiante.Activo;
            _estudianteRepository.SaveChanges();
        }

        public void MarcarAsistencia(MarcarAsistenciaDto marcarAsistenciaDto)
        {
            if (AsistenciaYaTomada(marcarAsistenciaDto.IdSeccionGrado, marcarAsistenciaDto.FechaAsistencia))
            {
                throw new ArgumentException("La asistencia ya fue tomada previmante");
            }
            else
            {
                foreach (AsistenciaAlumnoDto asistenciaAlumnoDto in marcarAsistenciaDto.AsistenciaAlumnoDtos)
                {
                    AsistenciaAlumno asistenciaAlumno = new AsistenciaAlumno()
                    {
                        Asistencia = new Asistencia()
                        {
                            IdProfesor = marcarAsistenciaDto.IdProfesor,
                            FechaIngreso = marcarAsistenciaDto.FechaAsistencia,
                            IdSeccionGrado = marcarAsistenciaDto.IdSeccionGrado

                        },
                        Asistio = asistenciaAlumnoDto.Asiste,
                        IdEstudiante = asistenciaAlumnoDto.CodigAlumno
                    };

                    _asistenciaAlumnoRepository.Insert(asistenciaAlumno);
                }
            }
            
        }

        public bool AsistenciaYaTomada(int idSeccionGrado, DateTime fechaMarcar)
        {
            Asistencia asistencia =
                _asistenciaRepository.FindBy(x => x.IdSeccionGrado == idSeccionGrado && x.FechaIngreso == fechaMarcar);

            return asistencia != null;
        }
    }
}
