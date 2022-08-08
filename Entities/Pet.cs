using Entities.Enums;

namespace Entities
{
    public class Pet
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public double Peso { get; set; }
        public string Cor { get; set; }
        public TipoPet Tipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool EstaAtivo { get; set; }
    }
}