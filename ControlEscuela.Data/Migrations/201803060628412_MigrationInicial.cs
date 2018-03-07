namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividad",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        IdSeccionGrado = c.Int(nullable: false),
                        Ponderacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdPeriodo = c.Int(nullable: false),
                        FechaRealizacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Periodo", t => t.IdPeriodo, cascadeDelete: true)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdSeccionGrado)
                .Index(t => t.IdPeriodo);
            
            CreateTable(
                "dbo.Periodo",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.SeccionGrado",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        IdGrado = c.Int(nullable: false),
                        LetraCorrelativo = c.String(nullable: false, maxLength: 50, unicode: false),
                        Turno = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        TextoTurno = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Grado", t => t.IdGrado, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .Index(t => t.IdGrado)
                .Index(t => t.IdProfesor);
            
            CreateTable(
                "dbo.AsignaturaSeccionGrado",
                c => new
                    {
                        IdAsignatura = c.Int(nullable: false),
                        IdSeccionGrado = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdAsignatura, t.IdSeccionGrado })
                .ForeignKey("dbo.Asignatura", t => t.IdAsignatura, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdAsignatura)
                .Index(t => t.IdSeccionGrado)
                .Index(t => t.IdProfesor);
            
            CreateTable(
                "dbo.Asignatura",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.DiasAsignaturaSeccionGrado",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        IdAsignatura = c.Int(nullable: false),
                        IdSeccionGrado = c.Int(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        DiaSemana = c.Int(nullable: false),
                        TextoDiaSemana = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.AsignaturaSeccionGrado", t => new { t.IdAsignatura, t.IdSeccionGrado }, cascadeDelete: true)
                .Index(t => new { t.IdAsignatura, t.IdSeccionGrado });
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 500, unicode: false),
                        Apellidos = c.String(nullable: false, maxLength: 500, unicode: false),
                        Edad = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaIngreso = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        NombreGrado = c.Int(nullable: false),
                        TextoGrado = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.SeccionGradoAlumno",
                c => new
                    {
                        IdSeccionGrado = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false, defaultValueSql:"getDate()"),
                    })
                .PrimaryKey(t => new { t.IdSeccionGrado, t.IdEstudiante })
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdSeccionGrado)
                .Index(t => t.IdEstudiante);
            
            CreateTable(
                "dbo.Asistencia",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false, defaultValueSql:"getDate()"),
                        IdSeccionGrado = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdSeccionGrado)
                .Index(t => t.IdProfesor);
            
            CreateTable(
                "dbo.AsistenciaAlumno",
                c => new
                    {
                        IdAsistencia = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                        Asistio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdAsistencia, t.IdEstudiante })
                .ForeignKey("dbo.Asistencia", t => t.IdAsistencia, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .Index(t => t.IdAsistencia)
                .Index(t => t.IdEstudiante);
            
            CreateTable(
                "dbo.Calificacion",
                c => new
                    {
                        IdActividad = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comentario = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => new { t.IdActividad, t.IdEstudiante })
                .ForeignKey("dbo.Actividad", t => t.IdActividad, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .Index(t => t.IdActividad)
                .Index(t => t.IdEstudiante)
                .Index(t => t.IdProfesor);
            
            CreateTable(
                "dbo.FichaEstudiante",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        FechaIngreso = c.DateTime(nullable: false, defaultValueSql:"getDate()"),
                        IdEstudiante = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        IdSeccionGrado = c.Int(nullable: false),
                        Razon = c.String(nullable: false, maxLength: 5000, unicode: false),
                        TipoFalta = c.Int(nullable: false),
                        TextoTipoFalta = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdEstudiante)
                .Index(t => t.IdProfesor)
                .Index(t => t.IdSeccionGrado);
            
            CreateTable(
                "dbo.PersonaUsuario",
                c => new
                    {
                        IdPersona = c.Int(nullable: false),
                        IdUsuario = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.IdPersona, t.IdUsuario })
                .ForeignKey("dbo.Persona", t => t.IdPersona, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: true)
                .Index(t => t.IdPersona)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.Binary(nullable: false),
                        IdRol = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false, defaultValueSql:"getDate()"),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Rol", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ReporteMensualConducta",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        IdEstudiante = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false, defaultValueSql:"getDate()"),
                        Comentario = c.String(maxLength: 5000, unicode: false),
                        IdSeccionGrado = c.Int(nullable: false),
                        TipoConducta = c.Int(nullable: false),
                        TextoConducta = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .ForeignKey("dbo.Profesor", t => t.IdProfesor)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.IdEstudiante)
                .Index(t => t.IdProfesor)
                .Index(t => t.IdSeccionGrado);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        Nie = c.String(),
                        NombreEncargado = c.String(nullable: false, maxLength: 500),
                        TelefonoEncargado = c.String(nullable: false, maxLength: 20),
                        Direccion = c.String(nullable: false, maxLength: 1000),
                        IdSeccionGrado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Persona", t => t.Codigo)
                .ForeignKey("dbo.SeccionGrado", t => t.IdSeccionGrado, cascadeDelete: true)
                .Index(t => t.Codigo)
                .Index(t => t.IdSeccionGrado);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        Codigo = c.Int(nullable: false),
                        NumeroIdentificacion = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Persona", t => t.Codigo)
                .Index(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profesor", "Codigo", "dbo.Persona");
            DropForeignKey("dbo.Estudiante", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.Estudiante", "Codigo", "dbo.Persona");
            DropForeignKey("dbo.ReporteMensualConducta", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.ReporteMensualConducta", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.ReporteMensualConducta", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.PersonaUsuario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropForeignKey("dbo.PersonaUsuario", "IdPersona", "dbo.Persona");
            DropForeignKey("dbo.FichaEstudiante", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.FichaEstudiante", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.FichaEstudiante", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Calificacion", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Calificacion", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Calificacion", "IdActividad", "dbo.Actividad");
            DropForeignKey("dbo.AsistenciaAlumno", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.AsistenciaAlumno", "IdAsistencia", "dbo.Asistencia");
            DropForeignKey("dbo.Asistencia", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.Asistencia", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Actividad", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.SeccionGradoAlumno", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.SeccionGradoAlumno", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.SeccionGrado", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.SeccionGrado", "IdGrado", "dbo.Grado");
            DropForeignKey("dbo.AsignaturaSeccionGrado", "IdSeccionGrado", "dbo.SeccionGrado");
            DropForeignKey("dbo.AsignaturaSeccionGrado", "IdProfesor", "dbo.Profesor");
            DropForeignKey("dbo.DiasAsignaturaSeccionGrado", new[] { "IdAsignatura", "IdSeccionGrado" }, "dbo.AsignaturaSeccionGrado");
            DropForeignKey("dbo.AsignaturaSeccionGrado", "IdAsignatura", "dbo.Asignatura");
            DropForeignKey("dbo.Actividad", "IdPeriodo", "dbo.Periodo");
            DropIndex("dbo.Profesor", new[] { "Codigo" });
            DropIndex("dbo.Estudiante", new[] { "IdSeccionGrado" });
            DropIndex("dbo.Estudiante", new[] { "Codigo" });
            DropIndex("dbo.ReporteMensualConducta", new[] { "IdSeccionGrado" });
            DropIndex("dbo.ReporteMensualConducta", new[] { "IdProfesor" });
            DropIndex("dbo.ReporteMensualConducta", new[] { "IdEstudiante" });
            DropIndex("dbo.Usuario", new[] { "IdRol" });
            DropIndex("dbo.PersonaUsuario", new[] { "IdUsuario" });
            DropIndex("dbo.PersonaUsuario", new[] { "IdPersona" });
            DropIndex("dbo.FichaEstudiante", new[] { "IdSeccionGrado" });
            DropIndex("dbo.FichaEstudiante", new[] { "IdProfesor" });
            DropIndex("dbo.FichaEstudiante", new[] { "IdEstudiante" });
            DropIndex("dbo.Calificacion", new[] { "IdProfesor" });
            DropIndex("dbo.Calificacion", new[] { "IdEstudiante" });
            DropIndex("dbo.Calificacion", new[] { "IdActividad" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "IdEstudiante" });
            DropIndex("dbo.AsistenciaAlumno", new[] { "IdAsistencia" });
            DropIndex("dbo.Asistencia", new[] { "IdProfesor" });
            DropIndex("dbo.Asistencia", new[] { "IdSeccionGrado" });
            DropIndex("dbo.SeccionGradoAlumno", new[] { "IdEstudiante" });
            DropIndex("dbo.SeccionGradoAlumno", new[] { "IdSeccionGrado" });
            DropIndex("dbo.DiasAsignaturaSeccionGrado", new[] { "IdAsignatura", "IdSeccionGrado" });
            DropIndex("dbo.AsignaturaSeccionGrado", new[] { "IdProfesor" });
            DropIndex("dbo.AsignaturaSeccionGrado", new[] { "IdSeccionGrado" });
            DropIndex("dbo.AsignaturaSeccionGrado", new[] { "IdAsignatura" });
            DropIndex("dbo.SeccionGrado", new[] { "IdProfesor" });
            DropIndex("dbo.SeccionGrado", new[] { "IdGrado" });
            DropIndex("dbo.Actividad", new[] { "IdPeriodo" });
            DropIndex("dbo.Actividad", new[] { "IdSeccionGrado" });
            DropTable("dbo.Profesor");
            DropTable("dbo.Estudiante");
            DropTable("dbo.ReporteMensualConducta");
            DropTable("dbo.Rol");
            DropTable("dbo.Usuario");
            DropTable("dbo.PersonaUsuario");
            DropTable("dbo.FichaEstudiante");
            DropTable("dbo.Calificacion");
            DropTable("dbo.AsistenciaAlumno");
            DropTable("dbo.Asistencia");
            DropTable("dbo.SeccionGradoAlumno");
            DropTable("dbo.Grado");
            DropTable("dbo.Persona");
            DropTable("dbo.DiasAsignaturaSeccionGrado");
            DropTable("dbo.Asignatura");
            DropTable("dbo.AsignaturaSeccionGrado");
            DropTable("dbo.SeccionGrado");
            DropTable("dbo.Periodo");
            DropTable("dbo.Actividad");
        }
    }
}
