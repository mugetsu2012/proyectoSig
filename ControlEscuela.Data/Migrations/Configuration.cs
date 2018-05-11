using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Grados;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ControlEscuela.Data.ControlEscuelaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControlEscuela.Data.ControlEscuelaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Grados.AddOrUpdate(p => p.Codigo,
                new Grado() {Codigo = 1, NombreGrado = Enums.NombresGrados.Primero},
                new Grado() {Codigo = 2, NombreGrado = Enums.NombresGrados.Segundo},
                new Grado() { Codigo = 3, NombreGrado = Enums.NombresGrados.Tercero },
                new Grado() { Codigo = 4, NombreGrado = Enums.NombresGrados.Cuarto },
                new Grado() { Codigo = 5, NombreGrado = Enums.NombresGrados.Quinto },
                new Grado() { Codigo = 6, NombreGrado = Enums.NombresGrados.Sexto },
                new Grado() { Codigo = 7, NombreGrado = Enums.NombresGrados.Septimo },
                new Grado() { Codigo = 8, NombreGrado = Enums.NombresGrados.Octavo },
                new Grado() { Codigo = 9, NombreGrado = Enums.NombresGrados.Noveno }
                );

            
        }
    }
}
