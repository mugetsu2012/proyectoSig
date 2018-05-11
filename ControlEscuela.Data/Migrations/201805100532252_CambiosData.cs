namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Periodo", "Nombre", c => c.String());
            AddColumn("dbo.Usuario", "IdPersona", c => c.Int());
            CreateIndex("dbo.Usuario", new[] { "IdPersona", "IdUsuario" });
            AddForeignKey("dbo.Usuario", new[] { "IdPersona", "IdUsuario" }, "dbo.PersonaUsuario", new[] { "IdPersona", "IdUsuario" });
            DropColumn("dbo.Persona", "Edad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persona", "Edad", c => c.Int(nullable: false));
            DropForeignKey("dbo.Usuario", new[] { "IdPersona", "IdUsuario" }, "dbo.PersonaUsuario");
            DropIndex("dbo.Usuario", new[] { "IdPersona", "IdUsuario" });
            DropColumn("dbo.Usuario", "IdPersona");
            DropColumn("dbo.Periodo", "Nombre");
        }
    }
}
