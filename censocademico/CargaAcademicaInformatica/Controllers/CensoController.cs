using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademicaInformatica.Controllers
{
    
     
        
    public class CensoController : Controller
    {
        Contexto _Contexto;
        AlumnoBL _alumnosBL;
        AsignaturasBL _asignaturasBL;
        HorariosBL _horarioBL;
        CensoMaestroBL _censoMaestroBL;
      
       
        public CensoController()
        {
            _Contexto = new Contexto(); 
            _alumnosBL = new AlumnoBL();
            _asignaturasBL = new AsignaturasBL();
            _horarioBL = new HorariosBL();
          
            _censoMaestroBL = new CensoMaestroBL();

       

        }

        public ActionResult Index(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumnos(id);

            var censo = new CensoMaestro();
            censo.PeriodoId = 1;
            censo.AlumnoId = id;
            censo.Alumno = alumno;

            var asignaturas = _asignaturasBL.ObtenerAsignaturasActivos();
            var horarios = _horarioBL.ObtenerHorarios();

            foreach (var asignatura in asignaturas)
            {
                censo.ListadeCensoDetalle.Add(new CensoDetalle()
                {
                    AsignaturaId = asignatura.Id,
                    Asignatura = asignatura
                });
            }

            ViewBag.HorarioId = new SelectList(horarios, "Id", "Horario");

            return View(censo);
        }

        [HttpPost]
        public ActionResult Index (CensoMaestro censo)
        {
            _censoMaestroBL.nuevoCenso(censo);
                   

            return RedirectToAction("CensoExitoso");

        }

        public ActionResult CensoExitoso()
        {



            return View();
        }

    }
}