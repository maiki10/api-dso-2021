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
    public class CarreraController : ControllerBase
    {
        private readonly AppDbContext context;
        public CarreraController(AppDbContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            try
            {
                return Ok(context.carrera.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetBId")]
        public ActionResult GetById(int id)
        {

            try
            {
                var carrera = context.carrera.FirstOrDefault(carrera => carrera.id == id);
                return Ok(carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Carrera carrera)
        {
            try
            {
                context.carrera.Add(carrera);
                context.SaveChanges();
                return CreatedAtRoute("GetBId", new { carrera.id }, carrera);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Carrera carrera)
        {
            try
            {
                if (carrera.id == id)
                {
                    context.Entry(carrera).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetBId", new { id = carrera.id }, carrera);
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
                var carrera = context.carrera.FirstOrDefault(p => p.id == id);
                if (carrera != null)
                {
                    context.carrera.Remove(carrera);
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
