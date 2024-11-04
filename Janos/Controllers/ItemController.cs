using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        #region Leitura (GET)

        [HttpGet("{nome}")]
        [SwaggerOperation(Summary = "Obtém um item pelo nome", Description = "Retorna um item específico com base no nome fornecido.")]
        [SwaggerResponse(200, "Item encontrado", typeof(Item))]
        [SwaggerResponse(404, "Item não encontrado")]
        public IActionResult GetById(string nome)
        {
            var item = _itemRepository.GetById(nome);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        #endregion

        #region Manipulação (POST, PUT, DELETE)

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo item", Description = "Adiciona um novo item ao banco de dados.")]
        [SwaggerResponse(201, "Item criado com sucesso", typeof(Item))]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Create([FromBody] Item item)
        {
            if (item == null)
                return BadRequest();

            _itemRepository.Add(item);
            return CreatedAtAction(nameof(GetById), new { nome = item.Nome }, item);
        }

        [HttpPut("{nome}")]
        [SwaggerOperation(Summary = "Atualiza um item existente", Description = "Atualiza as informações de um item com base no nome fornecido.")]
        [SwaggerResponse(204, "Item atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Update(string nome, [FromBody] Item item)
        {
            if (item == null || nome != item.Nome)
                return BadRequest();

            _itemRepository.Update(item);
            return NoContent();
        }

        [HttpDelete("{nome}")]
        [SwaggerOperation(Summary = "Remove um item", Description = "Remove um item do banco de dados com base no nome fornecido.")]
        [SwaggerResponse(204, "Item removido com sucesso")]
        [SwaggerResponse(404, "Item não encontrado")]
        public IActionResult Delete(string nome)
        {
            var itemExists = _itemRepository.GetById(nome);
            if (itemExists == null)
                return NotFound();

            _itemRepository.Delete(nome);
            return NoContent();
        }

        #endregion
    }
}