using System.Collections.Generic;

namespace AbcVeiculos
{
    public class Cliente
    {
        public string Nome { get; set; }

        public TipoPessoaEnum TipoPessoa { get; set; }

        public List<Veiculo> Veiculos = new List<Veiculo>();
        public Cliente(string nome, TipoPessoaEnum tipoPessoa)
        {
            this.Nome = nome;
            this.TipoPessoa = tipoPessoa;
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            this.Veiculos.Add(veiculo);
        }
    }
}
