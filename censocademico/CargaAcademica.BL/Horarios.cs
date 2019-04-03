using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class Horarios
    {
        public int Id { get; set; }
        public bool Activo { get; set; }

        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string Horario { get; set; }
        

    }
}
