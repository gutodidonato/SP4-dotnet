using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Janos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        #region Constructor
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        #endregion

        #region SendEmail
        /// <summary>
        /// Envia um email com base na solicitação fornecida.
        /// </summary>
        /// <param name="request">Informações do email (destinatário, assunto e mensagem).</param>
        /// <returns>Retorna uma mensagem de sucesso se o email for enviado corretamente.</returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.ToEmail) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Message))
            {
                return BadRequest("A solicitação de email é inválida.");
            }

            await _emailService.SendEmailAsync(request.ToEmail, request.Subject, request.Message);
            return Ok("Email enviado com sucesso.");
        }
        #endregion
    }
}
