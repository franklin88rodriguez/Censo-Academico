using System;
using System.Collections.Generic;
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


        public int Id { get; set; }
        public string Seccion { get; set; }
        public string NumeroEdificio { get; set; }
        public string NombreAsignatura { get; set; }
        public string NombreCatedratico { get; set; }

        public bool Activo { get; set; }


    }
}
