using Microsoft.AspNetCore.Mvc;
using GSLumiNET.Application.Services;
using GSLumiNET.Domain.Entities;
using System.Collections.Generic;
using GSLumiNET.Domain.Interfaces;

namespace GSLumiNET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : ControllerBase
    {
        private readonly IRegistroService _registroService;

        public RegistroController(IRegistroService registroService)
        {
            _registroService = registroService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var registro = _registroService.ObterPorId(id);
            if (registro == null)
            {
                return NotFound($"Registro com ID {id} não encontrado.");
            }
            return Ok(registro);
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var registros = _registroService.ObterTodos();
            return Ok(registros);
        }

        [HttpPost]
        public IActionResult AdicionarRegistro([FromBody] RegistroEntity entity)
        {
            if (entity == null)
            {
                return BadRequest("Os dados do registro são inválidos.");
            }

            var novoRegistro = _registroService.AdicionarRegistro(entity);
            return CreatedAtAction(nameof(ObterPorId), new { id = novoRegistro.Id }, novoRegistro);
        }

        [HttpPut("{id}")]
        public IActionResult EditarRegistro(int id, [FromBody] RegistroEntity entity)
        {
            if (entity == null || entity.Id != id)
            {
                return BadRequest("Os dados do registro são inválidos ou o ID não corresponde.");
            }

            var registroAtualizado = _registroService.EditarRegistro(entity);
            if (registroAtualizado == null)
            {
                return NotFound($"Registro com ID {id} não encontrado.");
            }

            return Ok(registroAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverRegistro(int id)
        {
            var registroRemovido = _registroService.RemoverRegistro(id);
            if (registroRemovido == null)
            {
                return NotFound($"Registro com ID {id} não encontrado.");
            }

            return Ok($"Registro com ID {id} removido com sucesso.");
        }
    }
}
