using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
   public class AlumnoBL//clase que contiene todas las acciones que va hacer la clase alumno
    {
        Contexto _contexto;

        public List<Alumno> ListadeAlumnos { get; set; }

        public AlumnoBL()
        {
            _contexto = new Contexto();
            ListadeAlumnos = new List<Alumno>();
        }

        public List<Alumno> ObtenerAlumnos()
        {
            ListadeAlumnos = _contexto.Alumnos
                .OrderBy(r => r.NombreAlumno)
                .ToList();
           
            return ListadeAlumnos;
        }

        public List<Alumno> ObtenerAlumnosActivos()
        {
            ListadeAlumnos = _contexto.Alumnos

                   .Where(r => r.Activo == true)
                 .OrderBy(r => r.NombreAlumno)
                .ToList();
            

            return ListadeAlumnos;
        }

        public void GuardarAlumno(Alumno alumno)
        {
            if (alumno.Id == 0)
            {
                _contexto.Alumnos.Add(alumno);
            }
            else
            {
                var alumnoExistente = _contexto.Alumnos.Find(alumno.Id);

                alumnoExistente.Id = alumno.Id;
               alumnoExistente.NombreAlumno = alumno.NombreAlumno;
                alumnoExistente.UrlImagen = alumno.UrlImagen;
                alumnoExistente.Activo = alumno.Activo;

            }

            _contexto.SaveChanges();
        }

        public Alumno ObtenerAlumnos(int Id)
        {
            var alumno = _contexto.Alumnos.Find(Id);

            return alumno;
        }

        public void EliminarAlumno(int Id)
        {
            var alumno = _contexto.Alumnos.Find(Id);

            _contexto.Alumnos.Remove(alumno);
            _contexto.SaveChanges();
        }
    }
}
