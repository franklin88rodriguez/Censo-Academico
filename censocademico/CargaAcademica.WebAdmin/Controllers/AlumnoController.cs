using CargaAcademica.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargaAcademica.WebAdmin.Controllers//paso 4 controlador para las acciones html
{
    public class AlumnoController : Controller
    {
        AlumnoBL _AlumnoBL;

        public AlumnoController()
        {
            _AlumnoBL = new AlumnoBL();
        }



        // GET: Alumno
        public ActionResult Index()
        {
            var ListadeAlumnos = _AlumnoBL.ObtenerAlumnos();

            return View(ListadeAlumnos);
        }

        public ActionResult Crear()
        {
            var nuevoAlumno = new Alumno();

            return View(nuevoAlumno);
        }

        [HttpPost]//validacion
        public ActionResult Crear(Alumno alumno, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)//validacion con estructura if que evalua si el model state es valio.
                                  //entonces permite guardar. 
            {
                 if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }

                _AlumnoBL.GuardarAlumno(alumno);


                return RedirectToAction("Index");//pendiente index
            }



            return View(alumno);
        }


        public ActionResult Editar(int Id)
        {
            var alumno = _AlumnoBL.ObtenerAlumnos(Id);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                /*if(alumno.Id != alumno.Id.Trim())
                {

                }*/

                if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }
                _AlumnoBL.GuardarAlumno(alumno);

                return RedirectToAction("Index");//pendiente index tambien
            }

            return View(alumno);
        }


        public ActionResult Detalle(int Id)
        {
            var alumno = _AlumnoBL.ObtenerAlumnos(Id);

            return View(alumno);
        }


        public ActionResult Eliminar(int Id)
        {
            var alumno = _AlumnoBL.ObtenerAlumnos(Id);

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Eliminar(Alumno alumno)
        {
            _AlumnoBL.EliminarAlumno(alumno.Id);

            return RedirectToAction("Index");//pendiente index
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);//para sacar ese simbolo uso alt + 126
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;

        }
    }
}