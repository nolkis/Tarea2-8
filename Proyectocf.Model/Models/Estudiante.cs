using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyectocf.Model.Models
{
   public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }
        public virtual ICollection<Inscripcione> Inscripciones { get; set; }
    }
}
