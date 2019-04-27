using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
   public class CensoMaestro//clase que contiene el master de las tablas
    {
        public int Id { get; set; }

        [Display(Name = "Periodo")]
        public int PeriodoId { get; set; }

        public Periodo Periodo { get; set; }

        [Display(Name="Alumno")]
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public List<CensoDetalle> ListadeCensoDetalle { get; set; }
        public CensoMaestro()
        {
            ListadeCensoDetalle = new List<CensoDetalle>();
        }
    }

    public class CensoDetalle//clase que contiene el detalle
    {

        public int Id { get; set; }

        public int CensoMaestroId { get; set; }
        public  CensoMaestro CensoMaestro  { get; set; }
        [Display(Name = "Asignatura")]
        public int AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }

        [Display(Name = "Horario")]
        public int HorarioId { get; set; }
        public Horarios Horario { get; set; }



    }
}
