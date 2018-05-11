namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosDataPersona : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "FechaIngreso", c => c.DateTime(nullable: false,defaultValueSql:"getdate()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "FechaIngreso", c => c.String());
        }
    }
}
