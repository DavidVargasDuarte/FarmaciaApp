using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class PaisController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;


        public PaisController(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Pais>>> Get()
        {
            var paises = await unitofwork.Paises.GetAllAsync();
            return Ok(paises);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pais>> Post(Pais pais)
        {
            this.unitofwork.Paises.Add(pais);
            await unitofwork.SaveAsync();
            if (pais == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = pais.Id }, pais);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pais>> Put(int id, [FromBody] Pais pais)
        {
            if (pais == null)
            {
                return NotFound();
            }
            unitofwork.Paises.Update(pais);
            await unitofwork.SaveAsync();
            return pais;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var  pais = await unitofwork.Paises.GetByIdAsync(id);
            if ( pais == null)
            {
                return NotFound();
            }
            unitofwork.Paises.Remove(pais);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
}