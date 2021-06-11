using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiEstudiantes.Models;

namespace ApiEstudiantes.Context
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
            {

            }
            public DbSet<Persona> persona { get; set; }
            public DbSet<Estudiante> estudiante { get; set; }
            public DbSet<Carrera> carrera { get; set; }


        }
    
}
