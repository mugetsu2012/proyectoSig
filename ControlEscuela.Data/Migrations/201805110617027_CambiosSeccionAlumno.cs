namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosSeccionAlumno : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeccionGradoAlumno", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.SeccionGradoAlumno", "IdSeccionGrado", "dbo.SeccionGrado");
            DropIndex("dbo.SeccionGradoAlumno", new[] { "IdSeccionGrado" });
            DropIndex("dbo.SeccionGradoAlumno", new[] { "IdEstudiante" });
            DropTable("dbo.SeccionGradoAlumno");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SeccionGradoAlumno",
                c => new
                    {
                        IdSeccionGrado = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdSeccionGrado, t.IdEstudiante });
            
            CreateIndex("dbo.SeccionGradoAlumno", "IdEstudiante");
            CreateIndex("dbo.SeccionGradoAlumno", "IdSeccionGrado");
            AddForeignKey("dbo.SeccionGradoAlumno", "IdSeccionGrado", "dbo.SeccionGrado", "Codigo", cascadeDelete: true);
            AddForeignKey("dbo.SeccionGradoAlumno", "IdEstudiante", "dbo.Estudiante", "Codigo");
        }
    }
}
