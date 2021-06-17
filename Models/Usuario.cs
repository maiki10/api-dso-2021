using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApiEstudiantes.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public int personaId { get; set; }

        public int tipoUsuarioId { get; set;}

        public string correo { get; set; }

        public string password { get; set; }
        public bool estado { get; set; }
    }
}
