using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Data.Mapping
{
    class DiasAsignaturaSeccionGradoMap:EntityTypeConfiguration<DiasAsignaturaSeccionGrado>
    {
        public DiasAsignaturaSeccionGradoMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.HoraInicio).IsRequired();
            Property(t => t.HoraFin).IsRequired();
            Property(t => t.DiaSemana).IsRequired();
            Property(t => t.TextoDiaSemana).IsRequired();

            HasRequired(t => t.AsignaturaSeccionGrado)
                .WithMany(m => m.DiasAsignaturaSeccionGrados)
                .HasForeignKey(f => new {f.IdAsignatura, f.IdSeccionGrado});

            ToTable("DiasAsignaturaSeccionGrado");



        }
    }
}
