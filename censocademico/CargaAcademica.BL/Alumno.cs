using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
   public class Alumno//clase donde solo estan las propiedades del alumno paso 2
    {
        public Alumno()
        {

            Activo = true;
        }

        [Required (ErrorMessage ="Ingrese el ID del alumno")]//validacion que no permite dejar vacio el campo Id
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string NombreAlumno { get; set; }

        [Display(Name ="Imagen")]
        public string UrlImagen { get; set; }

        public bool Activo { get; set; }
    }

}
