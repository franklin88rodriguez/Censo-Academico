using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class AsignaturasBL
    {
        Contexto _contexto;
        public List<Asignatura> ListadeAsignaturas { get; set; }

        public AsignaturasBL()
        {
            _contexto = new Contexto();
            ListadeAsignaturas = new List<Asignatura>();
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            ListadeAsignaturas = _contexto.Asignaturas.OrderBy(r => r.NombreAsignatura).ToList();

            return ListadeAsignaturas;

        }
        public List<Asignatura> ObtenerAsignaturasActivos()

        {
            ListadeAsignaturas = _contexto.Asignaturas

                 .Where(r => r.Activo == true)
                 .OrderBy(r => r.NombreAsignatura )
                .ToList();
            
            return ListadeAsignaturas;
        }


        public void GuardarAsignatura(Asignatura asignatura)
        {
            if (asignatura.Id == 0)
            {
                _contexto.Asignaturas.Add(asignatura);
            }
            else
            {
                var asignaturaExistente = _contexto.Asignaturas.Find(asignatura.Id);

                asignaturaExistente.Seccion = asignatura.Seccion;
                asignaturaExistente.NumeroEdificio = asignatura.NumeroEdificio;
                asignaturaExistente.NombreAsignatura = asignatura.NombreAsignatura;
                asignaturaExistente.NombreCatedratico = asignatura.NombreCatedratico;
                asignaturaExistente.Activo = asignatura.Activo;
            }

            _contexto.SaveChanges();
        }

        public Asignatura ObtenerAsignatura(int id)
        {
            var asignatura = _contexto.Asignaturas.Find(id);

            return asignatura;
        }

        public void EliminarAsignatura(int id)
        {
            var asignatura = _contexto.Asignaturas.Find(id);

            _contexto.Asignaturas.Remove(asignatura);
            _contexto.SaveChanges();
        }
    }
}
