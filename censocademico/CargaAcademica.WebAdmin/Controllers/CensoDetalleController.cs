using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class CensoDetalleController : Controller
    {
        AsignaturasBL _asignaturasBL;
        CensoMaestroBL _censoMaestroBL;
        HorariosBL _horarioBL;


        public CensoDetalleController()
        {
            _censoMaestroBL = new CensoMaestroBL();
            _asignaturasBL = new AsignaturasBL();
            _horarioBL = new HorariosBL();

        }
        // GET: CensoDetalle
        public ActionResult Index(int id)
        {
            var censo = _censoMaestroBL.ObtenerCenso(id);
            censo.ListadeCensoDetalle = _censoMaestroBL.ObtenerCensoDetalle(id);
            return View(censo);
        }

        public ActionResult Crear(int id)
        {
            var nuevoCensoDetalle = new CensoDetalle();
            nuevoCensoDetalle.CensoMaestroId = id;
            var asignaturas = _asignaturasBL.ObtenerAsignaturas();

            ViewBag.AsignaturaId = new SelectList(asignaturas, "Id", "NombreAsignatura");

            var horarios = _horarioBL.ObtenerHorarios();

            ViewBag.HorarioId = new SelectList(horarios, "Id", "Horario");

            return View(nuevoCensoDetalle);

        }
        [HttpPost]
        public ActionResult Crear(CensoDetalle censoDetalle)
        {
            if (ModelState.IsValid)
            {
                /*  if (censoDetalle.AsignaturaId == 0)
                  {

                  }*/
                _censoMaestroBL.GuardarCensoDetalle(censoDetalle);
                return RedirectToAction("Index", new { id = censoDetalle.CensoMaestroId });
            }


            var asignaturas = _asignaturasBL.ObtenerAsignaturasActivos();

            ViewBag.AsignaturaId = new SelectList(asignaturas, "Id", "NombreAsignatura");

            var horarios = _horarioBL.ObtenerHorarios();

            ViewBag.HorarioId = new SelectList(horarios, "Id", "Horario");

            return View(censoDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var censoDetalle = _censoMaestroBL.ObtenerCensoDetalle(id);
            return View(censoDetalle);

        }

        [HttpPost]
        public ActionResult Eliminar(CensoDetalle censoDetalle)
        {

            _censoMaestroBL.EliminarCensoDetalle(censoDetalle.Id);

            return RedirectToAction("index", new { id = censoDetalle.CensoMaestroId });

       
        }

    }

}