using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository _notaRepository;

        public NotaController(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtém uma nota pelo ID",
            Description = "Retorna uma nota específica com base no ID fornecido."
        )]
        [SwaggerResponse(200, "Nota encontrada", typeof(Nota))]
        [SwaggerResponse(404, "Nota não encontrada")]
        public IActionResult GetById(int id)
        {
            var nota = _notaRepository.GetById(id);
            if (nota == null)
                return NotFound();

            return Ok(nota);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Cria uma nova nota",
            Description = "Adiciona uma nova nota ao banco de dados."
        )]
        [SwaggerResponse(201, "Nota criada com sucesso", typeof(Nota))]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Create([FromBody] Nota nota)
        {
            if (nota == null)
                return BadRequest();

            _notaRepository.Add(nota);
            return CreatedAtAction(nameof(GetById), new { id = nota.NotaId }, nota);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza uma nota existente",
            Description = "Atualiza as informações de uma nota com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Nota atualizada com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Update(int id, [FromBody] Nota nota)
        {
            if (id != nota.NotaId)
                return BadRequest();

            _notaRepository.Update(nota);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remove uma nota",
            Description = "Remove uma nota do banco de dados com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Nota removida com sucesso")]
        [SwaggerResponse(404, "Nota não encontrada")]
        public IActionResult Delete(int id)
        {
            _notaRepository.Delete(id);
            return NoContent();
        }
    }
}
