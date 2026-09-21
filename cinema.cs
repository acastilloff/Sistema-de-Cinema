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
 
using MySqlConnector;
 
public class Filme
{
    private string conexao =
        "Server=127.0.0.1;" +
        "Port=3306;" +
        "Database=Cinema;" +
        "User ID=root;" +
        "Password=Senac2026;";
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    private int id;
    private string nomeFilme = "";
    private double precoIngresso;
    private int quantidadeIngressos;
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public Filme()
    {
        nomeFilme = "";
    }
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public Filme(
        string nomeFilme,
        double precoIngresso,
        int quantidadeIngressos)
    {
        NomeFilme = nomeFilme;
        PrecoIngresso = precoIngresso;
        QuantidadeIngressos = quantidadeIngressos;
    }
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public string NomeFilme
    {
        get { return nomeFilme; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Nome do filme inválido!");
                return;
            }
<<<<<<< HEAD
 
            nomeFilme = value;
        }
    }
 
=======

            nomeFilme = value;
        }
    }

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public double PrecoIngresso
    {
        get { return precoIngresso; }
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
<<<<<<< HEAD
 
            precoIngresso = value;
        }
    }
 
=======

            precoIngresso = value;
        }
    }

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public int QuantidadeIngressos
    {
        get { return quantidadeIngressos; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Quantidade inválida!");
                return;
            }
<<<<<<< HEAD
 
            quantidadeIngressos = value;
        }
    }
 
=======

            quantidadeIngressos = value;
        }
    }

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public void Cadastrar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
            string sql =
                "INSERT INTO filmes " +
                "(nomeFilme, precoIngresso, quantidadeIngressos) " +
                "VALUES " +
                "(@nome, @preco, @quantidade)";
<<<<<<< HEAD
 
=======

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@nome",
                    NomeFilme
<<<<<<< HEAD
=======
                );

                comando.Parameters.AddWithValue(
                    "@preco",
                    PrecoIngresso
>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
                );
 
                comando.Parameters.AddWithValue(
                    "@preco",
                    PrecoIngresso
                );
 
                comando.Parameters.AddWithValue(
                    "@quantidade",
                    QuantidadeIngressos
                );
<<<<<<< HEAD
 
                comando.ExecuteNonQuery();
            }
        }
 
        Console.WriteLine();
        Console.WriteLine("Filme cadastrado com sucesso!");
    }
 
=======

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Filme cadastrado com sucesso!");
    }

>>>>>>> 08f7b3f0bdcb489fb45cb5d197b59479839a639c
    public static void Listar()
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Port=3306;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=Senac2026;";
 
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();
 
            string sql =
                "SELECT * FROM filmes";
 
            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                using (MySqlDataReader leitor =
                    comando.ExecuteReader())
                {
                    bool encontrou = false;
 
                    while (leitor.Read())
                    {
                        encontrou = true;
 
                        Filme filme = new Filme();
 
                        filme.Id =
                            Convert.ToInt32(leitor["id"]);
 
                        filme.NomeFilme =
                            leitor["nomeFilme"].ToString() ?? "";
 
                        filme.PrecoIngresso =
                            Convert.ToDouble(
                                leitor["precoIngresso"]
                            );
 
                        filme.QuantidadeIngressos =
                            Convert.ToInt32(
                                leitor["quantidadeIngressos"]
                            );
 
                        Console.WriteLine(
                            filme.ToString()
                        );
                    }
 
                    if (!encontrou)
                    {
                        Console.WriteLine(
                            "Nenhum filme cadastrado."
                        );
                    }
                }
            }
        }
    }
 
    public static void Buscar(int id)
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Port=3306;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=Senac2026;";
 
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();
 
            string sql =
                "SELECT * FROM filmes WHERE id = @id";
 
            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@id",
                    id
                );
 
                using (MySqlDataReader leitor =
                    comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        Filme filme = new Filme();
 
                        filme.Id =
                            Convert.ToInt32(leitor["id"]);
 
                        filme.NomeFilme =
                            leitor["nomeFilme"].ToString() ?? "";
 
                        filme.PrecoIngresso =
                            Convert.ToDouble(
                                leitor["precoIngresso"]
                            );
 
                        filme.QuantidadeIngressos =
                            Convert.ToInt32(
                                leitor["quantidadeIngressos"]
                            );
 
                        Console.WriteLine();
                        Console.WriteLine("Filme encontrado!");
                        Console.WriteLine(filme);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Filme não encontrado!"
                        );
                    }
                }
            }
        }
    }
 
    public static void Atualizar(
        int id,
        string nome,
        double preco,
        int quantidade)
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Port=3306;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=Senac2026;";
 
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();
 
            string sql =
                "UPDATE filmes SET " +
                "nomeFilme = @nome, " +
                "precoIngresso = @preco, " +
                "quantidadeIngressos = @quantidade " +
                "WHERE id = @id";
 
            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@nome",
                    nome
                );
 
                comando.Parameters.AddWithValue(
                    "@preco",
                    preco
                );
 
                comando.Parameters.AddWithValue(
                    "@quantidade",
                    quantidade
                );
 
                comando.Parameters.AddWithValue(
                    "@id",
                    id
                );
 
                int resultado =
                    comando.ExecuteNonQuery();
 
                if (resultado > 0)
                {
                    Console.WriteLine(
                        "Filme atualizado com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Filme não encontrado!"
                    );
                }
            }
        }
    }
 
    public static void Excluir(int id)
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Port=3306;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=Senac2026;";
 
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();
 
            string sql =
                "DELETE FROM filmes WHERE id = @id";
 
            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@id",
                    id
                );
 
                int resultado =
                    comando.ExecuteNonQuery();
 
                if (resultado > 0)
                {
                    Console.WriteLine(
                        "Filme excluído com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Filme não encontrado!"
                    );
                }
            }
        }
    }
 
    public override string ToString()
    {
        return
            $"ID: {Id} | " +
            $"Filme: {NomeFilme} | " +
            $"Preço: R$ {PrecoIngresso:F2} | " +
            $"Ingressos: {QuantidadeIngressos}";
    }
}
 