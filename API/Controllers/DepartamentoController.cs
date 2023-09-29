using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        private readonly IUnitOfWork unitofwork;
        private object unitOfWork;

        //private readonly IMapper mapper;
        //, IMapper mapper
        public DepartamentoController(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
            //this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Departamento>>> Get()
        {
            var departamentos = await unitofwork.Departamentos.GetAllAsync();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var departamento = await unitofwork.Departamentos.GetByIdAsync(id);
            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(Departamento departamento)
        {
            this.unitofwork.Departamentos.Add(departamento);
            await unitofwork.SaveAsync();
            if (departamento == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = departamento.Id }, departamento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Departamento>> Put(int id, [FromBody] Departamento departamento)
        {
            if (departamento == null)
            {
                return NotFound();
            }
            unitofwork.Departamentos.Update(departamento);
            await unitofwork.SaveAsync();
            return departamento;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Departamento = await unitofwork.Departamentos.GetByIdAsync(id);
            if (Departamento == null)
            {
                return NotFound();
            }
            unitofwork.Departamentos.Remove(Departamento);
            await unitofwork.SaveAsync();
            return NoContent();
        }
    }
}