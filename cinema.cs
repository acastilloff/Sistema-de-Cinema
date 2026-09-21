using MySqlConnector;

public class Filme
{
    private string conexao =
        "Server=127.0.0.1;" +
        "Port=3306;" +
        "Database=Cinema;" +
        "User ID=root;" +
        "Password=Senac2026;";

    private int id;
    private string nomeFilme = "";
    private double precoIngresso;
    private int quantidadeIngressos;

    public Filme()
    {
        nomeFilme = "";
    }

    public Filme(
        string nomeFilme,
        double precoIngresso,
        int quantidadeIngressos)
    {
        NomeFilme = nomeFilme;
        PrecoIngresso = precoIngresso;
        QuantidadeIngressos = quantidadeIngressos;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

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

            nomeFilme = value;
        }
    }

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

            precoIngresso = value;
        }
    }

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

            quantidadeIngressos = value;
        }
    }

    public void Cadastrar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "INSERT INTO filmes " +
                "(nomeFilme, precoIngresso, quantidadeIngressos) " +
                "VALUES " +
                "(@nome, @preco, @quantidade)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@nome",
                    NomeFilme
                );

                comando.Parameters.AddWithValue(
                    "@preco",
                    PrecoIngresso
                );

                comando.Parameters.AddWithValue(
                    "@quantidade",
                    QuantidadeIngressos
                );

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine();
        Console.WriteLine("Filme cadastrado com sucesso!");
    }

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