using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectocf.Model.Models
{
   public class Curso
    {
        public int CursoID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Inscripcione> Inscripciones { get; set; }
    }
}
