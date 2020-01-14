using Proyectocf.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectocf.Model.DAL
{
   public class CargarDatosDB : System.Data.Entity.DropCreateDatabaseIfModelChanges<EstudianteContext>

    {
        protected override void Seed(EstudianteContext context)
        {
            var Estudiantes = new List<Estudiante>
            {
                new Estudiante{ EstudianteID=1,Nombres="Marino Jose",Apellidos="Cuevas Rojas",Fecha_Inscripcion=DateTime.Parse("09-01-2020")},
                new Estudiante{ EstudianteID=2,Nombres="Cleto Alberto",Apellidos="Marcelino Mendez",Fecha_Inscripcion=DateTime.Parse("08-02-2020")},
            };

            var Cursos = new List<Curso>
            {
                new Curso{ CursoID=1,Descripcion="6to A Informatica"},
                new Curso{ CursoID=2,Descripcion="6to A Contabilidad"},
            };

            var Inscripciones = new List<Inscripcione>
            {
                new Inscripcione{ InscripcioneID=1,CursoID=1,EstudianteID=1, Semestre="1-2020"},
                new Inscripcione{ InscripcioneID=1,CursoID=2,EstudianteID=2, Semestre="1-2020"},
            };
        }
    }
}
