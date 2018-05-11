namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosUsuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropPrimaryKey("dbo.Rol");
            AlterColumn("dbo.Rol", "Codigo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rol", "Codigo");
            AddForeignKey("dbo.Usuario", "IdRol", "dbo.Rol", "Codigo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdRol", "dbo.Rol");
            DropPrimaryKey("dbo.Rol");
            AlterColumn("dbo.Rol", "Codigo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rol", "Codigo");
            AddForeignKey("dbo.Usuario", "IdRol", "dbo.Rol", "Codigo", cascadeDelete: true);
        }
    }
}
