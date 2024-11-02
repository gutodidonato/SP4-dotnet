namespace Janos.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<Nota>? Notas { get; set; }
    }
}
