using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ApiEstudiantes.Models
{
    public class Estudiante
    {
        [Key]
        public int id { get; set; }

        public int personaId { get; set; }
        public Persona persona { get; set; }

        public int carreraId { get; set; }
        public Carrera carrera { get; set; }

        public string matricula { get; set; }
        public bool estado { get; set; }
    }
}
