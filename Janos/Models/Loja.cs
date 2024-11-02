namespace Janos.Models
{
    public class Loja
    {
        public int LojaId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        public ICollection<Nota>? Notas { get; set; }
        public ICollection<Item>? Itens { get; set; }  
    }
}
