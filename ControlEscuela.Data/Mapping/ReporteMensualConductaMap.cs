using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Data.Mapping
{
    class ReporteMensualConductaMap: EntityTypeConfiguration<ReporteMensualConducta>
    {
        public ReporteMensualConductaMap()
        {
            HasKey(t => t.Codigo);

            Property(t => t.Codigo).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.FechaIngreso).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(t => t.Comentario).HasMaxLength(5000).HasColumnType("varchar");
            Property(t => t.TipoConducta).IsRequired();
            Property(t => t.TextoConducta).IsRequired().HasMaxLength(500).HasColumnType("varchar");

            HasRequired(t => t.SeccionGrado).WithMany().HasForeignKey(f => f.IdSeccionGrado);
            HasRequired(t => t.Profesor).WithMany().HasForeignKey(f => f.IdProfesor);
            HasRequired(t => t.Estudiante).WithMany().HasForeignKey(f => f.IdEstudiante);

            ToTable("ReporteMensualConducta");
        }
    }
}
