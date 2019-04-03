using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers
{
    public class HorarioController : Controller
    {
        HorariosBL _HorarioBL;

        public HorarioController()
        {
            _HorarioBL = new HorariosBL();
        }


        // GET: Horario
        public ActionResult Index()
        {
            var ListadeHorarios = _HorarioBL.ObtenerHorarios();

            return View(ListadeHorarios);
        }

        public ActionResult Crear()
        {
            var nuevoHorario = new Horarios();

            return View(nuevoHorario);
        }

        [HttpPost]//validacion
        public ActionResult Crear(Horarios horarios)
        {
            if (ModelState.IsValid)//validacion con estructura if que evalua si el model state es valio.
                                   //entonces permite guardar. 
            {
                

                _HorarioBL.GuardarHorario(horarios);


                return RedirectToAction("Index");
            }


            return View(horarios);
        }
        public ActionResult Editar(int Id)
        {
            var hora = _HorarioBL.ObtenerHorarios(Id);

            return View(hora);
        }

        [HttpPost]
        public ActionResult Editar(Horarios horarios)
        {
            if (ModelState.IsValid)
            {
               
                    
                _HorarioBL.GuardarHorario(horarios);

                return RedirectToAction("Index");//pendiente index tambien
            }

            return View(horarios);
        }


        public ActionResult Detalle(int Id)
        {
            var horarios = _HorarioBL.ObtenerHorarios(Id);

            return View(horarios);
        }

        [HttpPost]
        public ActionResult Eliminar(Horarios horarios)
        {
            _HorarioBL.EliminarHorario(horarios.Id);

            return RedirectToAction("Index");//pendiente index
        }


    }
}