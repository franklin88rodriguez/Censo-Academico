using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class Asignatura
    {
        public Asignatura()
        {

            Activo = true;
        }

        [Display(Name = "ID")]
        public int Id { get; set; }
        public string Seccion { get; set; }

        [Display(Name = "Numero de Edificio")]
        public string NumeroEdificio { get; set; }
        [Display(Name = "Nombre de Asignatura")]
        public string NombreAsignatura { get; set; }

        [Display(Name = "Nombre de Catedratico")]
        public string NombreCatedratico { get; set; }

        public bool Activo { get; set; }


    }
}
