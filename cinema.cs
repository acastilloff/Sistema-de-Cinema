using MySqlConnector;

public class Cinema
{
    private string conexao = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

    private int id;
    private double preçoIngresso;
    private string nomeFilme;
    private bool[,] poltronasMatriz = new bool[5, 5];
    private int quantidadePoltronasOcupadas;

    // Construtor vazio
    public Cinema()
    {
    }

    // Construtor com parâmetros
    public Cinema(double preçoIngresso, string nomeFilme)
    {
        preçoIngresso = PreçoIngresso;
        quantidadeIngressos = QuantidadeIngressos;
        nomeFilme = NomeFilme;
        poltronas = Poltronas;
        reservarAssento = ReservarAssento;
    }

    // Propriedade ID
    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    // Propriedade Preço do Ingresso
    public double PreçoIngresso
    {
        get
        {
            return preçoIngresso;
        }
        set
        {
            if (value < 22.50)
            {
                Console.WriteLine("Valor inválido. O ingresso deve custar pelo menos R$ 22,50.");
            }
            else
            {
                preçoIngresso = value;
            }
        }
    }

    // Propriedade Nome do Filme
    public string NomeFilme
    {
        get
        {
            return nomeFilme;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Nome do filme inválido.");
            }
            else
            {
                nomeFilme = value;
            }
        }
    }

    // Propriedade Quantidade de Poltronas Ocupadas
    public int QuantidadePoltronasOcupadas
    {
        get
        {
            return quantidadePoltronasOcupadas;
        }
        set
        {
            quantidadePoltronasOcupadas = value;
        }
    }

    // Reservar assento
    public bool ReservarAssento(int linha, int coluna)
    {
        // Verifica se a linha e a coluna são válidas
        if (linha < 0 || linha >= 5 || coluna < 0 || coluna >= 5)
        {
            Console.WriteLine("Assento inválido.");
            return false;
        }

        // Verifica se o assento já está ocupado
        if (poltronasMatriz[linha, coluna])
        {
            Console.WriteLine("Esse assento já está ocupado.");
            return false;
        }

        // Reserva o assento
        poltronasMatriz[linha, coluna] = true;

        // Aumenta a quantidade de assentos ocupados
        quantidadePoltronasOcupadas++;

        Console.WriteLine("Assento reservado com sucesso!");

        return true;
    }

    // Cadastrar cinema
    public void Cadastrar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql = "INSERT INTO cinemas (ingresso, nomeFilme, poltronas) " +
                         "VALUES (@ingresso, @nomeFilme, @poltronas)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@preco",
                    preçoIngresso
                );

                comando.Parameters.AddWithValue(
                    "@quantidade",
                    quantidadeIngressos
                );

                comando.Parameters.AddWithValue(
                    "@filme",
                    nomeFilme
                );

                comando.Parameters.AddWithValue(
                    "@poltronas",
                    PoltronasParaTexto()
                );

                comando.Parameters.AddWithValue(
                    "@reservar",
                    reservarAssento
                );

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Cinema cadastrado com sucesso!");
    }

    // Listar cinemas
    public static void Listar()
    {
        string conexaoLocal =
            "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

        using (MySqlConnection banco = new MySqlConnection(conexaoLocal))
        {
            banco.Open();

            string sql = "SELECT * FROM cinemas";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            using (MySqlDataReader leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Cinema cinema = new Cinema();

                    cinema.Id = leitor.GetInt32("id");
                    cinema.PreçoIngresso = leitor.GetDouble("ingresso");
                    cinema.NomeFilme = leitor.GetString("nomeFilme");
                    cinema.QuantidadePoltronasOcupadas =
                        leitor.GetInt32("poltronas");

                    Console.WriteLine(cinema);
                }
            }
        }
    }

    // Buscar cinema pelo ID
    public static void Buscar(int id)
    {
        string conexaoLocal =
            "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

        using (MySqlConnection banco = new MySqlConnection(conexaoLocal))
        {
            banco.Open();

            string sql = "SELECT * FROM cinemas WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        Cinema cinema = new Cinema();

                        cinema.Id = leitor.GetInt32("id");
                        cinema.PreçoIngresso = leitor.GetDouble("ingresso");
                        cinema.NomeFilme = leitor.GetString("nomeFilme");
                        cinema.QuantidadePoltronasOcupadas =
                            leitor.GetInt32("poltronas");

                        Console.WriteLine(cinema);
                    }
                    else
                    {
                        Console.WriteLine("Cinema não encontrado.");
                    }
                }
            }
        }
    }

    // Atualizar cinema
    public void Atualizar()
    {
        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "UPDATE cinemas SET " +
                "ingresso = @ingresso, " +
                "nomeFilme = @nomeFilme, " +
                "poltronas = @poltronas " +
                "WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", Id);
                comando.Parameters.AddWithValue("@ingresso", PreçoIngresso);
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue(
                    "@poltronas",
                    QuantidadePoltronasOcupadas
                );

                int linhasAlteradas = comando.ExecuteNonQuery();

                if (linhasAlteradas > 0)
                {
                    Console.WriteLine("Cinema atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cinema não encontrado.");
                }
            }
        }
    }

    // Excluir cinema
    public static void Excluir(int id)
    {
        string conexaoLocal =
            "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

        using (MySqlConnection banco = new MySqlConnection(conexaoLocal))
        {
            banco.Open();

            string sql = "DELETE FROM cinemas WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", id);

                int linhasExcluidas = comando.ExecuteNonQuery();

                if (linhasExcluidas > 0)
                {
                    Console.WriteLine("Cinema excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Cinema não encontrado.");
                }
            }
        }
    }

    // Exibir informações do cinema
    public override string ToString()
    {
        return $"ID: {Id} | " +
               $"Filme: {NomeFilme} | " +
               $"Preço: R$ {PreçoIngresso:F2} | " +
               $"Poltronas Ocupadas: {QuantidadePoltronasOcupadas}";
    }
}