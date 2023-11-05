using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PersonaCLS
    {

        public int idPersona { get; set; }
        public string nombreCompleto { get; set; }
        public string correo { get; set; }
        public string fechaNacimientoStr { get; set; }

        public string nombre { get; set; }
        public  string apeMaterno { get; set; }
        public string apePaterno { get; set; }
        
        public DateTime  fechaNacimiento { get; set; }

        
    }
}
