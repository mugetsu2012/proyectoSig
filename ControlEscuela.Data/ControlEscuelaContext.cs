using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Core.Model.Grados;
using ControlEscuela.Core.Model.Notas;
using ControlEscuela.Core.Model.Usuarios;
using ControlEscuela.Data.Mapping;

namespace ControlEscuela.Data
{
    public class ControlEscuelaContext: DbContext
    {
        public ControlEscuelaContext() : base("ControlEscuelaContext")
        {
            
        }

        public DbSet<Actividad> Actividades { get; set; }

        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<AsignaturaSeccionGrado> AsignaturaSeccionGrados { get; set; }

        public DbSet<AsistenciaAlumno> AsistenciasAlumno { get; set; }

        public DbSet<Asistencia> Asistencias { get; set; }

        public DbSet<Calificacion> Calificaciones { get; set; }

        public DbSet<DiasAsignaturaSeccionGrado> DiasAsignaturaSeccionGrados { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<FichaEstudiante> FichasEstudiantes { get; set; }

        public DbSet<Grado> Grados { get; set; }

        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<PersonaUsuario> PersonasUsuario { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<ReporteMensualConducta> ReportesMensualesConsulta { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<SeccionGradoAlumno> SeccionesGradoAlumno { get; set; }

        public DbSet<SeccionGrado> SeccionesGrado { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ActividadMap());
            modelBuilder.Configurations.Add(new AsignaturaMap());
            modelBuilder.Configurations.Add(new AsignaturaSeccionGradoMap());
            modelBuilder.Configurations.Add(new AsistenciaAlumnoMap());
            modelBuilder.Configurations.Add(new AsistenciaMap());
            modelBuilder.Configurations.Add(new CalificacionMap());
            modelBuilder.Configurations.Add(new DiasAsignaturaSeccionGradoMap());
            modelBuilder.Configurations.Add(new EstudianteMap());
            modelBuilder.Configurations.Add(new FichaEstudianteMap());
            modelBuilder.Configurations.Add(new GradoMap());
            modelBuilder.Configurations.Add(new PeriodoMap());
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new PersonaUsuarioMap());
            modelBuilder.Configurations.Add(new ProfesorMap());
            modelBuilder.Configurations.Add(new ReporteMensualConductaMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new SeccionGradoAlumnoMap());
            modelBuilder.Configurations.Add(new SeccionGradoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

        }
    }
}
