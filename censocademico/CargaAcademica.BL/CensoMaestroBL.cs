using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class CensoMaestroBL
    {
        Contexto _Contexto;
        public List<CensoMaestro> ListadeCenso { get; set; }

        public CensoMaestroBL()
        {
            _Contexto = new Contexto();
            ListadeCenso = new List<CensoMaestro>();
          
        }

     

        public void GuardarCenso(CensoMaestro censo)
        {
            if (censo.Id == 0)
            {
                _Contexto.CensosMaestros.Add(censo);
            }
            else
            {
                var censoExistente = _Contexto.CensosMaestros.Find(censo.Id);

                censoExistente.Id = censo.Id;
                //periodoExistente.año = censo.;

            }

            _Contexto.SaveChanges();
        }

        public void GuardarCensoDetalle(CensoDetalle censoDetalle)
        {
            _Contexto.CensosDetalles.Add(censoDetalle);
            _Contexto.SaveChanges();
        }

        public CensoMaestro ObtenerCenso(int id)
        {
            var Censo = _Contexto.CensosMaestros.Include("Periodo").Include("Alumno").FirstOrDefault(r => r.Id == id);

            return Censo;
        
        }
        public List<CensoDetalle> ObtenerCensoDetalle(int censoId)
        {
            var listadeCensoDetalle = _Contexto.CensosDetalles
                .Include("Asignatura")
                .Where(c => c.CensoMaestroId == censoId).ToList();

            return listadeCensoDetalle;
        }

        public CensoDetalle ObtenercensoDetallePorId(int id)
        {
            var censoDetalle = _Contexto.CensosDetalles.Find(id);
            return censoDetalle;
        }
        public List<CensoMaestro> ObtenerCensos()
        {
            var listadeCensos = _Contexto.CensosMaestros
                .Include("Periodo")
                .Include("Alumno")
                .ToList();

            return listadeCensos;
        }

        public void EliminarCensoDetalle(int id)
        {
            var censoDetalle = _Contexto.CensosDetalles.Find(id);
            _Contexto.CensosDetalles.Remove(censoDetalle);


            var Censo = _Contexto.CensosDetalles.Find(censoDetalle.CensoMaestroId);

            _Contexto.SaveChanges();
        }
      
        //metodo para uso del censo exitoso
        public void nuevoCenso(CensoMaestro censo)    
        {


            foreach (var detalle in censo.ListadeCensoDetalle)
            {
                if (detalle.HorarioId > 0)
                {

                    var nuevoCensoDetalle = new CensoDetalle();

                    var asignaturaId = detalle.AsignaturaId;
                    var horarioId = detalle.HorarioId;

                    var CensoId = detalle.CensoMaestroId;

                    nuevoCensoDetalle.HorarioId = horarioId;
                    nuevoCensoDetalle.AsignaturaId = asignaturaId;
                    nuevoCensoDetalle.CensoMaestroId = CensoId;


                    _Contexto.CensosDetalles.Add(nuevoCensoDetalle);

             
               }

               
            }

            _Contexto.SaveChanges();
        }

        public void censoDetalleExistente(CensoMaestro censo )
        {


        }
        }
}
//crear nuevo y editar