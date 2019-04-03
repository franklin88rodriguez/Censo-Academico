using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class AsignaturasController : Controller
    {
        AsignaturasBL _asignaturasBL;

        public AsignaturasController()
        {
            _asignaturasBL = new AsignaturasBL();
        }

        // GET: Asignaturas
        public ActionResult Index()
        {
            var listadeAsignaturas = _asignaturasBL.ObtenerAsignaturas();

            return View(listadeAsignaturas);
        }

        public ActionResult Crear()
        {
            var nuevaAsignatura = new Asignatura();

            return View(nuevaAsignatura);
        }

        [HttpPost]
        public ActionResult Crear(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _asignaturasBL.GuardarAsignatura(asignatura);

                return RedirectToAction("Index");
            }

            return View(asignatura);
        }

        public ActionResult Editar(int id)
        {
            var asignatura = _asignaturasBL.ObtenerAsignatura(id);

            return View(asignatura);
        }

        [HttpPost]
        public ActionResult Editar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _asignaturasBL.GuardarAsignatura(asignatura);

                return RedirectToAction("Index");
            }

            return View(asignatura);
        }

        public ActionResult Detalle(int id)
        {
            var asignatura = _asignaturasBL.ObtenerAsignatura(id);

            return View(asignatura);
        }

        public ActionResult Eliminar(int id)
        {
            var asignatura = _asignaturasBL.ObtenerAsignatura(id);

            return View(asignatura);
        }

        [HttpPost]
        public ActionResult Eliminar(Asignatura asignatura)
        {
            _asignaturasBL.EliminarAsignatura(asignatura.Id);

            return RedirectToAction("Index");
        }
    }
}