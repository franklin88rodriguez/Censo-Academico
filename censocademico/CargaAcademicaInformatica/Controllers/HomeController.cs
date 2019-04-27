using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademicaInformatica.Controllers
{
    public class HomeController : Controller
    {
        AlumnoBL _alumnosBL;

        public HomeController()
        {
            _alumnosBL = new AlumnoBL();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Alumno alumno)
        {
            var alumnoExistente = _alumnosBL.ObtenerAlumnoPorNcuenta(alumno.Ncuenta);

            if(alumnoExistente != null)
            {
                return RedirectToAction("Index", "Censo", new { Id = alumnoExistente.Id });
            }

            ModelState.AddModelError("Ncuenta", "Numero de cuenta no encontrado");

            return View();
        }
    }
}