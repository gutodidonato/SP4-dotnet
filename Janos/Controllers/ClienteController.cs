using Janos.Models;
using Janos.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

            [HttpGet("{id}")]
            [SwaggerOperation(
                Summary = "Obtém um cliente pelo ID",
                Description = "Retorna um cliente específico com base no ID fornecido. Se o cliente não for encontrado, retorna um erro 404.",
                OperationId = "GetById" 
            )]
            public IActionResult GetById(int id)
            {
                var cliente = _clienteRepository.GetById(id);
                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }

            [HttpPost]
            [SwaggerOperation(
                Summary = "Cria um novo cliente",
                Description = "Adiciona um novo cliente ao banco de dados."
            )]
            [SwaggerResponse(201, "Cliente criado com sucesso", typeof(Cliente))]
            [SwaggerResponse(400, "Requisição inválida")]
            public IActionResult Create(Cliente cliente)
            {
                if (cliente == null)
                {
                    return BadRequest();
                }

                _clienteRepository.Add(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
            }
        

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualiza um cliente existente",
            Description = "Atualiza as informações de um cliente com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Cliente atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return BadRequest();

            _clienteRepository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Remove um cliente",
            Description = "Remove um cliente do banco de dados com base no ID fornecido."
        )]
        [SwaggerResponse(204, "Cliente removido com sucesso")]
        [SwaggerResponse(404, "Cliente não encontrado")]
        public IActionResult Delete(int id)
        {
            _clienteRepository.Delete(id);
            return NoContent();
        }
    }
}
