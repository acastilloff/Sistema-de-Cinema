while (true)
{
  
    Console.WriteLine("        SISTEMA DE FILMES COLLUZ");
    

    Console.WriteLine("1 - Cadastrar filme");
    Console.WriteLine("2 - Listar filmes");
    Console.WriteLine("3 - Buscar filme");
    Console.WriteLine("4 - Atualizar filme");
    Console.WriteLine("5 - Excluir filme");
    Console.WriteLine("0 - Sair");

    Console.WriteLine();

    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine() ?? "";

    Console.WriteLine();

    if (opcao == "1")
    {
        Console.Write("Digite o nome do filme: ");

        string nome = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido!");
            Console.Write("Digite o nome do filme novamente: ");

            nome = Console.ReadLine() ?? "";
        }

        double preco;

        Console.Write("Digite o preço do ingresso: ");

        while (!double.TryParse(
            Console.ReadLine(),
            out preco) || preco <= 0)
        {
            Console.WriteLine("Preço inválido!");
            Console.Write("Digite o preço novamente: ");
        }

        int quantidade;

        Console.Write("Digite a quantidade de ingressos: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out quantidade) || quantidade < 0)
        {
            Console.WriteLine("Quantidade inválida!");
            Console.Write("Digite a quantidade novamente: ");
        }

        Filme filme = new Filme(
            nome,
            preco,
            quantidade
        );

        filme.Cadastrar();
    }
    else if (opcao == "2")
    {
        Console.WriteLine("===== FILMES CADASTRADOS =====");
        Console.WriteLine();

        Filme.Listar();
    }
    else if (opcao == "3")
    {
        int id;

        Console.Write("Digite o ID do filme: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out id) || id <= 0)
        {
            Console.WriteLine("ID inválido!");
            Console.Write("Digite o ID novamente: ");
        }

        Filme.Buscar(id);
    }
    else if (opcao == "4")
    {
        int id;

        Console.Write("Digite o ID do filme: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out id) || id <= 0)
        {
            Console.WriteLine("ID inválido!");
            Console.Write("Digite o ID novamente: ");
        }

        Console.Write("Digite o novo nome do filme: ");

        string nome = Console.ReadLine() ?? "";

        while (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome inválido!");
            Console.Write(
                "Digite o nome do filme novamente: "
            );

            nome = Console.ReadLine() ?? "";
        }

        double preco;

        Console.Write("Digite o novo preço: ");

        while (!double.TryParse(
            Console.ReadLine(),
            out preco) || preco <= 0)
        {
            Console.WriteLine("Preço inválido!");
            Console.Write("Digite o preço novamente: ");
        }

        int quantidade;

        Console.Write("Digite a nova quantidade de ingressos: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out quantidade) || quantidade < 0)
        {
            Console.WriteLine("Quantidade inválida!");
            Console.Write(
                "Digite a quantidade novamente: "
            );
        }

        Filme.Atualizar(
            id,
            nome,
            preco,
            quantidade
        );
    }
    else if (opcao == "5")
    {
        int id;

        Console.Write("Digite o ID do filme: ");

        while (!int.TryParse(
            Console.ReadLine(),
            out id) || id <= 0)
        {
            Console.WriteLine("ID inválido!");
            Console.Write("Digite o ID novamente: ");
        }

        Filme.Excluir(id);
    }
    else if (opcao == "0")
    {
        Console.WriteLine("Programa encerrado.");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida!");
        Console.WriteLine(
            "Digite uma opção entre 0 e 5."
        );
    }
}