using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiEstudiantes.Models
{
    public class TipoUsuario
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public bool estado { get; set; }
    }
}
