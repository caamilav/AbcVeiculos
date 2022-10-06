using System;
using System.Collections.Generic;

namespace AbcVeiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Camila Valdrigues Candido
            var veiculos = new List<Veiculo>();
            var revendas = new List<Revenda>();
            var clientes = new List<Cliente>();
            bool continuar = true;

            do
            {

                ExibeMensagem("ABC Veículos", ConsoleColor.Blue);

                Console.WriteLine("1 - Cadastrar novo veículo\n2 - Visualizar veículos cadastrados\n3 - Cadastrar nova revenda\n4 - Visualizar revendas realizadas\n5 - Cadastrar novo cliente\n6 - Visualizar clientes cadastrados\n0 - Sair");
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0":
                        continuar = false;
                        break;

                    case "1":
                        ExibeMensagem("Cadastro de Veículos", ConsoleColor.Blue);

                        Console.Write("Modelo: ");
                        var modelo = Console.ReadLine();
                        Console.Write("Marca: ");
                        var marca = Console.ReadLine();
                        Console.Write("Ano: ");
                        var ano = Console.ReadLine();
                        Console.Write("Cor: ");
                        var cor = Console.ReadLine();

                        var veiculo = new Veiculo(modelo, marca, ano, cor);

                        veiculos.Add(veiculo);

                        ExibeMensagem("Veículo cadastrado com sucesso!", ConsoleColor.Green);
                        break;
                    case "2":
                        ExibeMensagem("Veículos cadastrados", ConsoleColor.Blue);

                        if (veiculos.Count == 0)
                            ExibeMensagem("Nenhum veículo cadastrado", ConsoleColor.DarkYellow);
                        else
                            ListarVeiculosCadastrados(veiculos);

                        break;
                    case "3":
                        ExibeMensagem("Cadastrado de revenda", ConsoleColor.Blue);
                        if (veiculos.Count == 0 || clientes.Count == 0)
                            ExibeMensagem("Para cadastrar uma revenda é necessário ter veículos e clientes cadastrados", ConsoleColor.Red);
                        else
                        {
                            Console.Write("Informe o índice do cliente: ");
                            var indiceCliente = int.Parse(Console.ReadLine());
                            if (indiceCliente > clientes.Count)
                                ExibeMensagem("Índice inválido. Verifique a lista de clientes cadastrados e tente novamente!", ConsoleColor.Red);
                            else
                            {

                                Console.Write("Informe o índice do veículo: ");
                                var indiceVeiculo = int.Parse(Console.ReadLine());

                                if (indiceVeiculo > veiculos.Count)
                                    ExibeMensagem("Índice inválido. Verifique a lista de veículos cadastrados e tente novamente!", ConsoleColor.Red);
                                else if (veiculos[indiceVeiculo].Disponivel == false)
                                {
                                    ExibeMensagem("O veículo não está disponível para revenda. Verifique a lista de veículos cadastrados e tente novamente!", ConsoleColor.Red);
                                }
                                else
                                {
                                    var revenda = new Revenda();
                                    revenda.Veiculo = veiculos[indiceVeiculo];
                                    revenda.Cliente = clientes[indiceCliente];
                                    revenda.Data = DateTime.Now;

                                    revendas.Add(revenda);

                                    veiculos[indiceVeiculo].Disponivel = false;

                                    clientes[indiceCliente].AdicionarVeiculo(veiculos[indiceVeiculo]);

                                    ExibeMensagem("Revenda cadastrada com sucesso!", ConsoleColor.Green);
                                }
                            }
                        }
                        break;
                    case "4":
                        ExibeMensagem("Revendas cadastradas", ConsoleColor.Blue);
                        if (revendas.Count == 0)
                            ExibeMensagem("Nenhuma revenda cadastrada", ConsoleColor.DarkYellow);
                        else
                            ListarRevendasCadastradas(revendas);
                        break;
                    case "5":
                        ExibeMensagem("Cadastro de Cliente", ConsoleColor.Blue);

                        Console.Write("Nome: ");
                        var nomeCliente = Console.ReadLine();

                        Console.WriteLine("0 - Pessoa Física 1 - Pessoa Jurídica:");
                        Console.Write("Tipo de pessoa: ");
                        var tipoPessoa = int.Parse(Console.ReadLine());

                        if (tipoPessoa != 0 && tipoPessoa != 1)
                        {
                            ExibeMensagem("Inválido. Por favor, informe apenas 0 ou 1. Tente novamente!", ConsoleColor.Red);
                            break;
                        }

                        var cliente = new Cliente(nomeCliente, (TipoPessoaEnum)tipoPessoa);

                        clientes.Add(cliente);

                        ExibeMensagem("Cliente cadastrado com sucesso!", ConsoleColor.Green);
                        break;
                    case "6":
                        ExibeMensagem("Clientes cadastrados", ConsoleColor.Blue);

                        if (clientes.Count == 0)
                            ExibeMensagem("Nenhum cliente cadastrado", ConsoleColor.DarkYellow);
                        else
                            ListarClientesCadastrados(clientes);

                        break;

                }
            } while (continuar);



        }

        private static void ListarClientesCadastrados(List<Cliente> clientes)
        {
            foreach (var item in clientes)
            {
                string tipoPessoa = item.TipoPessoa == 0 ? "Pessoa física" : "Pessoa jurídica";
                Console.WriteLine($"#{clientes.IndexOf(item)}   Nome: {item.Nome}    TipoPessoa: {tipoPessoa}");
            }
        }

        private static void ListarVeiculosCadastrados(List<Veiculo> veiculos)
        {
            foreach (var item in veiculos)
            {
                Console.WriteLine($"#{veiculos.IndexOf(item)}   Modelo: {item.Modelo}    Marca: {item.Marca}    Cor:{item.Cor}    Ano: {item.Ano}     Disponível: {item.Disponivel}\n");
            }
        }
        private static void ListarRevendasCadastradas(List<Revenda> revendas)
        {
            foreach (var item in revendas)
            {
                string tipoPessoa = item.Cliente.TipoPessoa == 0 ? "Pessoa física" : "Pessoa jurídica";

                Console.WriteLine($"Revenda #{revendas.IndexOf(item)}");
                Console.WriteLine($"Data: {item.Data}");
                Console.WriteLine("Dados do Veículo:");
                Console.WriteLine($"\tModelo: {item.Veiculo.Modelo}\n\tMarca: {item.Veiculo.Marca}\n\tAno: {item.Veiculo.Ano}\n\tCor: {item.Veiculo.Cor}");
                Console.WriteLine("Dados do Cliente:");
                Console.WriteLine($"\tTipo: {tipoPessoa}\n\tNome: {item.Cliente.Nome}\n");

            }
        }
        private static void ExibeMensagem(string msg, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine($"\n{msg}");
            Console.ResetColor();
        }


    }
}
