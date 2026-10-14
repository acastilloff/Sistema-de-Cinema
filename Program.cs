
using System;
using System.Globalization;

class Program
{
    static bool TryParsePreco(string? texto, out double preco)
    {
        preco = 0;

        if (string.IsNullOrWhiteSpace(texto))
        {
            return false;
        }

        // Aceita valores como 25,99 e 25.99.
        if (texto.Contains(','))
        {
            return double.TryParse(
                texto,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out preco);
        }

        return double.TryParse(
            texto,
            NumberStyles.Number,
            CultureInfo.InvariantCulture,
            out preco);
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("        GASTHER COLLUZ");
            Console.WriteLine("        SISTEMA DE FILMES");
            Console.WriteLine("==============================");
            Console.WriteLine();

            Console.WriteLine("1 - Cadastrar filme");
            Console.WriteLine("2 - Listar filmes");
            Console.WriteLine("3 - Buscar filme");
            Console.WriteLine("4 - Atualizar filme");
            Console.WriteLine("5 - Excluir filme");
            Console.WriteLine("6 - Sair");

            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                {
                    Filme filme = new Filme();

                    Console.Write("Nome do filme: ");
                    filme.NomeFilme = Console.ReadLine() ?? "";

                    Console.Write("Preço do ingresso (ex.: 25,99): ");

                    if (!TryParsePreco(Console.ReadLine(), out double preco))
                    {
                        Console.WriteLine("Preço inválido!");
                        break;
                    }

                    filme.PrecoIngresso = preco;

                    Console.Write("Quantidade de ingressos: ");

                    if (!int.TryParse(
                        Console.ReadLine(),
                        out int quantidade))
                    {
                        Console.WriteLine("Quantidade inválida!");
                        break;
                    }

                    filme.QuantidadeIngressos = quantidade;
                    filme.Cadastrar();

                    break;
                }

                case "2":
                {
                    Filme.Listar();
                    break;
                }

                case "3":
                {
                    Console.Write("Digite o ID do filme: ");

                    if (int.TryParse(
                        Console.ReadLine(),
                        out int idBusca))
                    {
                        Filme.Buscar(idBusca);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido!");
                    }

                    break;
                }

                case "4":
                {
                    Console.Write("Digite o ID do filme que deseja atualizar: ");

                    if (!int.TryParse(
                        Console.ReadLine(),
                        out int idAtualizar))
                    {
                        Console.WriteLine("ID inválido!");
                        break;
                    }

                    Console.Write("Novo nome do filme: ");
                    string nome = Console.ReadLine() ?? "";

                    Console.Write("Novo preço do ingresso (ex.: 25,99): ");

                    if (!TryParsePreco(
                        Console.ReadLine(),
                        out double novoPreco))
                    {
                        Console.WriteLine("Preço inválido!");
                        break;
                    }

                    Console.Write("Nova quantidade de ingressos: ");

                    if (!int.TryParse(
                        Console.ReadLine(),
                        out int novaQuantidade))
                    {
                        Console.WriteLine("Quantidade inválida!");
                        break;
                    }

                    Filme.Atualizar(
                        idAtualizar,
                        nome,
                        novoPreco,
                        novaQuantidade);

                    break;
                }

                case "5":
                {
                    Console.Write("Digite o ID do filme que deseja excluir: ");

                    if (int.TryParse(
                        Console.ReadLine(),
                        out int idExcluir))
                    {
                        Filme.Excluir(idExcluir);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido!");
                    }

                    break;
                }

                case "6":
                {
                    Console.WriteLine("Saindo do sistema...");
                    return;
                }

                default:
                {
                    Console.WriteLine("Opção inválida!");
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
