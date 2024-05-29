﻿using SGED.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SGED.Objects.DTO.Entities;

namespace SGED.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : Controller
    {

        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetAll()
        {
            var estadosDTO = await _estadoService.GetAll();
            return Ok(estadosDTO);
        }

        [HttpGet("Id/{id}", Name = "GetEstado")]
        public async Task<ActionResult<EstadoDTO>> GetId(int id)
        {
            var estadoDTO = await _estadoService.GetById(id);
            if (estadoDTO == null) return NotFound("Estado não encontrado!");
            return Ok(estadoDTO);
        }

        [HttpGet("Name/{nome}", Name = "GetByName")]
        public async Task<ActionResult<IEnumerable<EstadoDTO>>> GetName(string nome)
        {
            var estadosDTO = await _estadoService.GetByName(nome);
            if (estadosDTO == null) return NotFound("Estados não econtrados!");
            return Ok(estadosDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EstadoDTO estadoDTO)
        {
            if (estadoDTO is null) return BadRequest("Dado inválido!");
            await _estadoService.Create(estadoDTO);
            return new CreatedAtRouteResult("GetById", new { id = estadoDTO.Id }, estadoDTO);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] EstadoDTO estadoDTO)
        {
            if (estadoDTO is null) return BadRequest("Dado inválido!");
            await _estadoService.Update(estadoDTO);
            return Ok(estadoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadoDTO>> Delete(int id)
        {
            var estadoDTO = await _estadoService.GetById(id);
            if (estadoDTO == null) return NotFound("Estado não encontrado!");
            await _estadoService.Remove(id);
            return Ok(estadoDTO);
        }
    }
}