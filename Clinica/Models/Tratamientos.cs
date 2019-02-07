using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Models
{
    public class Tratamientos
    {
        [Key]
        public int TratamientoId { get; set; }
        public string Nombre { get; set; }
        public string Costo { get; set; }

    }
}
