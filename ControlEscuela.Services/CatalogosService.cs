using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Services
{
    public class CatalogosService: ICatalogosService
    {
        private readonly IRepository<SeccionGrado> _seccionGradoRepository;
        private readonly IRepository<Asignatura> _asignaturaRepository;
        private readonly IRepository<Grado> _gradoRepository;

        public CatalogosService(IRepository<SeccionGrado> seccionGradoRepository,
            IRepository<Asignatura> asignaturaRepository, 
            IRepository<Grado> gradoRepository)
        {
            _seccionGradoRepository = seccionGradoRepository;
            _asignaturaRepository = asignaturaRepository;
            _gradoRepository = gradoRepository;
        }

        public void Dispose()
        {
            _asignaturaRepository.Dispose();
            _seccionGradoRepository.Dispose();
            _gradoRepository.Dispose();
        }

        public List<SeccionGrado> GetSeccionesGrados()
        {
            return _seccionGradoRepository.GetList(x => true, new Expression<Func<SeccionGrado, object>>[]
            {
                x => x.Grado
            });
        }

        public List<Asignatura> GetAsignaturas()
        {
            return _asignaturaRepository.GetList(x => true);
        }

        public List<Grado> GetGrados()
        {
            return _gradoRepository.GetList(x => true);
        }
    }
}
