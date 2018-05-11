using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Services
{
    public class GradosService: IGradosService
    {
        private readonly IRepository<Grado> _gradoRepository;
        private readonly IRepository<SeccionGrado> _seccionGradoRepository;
        private readonly IRepository<AsistenciaAlumno> _asistenciaAlumnoRepository;

        public GradosService(IRepository<Grado> gradoRepository,
            IRepository<SeccionGrado> seccionGradoRepository, 
            IRepository<AsistenciaAlumno> asistenciaAlumnoRepository)
        {
            _gradoRepository = gradoRepository;
            _seccionGradoRepository = seccionGradoRepository;
            _asistenciaAlumnoRepository = asistenciaAlumnoRepository;
        }

        public void Dispose()
        {
            _gradoRepository.Dispose();
            _seccionGradoRepository.Dispose();
            _asistenciaAlumnoRepository.Dispose();
        }

        public List<SeccionGrado> GetListaGrados(string nombresGrados ="", string profesor = "", Enums.Turno turno = Enums.Turno.Todos)
        {
            return _seccionGradoRepository.GetList(x =>
                (x.Grado.TextoGrado.Contains(nombresGrados) || nombresGrados == "") &&
                (x.Profesor.Nombres.Contains(profesor) || x.Profesor.Apellidos.Contains(profesor) ||
                 profesor == "") &&
                (x.Turno == turno || turno == Enums.Turno.Todos), new Expression<Func<SeccionGrado, object>>[]
            {
                x => x.Profesor,
                x => x.Estudiantes,
                x => x.Actividades,
                x => x.Grado
            });
        }

        public SeccionGrado AgregarEditarSeccionGrado(SeccionGrado seccionGrado)
        {
            if (seccionGrado.Codigo == 0)
            {
                seccionGrado.LetraCorrelativo = GetSiguienteLetraCorrelativoSeccionGrado(seccionGrado.IdGrado);
                _seccionGradoRepository.Insert(seccionGrado);
            }
            else
            {
                SeccionGrado seccionGradoUpdate = _seccionGradoRepository.FindByTracking(x =>
                    x.Codigo == seccionGrado.Codigo && x.IdGrado == seccionGrado.IdGrado);

                seccionGradoUpdate.IdProfesor = seccionGradoUpdate.IdProfesor;
                seccionGradoUpdate.Turno = seccionGradoUpdate.Turno;
                _seccionGradoRepository.SaveChanges();
            }

            return seccionGrado;
        }

        public string GetSiguienteLetraCorrelativoSeccionGrado(int idGrado)
        {
            string siguienteLetra;
            List<SeccionGrado> seccionesGrado = _seccionGradoRepository.GetList(x => x.IdGrado == idGrado);

            
            if (!seccionesGrado.Any())
                siguienteLetra = "A";
            else if (seccionesGrado.Last().LetraCorrelativo == "Z")
                siguienteLetra = "A";
            else
            {
                char letter = seccionesGrado.Last().LetraCorrelativo.ToCharArray()[0];
                siguienteLetra = ((char)(((int)letter) + 1)).ToString();
            }
            return siguienteLetra;
        }

        public Grado GetGrado(int codigo)
        {
            return _gradoRepository.FindBy(x => x.Codigo == codigo);
        }

        public SeccionGrado GetSeccionGrado(int idSeccionGrado)
        {
            return _seccionGradoRepository.FindBy(x => x.Codigo == idSeccionGrado);
        }

        public List<AsistenciaAlumno> GetEstudiantesAsistencia(int idSeccionGrado, DateTime fechaAsistencia)
        {
            List<AsistenciaAlumno> asistenciaAlumnos = _asistenciaAlumnoRepository.GetList(
                x => x.Asistencia.IdSeccionGrado == idSeccionGrado && x.Asistencia.FechaIngreso == fechaAsistencia);

            return asistenciaAlumnos;
        }
    }
}
