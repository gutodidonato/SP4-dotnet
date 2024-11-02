using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Janos.Models;


namespace Janos.Services
{
    public class CepService
    {
        public async Task<bool> CepExiste(string cep)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
                var endereco = JsonConvert.DeserializeObject<Endereco>(response);

                return !(endereco.Logradouro == null || endereco.Logradouro == "");
            }
        }
    }
}
