using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class CensoMasterController : Controller
    {

        CensoMaestroBL _CensosMasterBL;

        PeriodoBL _PeriodoBL;

        AlumnoBL _AlumnoBL;

        public CensoMasterController()//constructor para inicializar
        {
            _CensosMasterBL = new CensoMaestroBL();//inicializando variable _CensosMasterBL

            _PeriodoBL = new PeriodoBL();

            _AlumnoBL = new AlumnoBL();
        }
        // GET: CensoMaster
        public ActionResult Index()
        {
            var listadeCenso = _CensosMasterBL.ObtenerCensos();

            return View(listadeCenso);
        }

        public ActionResult Crear()
        {
            var nuevoCenso = new CensoMaestro();

            var periodos = _PeriodoBL.ObtenerPeriodosActivos();

            var alumnos = _AlumnoBL.ObtenerAlumnosActivos();


            ViewBag.PeriodoId = new SelectList(periodos, "Id", "numero");

            ViewBag.AlumnoId = new SelectList(alumnos, "Id", "NombreAlumno");


            return View(nuevoCenso);
        }

        [HttpPost]
        public ActionResult Crear(CensoMaestro censo)
        {
            if (ModelState.IsValid)
            {
                _CensosMasterBL.GuardarCenso(censo);

                return RedirectToAction("Index");
            }

            return View(censo);
        }


        public ActionResult Editar(int id)
        {
            var censo = _CensosMasterBL.ObtenerCensoDetalle(id);

            return View(censo);
        }

        [HttpPost]
        public ActionResult Editar(CensoMaestro censo)
        {
            if (ModelState.IsValid)
            {
                _CensosMasterBL.GuardarCenso(censo);

                return RedirectToAction("Index");
            }

            return View(censo);
        }


    }
}