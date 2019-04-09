using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class PeriodoBL
    {
        Contexto _contexto;

        public List<Periodo> ListadePeriodos { get; set; }

        public PeriodoBL()
        {
            _contexto = new Contexto();
            ListadePeriodos = new List<Periodo>();

            
        }

        public List<Periodo> ObtenerPeriodos()
        {
            ListadePeriodos = _contexto.Periodos.ToList();

            return ListadePeriodos;
        }
        public List<Periodo> ObtenerPeriodosActivos()
        {
            ListadePeriodos = _contexto.Periodos
                   //.Where(r => r.Activo == true)
                 .OrderBy(r => r.numero)
                .ToList();

            return ListadePeriodos;
        }


        public Periodo ObtenerPeriodo(int id)
        {
            var periodo = _contexto.Periodos.Find(id);

            return periodo;
        }

        public void EliminarPeriodo(int id)
        {
            var periodo = _contexto.Periodos.Find(id);

            _contexto.Periodos.Remove(periodo);
            _contexto.SaveChanges();
        }

        public void GuardarPeriodo(Periodo periodo)
        {
            if (periodo.Id == 0)
            {
                _contexto.Periodos.Add(periodo);
            }
            else
            {
                var periodoExistente = _contexto.Periodos.Find(periodo.Id);

                periodoExistente.numero = periodo.numero;
                periodoExistente.año = periodo.año;
                
            }

            _contexto.SaveChanges();
        }

    }
}
