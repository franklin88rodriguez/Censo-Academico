using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademicaInformatica.Controllers
{
    public class AlumnoController : Controller
    {
        AlumnoBL _alumnoBL;

        public AlumnoController()
        {
            _alumnoBL = new AlumnoBL();
        }

        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            var alumno = _alumnoBL.ObtenerAlumnos(id);

            if (alumno != null)
            {
                return RedirectToAction("Index", "Home", new { id = alumno.Id });
            }

            return RedirectToAction("Index");
        }
    }
}