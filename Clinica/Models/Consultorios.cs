using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Consultorios
    {

        [Key]
        public int ConsultoriosId { get; set; }
        public string Numero { get; set; }
    }
}
