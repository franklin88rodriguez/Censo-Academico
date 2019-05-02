using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
   public class Periodo
    {
        public int Id  { get; set; }
        [Display(Name = "Número")]
        public int numero { get; set; }
        [Display(Name = "Año")]
        public int año { get; set; }
        public bool Activo { get; set; }
        //    public Boolean activo { get; set; }
    }
}
