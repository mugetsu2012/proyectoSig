using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Services
{
    public class AsignaturaService: IAsignaturaService
    {
        private readonly IRepository<Asignatura> _asignaturaRepository;


        public AsignaturaService(IRepository<Asignatura> asignaturaRepository)
        {
            _asignaturaRepository = asignaturaRepository;
        }

        public void Dispose()
        {
            _asignaturaRepository.Dispose();
        }

        public List<Asignatura> GetAsignaturas(string nombre = "")
        {
            return _asignaturaRepository.GetList(x => x.Nombre.Contains(nombre) || nombre == "");
        }

        public Asignatura GetAsignatura(int codigo)
        {
            return _asignaturaRepository.FindBy(x => x.Codigo == codigo);
        }

        public Asignatura IngresarEditarAsignatura(int codigo, string nombre)
        {
            Asignatura asignatura = new Asignatura()
            {
                Codigo = codigo,
                Nombre = nombre
            };

            if (codigo == 0)
            {
                _asignaturaRepository.Insert(asignatura);
            }
            else
            {
                _asignaturaRepository.Update(asignatura);
            }

            return asignatura;
        }

        public void EliminarAsignatura(int codigo)
        {
            Asignatura asignatura = new Asignatura()
            {
                Codigo = codigo
            };

            _asignaturaRepository.Delete(asignatura);
        }
    }
}
