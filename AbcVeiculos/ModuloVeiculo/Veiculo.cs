namespace AbcVeiculos
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Ano { get; set; }       
        public string Cor { get; set; }
        public bool Disponivel { get; set; }

        public Veiculo(string modelo, string marca, string ano, string cor)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.Ano = ano;
            this.Cor = cor;
            this.Disponivel = true;
        }

    }
}
