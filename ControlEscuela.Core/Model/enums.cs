﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscuela.Core.Model
{
    public class Enums
    {
        public enum NombresGrados
        {
            Primero,
            Segundo,
            Tercero,
            Cuarto,
            Quinto,
            Sexto,
            Septimo,
            Octavo,
            Noveno
        }

        public enum Turno
        {
            [Display(Name = "Todos")]
            Todos,
            [Display(Name = "Mañana")]
            Manniana,
            [Display(Name = "Tarde")]
            Tarde
        }

        public enum TipoConducta
        {
            Excelente,
            MuyBuena,
            Buena,
            Regular,
            NecesitaMejorar
        }

        public enum TipoFalta
        {
            Leve,
            Grave,
            MuyGrave
        }

        public enum DiasSemana
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes
        }

        public enum TipoActividad
        {
            Examen,
            Tarea,
            Exposicion,
            EvaluadoCorto,
            Extracurricular,
            Otro
        }
        
        public enum Estado
        {
            Todos,
            Activo,
            Inactivo
        }


    }
}
