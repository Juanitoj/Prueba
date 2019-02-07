using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Locales
    {
        public int LocalesId { get; set; }
        public string Nombre { get; set; }
        public string Direcion { get; set; }
        public string Calle { get; set; }
        public int ConsultoriosId { get; set; }
        public Consultorios Consultorios { get; set; }



    }
}
