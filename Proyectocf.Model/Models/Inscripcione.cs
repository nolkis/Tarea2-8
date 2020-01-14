using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectocf.Model.Models
{
   public class Inscripcione
    {
        public int InscripcioneID { get; set; }
        public int CursoID { get; set; }
        public int EstudianteID { get; set; }
        public string Semestre { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
