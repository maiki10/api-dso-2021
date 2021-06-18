﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEstudiantes.Context;
using ApiEstudiantes.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiEstudiantes.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly AppDbContext context;
        public EstudianteController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            try
            {
                return Ok(context.estudiante.Include(e => e.persona).Include(e=> e.carrera).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetByI")]
        public ActionResult GetById(int id)
        {

            try
            {
                var estudiante = context.estudiante.FirstOrDefault(estudiante => estudiante.id == id);
                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estudiante)
        {
            try
            {
                context.estudiante.Add(estudiante);
                context.SaveChanges();
                return CreatedAtRoute("GetByI", new { estudiante.id }, estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Estudiante estudiante)
        {
            try
            {
                if (estudiante.id == id)
                {
                    context.Entry(estudiante).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetByI", new { id = estudiante.id }, estudiante);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var estudiante = context.estudiante.FirstOrDefault(p => p.id == id);
                if (estudiante != null)
                {
                    context.estudiante.Remove(estudiante);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
