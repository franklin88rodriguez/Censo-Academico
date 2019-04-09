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
        AlumnoBL _alumnosBL;
        AsignaturasBL _asignaturasBL;
        HorariosBL _horarioBL;

        public CensoController()
        {
            _alumnosBL = new AlumnoBL();
            _asignaturasBL = new AsignaturasBL();
            _horarioBL = new HorariosBL();
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
        public ActionResult Index(CensoMaestro censo)
        {
            // Para guardar el censo debe recorrer la ListadeCensoDetalle y validar solo el horarioId > 0
            // tambien debe borrar todo el censo detalle de un alumno antes de agregarlos de nuevo
            // para borrar todo use 
            //foreach (var detalle in censo.ListadeCensoDetalle)
            //{
            //    if (detalle.HorarioId > 0)
            //    {
            //          _Contexto.CensosDetalles.Remove(censoDetalleExistente);
            //        ...
            //        var asignaturaId = detalle.AsignaturaId;
            //        var horarioId = detalle.HorarioId;
            //        ...
            //        _Contexto.CensosDetalles.Add(nuevoCenso);
            //    }
            //}

            return RedirectToAction("CensoExitoso");
        }

        public ActionResult CensoExitoso()
        {
            return View();
        }

    }
}