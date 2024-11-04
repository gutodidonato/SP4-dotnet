using System.Net.Http;
using System.Threading.Tasks;

namespace Janos.Services
{
    public interface IValidadorCepService
    {
        Task<bool> ValidarCep(string cep);
    }

    public class ValidadorCepService : IValidadorCepService
    {
        private readonly HttpClient _httpClient;

        public ValidadorCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidarCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            return response.IsSuccessStatusCode;
        }
    }
}
