namespace Janos.Models
{
    public class Item
    {
        public int ItemId {get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public bool? Patrocinado { get; set; }
    }
}
