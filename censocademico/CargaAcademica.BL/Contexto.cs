using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargaAcademica.BL
{
    public class Contexto : DbContext
    {
        public Contexto() : base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" +
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Censodb.mdf")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }//paso 1

        public DbSet<Horarios> Horarios { get; set; }

        public DbSet<CensoMaestro> CensosMaestros { get; set; }// base de adato para mi clase maestro
     public DbSet<CensoDetalle> CensosDetalles { get; set; }// base para mi clase detalles




    }

}
