using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : ControllerBase
    {
        private readonly ILojaRepository _lojaRepository;

        public LojaController(ILojaRepository lojaRepository)
        {
            _lojaRepository = lojaRepository;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Obtém uma loja pelo ID",
            Description = "Retorna uma loja específica com base no ID fornecido."
        )]
        [SwaggerResponse(200, "Loja encontrada", typeof(Loja))]
        [SwaggerResponse(404, "Loja não encontrada")]
        public IActionResult GetById(int id)
        {
            var loja = _lojaRepository.GetById(id);
            if (loja == null)
                return NotFound();

            return Ok(loja);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Cria uma nova loja",
            Description = "Adiciona uma nova loja ao banco de dados."
        )]
        [SwaggerResponse(201, "Loja criada com sucesso", typeof(Loja))]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Create([FromBody] Loja loja)
        {
            if (loja == null)
                return BadRequest();

            _lojaRepository.Add(loja);
            return CreatedAtAction(nameof(GetById), new { id = loja.LojaId }, loja);
        }

        [HttpGet("nota/{notaMinima}")]
        [SwaggerOperation(
            Summary = "Obtém lojas com nota mínima",
            Description = "Retorna as lojas que possuem uma nota mínima igual ou maior que a fornecida."
        )]
        [SwaggerResponse(200, "Lojas encontradas", typeof(IEnumerable<Loja>))]
        [SwaggerResponse(404, "Nenhuma loja encontrada com essa nota mínima")]
        public IActionResult GetByNotaMinima(int notaMinima)
        {
            var lojas = _lojaRepository.GetByNotaMinima(notaMinima);
            if (lojas == null || !lojas.Any())
                return NotFound();

            return Ok(lojas);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza uma loja existente",
            Description = "Atualiza as informações de uma loja com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Loja atualizada com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Update(int id, [FromBody] Loja loja)
        {
            if (id != loja.LojaId)
                return BadRequest();

            _lojaRepository.Update(loja);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remove uma loja",
            Description = "Remove uma loja do banco de dados com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Loja removida com sucesso")]
        [SwaggerResponse(404, "Loja não encontrada")]
        public IActionResult Delete(int id)
        {
            _lojaRepository.Delete(id);
            return NoContent();
        }
    }
}
