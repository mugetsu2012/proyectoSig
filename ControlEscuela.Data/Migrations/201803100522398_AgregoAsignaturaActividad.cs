namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregoAsignaturaActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "IdAsignatura", c => c.Int(nullable: false));
            CreateIndex("dbo.Actividad", "IdAsignatura");
            AddForeignKey("dbo.Actividad", "IdAsignatura", "dbo.Asignatura", "Codigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Actividad", "IdAsignatura", "dbo.Asignatura");
            DropIndex("dbo.Actividad", new[] { "IdAsignatura" });
            DropColumn("dbo.Actividad", "IdAsignatura");
        }
    }
}
