using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class PeriodosController : Controller
    {
        PeriodoBL _periodosBL;

        public PeriodosController()
        {
            _periodosBL = new PeriodoBL();
        }

        // GET: Periodos
        public ActionResult Index()
        {
            var listadePeriodos = _periodosBL.ObtenerPeriodos();

            return View(listadePeriodos);
        }

        public ActionResult Crear()
        {
            var nuevoPeriodo = new Periodo();

            return View(nuevoPeriodo);
        }

        [HttpPost]
        public ActionResult Crear(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _periodosBL.GuardarPeriodo(periodo);

                return RedirectToAction("Index");
            }

            return View(periodo);
        }

        public ActionResult Editar(int id)
        {
            var periodo = _periodosBL.ObtenerPeriodo(id);

            return View(periodo);
        }

        [HttpPost]
        public ActionResult Editar(Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _periodosBL.GuardarPeriodo(periodo);

                return RedirectToAction("Index");
            }

            return View(periodo);
        }

        public ActionResult Detalle(int id)
        {
            var periodo = _periodosBL.ObtenerPeriodo(id);

            return View(periodo);
        }

        public ActionResult Eliminar(int id)
        {
            var periodo = _periodosBL.ObtenerPeriodo(id);

            return View(periodo);
        }

        [HttpPost]
        public ActionResult Eliminar(Periodo periodo)
        {
            _periodosBL.EliminarPeriodo(periodo.Id);

            return RedirectToAction("Index");
        }
    }
}