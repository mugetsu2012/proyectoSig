using System;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Asignaturas
{
    public class DiasAsignaturaSeccionGrado
    {
        public int Codigo { get; set; }

        public int IdAsignatura { get; set; }

        public int IdSeccionGrado { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public Enums.DiasSemana DiaSemana { get; set; }

        public string TextoDiaSemana
        {
            get => DiaSemana.ToString();
            set => DiaSemana = (Enums.DiasSemana)Enum.Parse(typeof(Enums.DiasSemana), value);
        }

        public AsignaturaSeccionGrado AsignaturaSeccionGrado { get; set; }


    }
}
