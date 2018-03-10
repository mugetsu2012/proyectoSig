namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregoNombreActividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actividad", "Nombre", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actividad", "Nombre");
        }
    }
}
