using MySqlConnector;

public class Cinema
{
    // Conexão com o banco de dados
    private string conexao =
        "Server=127.0.0.1;" +
        "Database=Cinema;" +
        "User ID=root;" +
        "Password=SUA_SENHA;";

    // Atributos
    private int id;
    private double preçoIngresso;
    private int quantidadeIngressos;
    private string nomeFilme = "";
    private bool[,] poltronas = new bool[5, 5];
    private bool reservarAssento;

    // Construtor vazio
    public Cinema()
    {
    }

    // Construtor com parâmetros
    public Cinema(
        double PreçoIngresso,
        int QuantidadeIngressos,
        string NomeFilme,
        bool[,] Poltronas,
        bool ReservarAssento)
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
        get { return id; }
        set { id = value; }
    }

    // Propriedade PreçoIngresso
    public double PreçoIngresso
    {
        get { return preçoIngresso; }
        set
        {
            if (value < 22.50)
            {
                Console.WriteLine("Valor inválido.");
            }
            else
            {
                preçoIngresso = value;
            }
        }
    }

    // Propriedade QuantidadeIngressos
    public int QuantidadeIngressos
    {
        get { return quantidadeIngressos; }
        set
        {
            if (value < 0 || value > 10)
            {
                Console.WriteLine(
                    "Quantidade inválida ou ultrapassada do limite. Tente novamente."
                );
            }
            else
            {
                quantidadeIngressos = value;
            }
        }
    }

    // Propriedade NomeFilme
    public string NomeFilme
    {
        get { return nomeFilme; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Nome inválido.");
            }
            else
            {
                nomeFilme = value;
            }
        }
    }

    // Propriedade Poltronas
    public bool[,] Poltronas
    {
        get { return poltronas; }
        set { poltronas = value; }
    }

    // Reservar assento
    public bool ReservarAssento(int linha, int coluna)
    {
        if (linha < 0 || linha >= 5 ||
            coluna < 0 || coluna >= 5)
        {
            return false;
        }

        if (poltronas[linha, coluna])
        {
            return false;
        }

        poltronas[linha, coluna] = true;

        return true;
    }

    // Transformar as poltronas em texto
    private string PoltronasParaTexto()
    {
        string texto = "";

        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (poltronas[linha, coluna])
                {
                    texto += "1";
                }
                else
                {
                    texto += "0";
                }
            }
        }

        return texto;
    }

    // Transformar texto em matriz de poltronas
    private void TextoParaPoltronas(string texto)
    {
        poltronas = new bool[5, 5];

        int posicao = 0;

        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (posicao < texto.Length)
                {
                    poltronas[linha, coluna] =
                        texto[posicao] == '1';

                    posicao++;
                }
            }
        }
    }

    // Cadastrar
    public void Cadastrar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "INSERT INTO cinemas " +
                "(precoIngresso, quantidadeIngressos, nomeFilme, poltronas, reservarAssento) " +
                "VALUES " +
                "(@precoIngresso, @quantidadeIngressos, @nomeFilme, @poltronas, @reservarAssento)";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@precoIngresso",
                    preçoIngresso
                );

                comando.Parameters.AddWithValue(
                    "@quantidadeIngressos",
                    quantidadeIngressos
                );

                comando.Parameters.AddWithValue(
                    "@nomeFilme",
                    nomeFilme
                );

                comando.Parameters.AddWithValue(
                    "@poltronas",
                    PoltronasParaTexto()
                );

                comando.Parameters.AddWithValue(
                    "@reservarAssento",
                    reservarAssento
                );

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine(
            "Cinema cadastrado com sucesso!"
        );
    }

    // Listar
    public static void Listar()
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "SELECT * FROM cinemas";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            using (MySqlDataReader leitor =
                comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Cinema cinema = new Cinema();

                    cinema.id =
                        leitor.GetInt32("id");

                    cinema.preçoIngresso =
                        leitor.GetDouble("precoIngresso");

                    cinema.quantidadeIngressos =
                        leitor.GetInt32("quantidadeIngressos");

                    cinema.nomeFilme =
                        leitor.GetString("nomeFilme");

                    cinema.TextoParaPoltronas(
                        leitor.GetString("poltronas")
                    );

                    cinema.reservarAssento =
                        leitor.GetBoolean("reservarAssento");

                    Console.WriteLine(cinema);
                }
            }
        }
    }

    // Buscar
    public static void Buscar(int id)
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "SELECT * FROM cinemas WHERE id = @id";

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
                        Cinema cinema =
                            new Cinema();

                        cinema.id =
                            leitor.GetInt32("id");

                        cinema.preçoIngresso =
                            leitor.GetDouble(
                                "precoIngresso"
                            );

                        cinema.quantidadeIngressos =
                            leitor.GetInt32(
                                "quantidadeIngressos"
                            );

                        cinema.nomeFilme =
                            leitor.GetString(
                                "nomeFilme"
                            );

                        cinema.TextoParaPoltronas(
                            leitor.GetString(
                                "poltronas"
                            )
                        );

                        cinema.reservarAssento =
                            leitor.GetBoolean(
                                "reservarAssento"
                            );

                        Console.WriteLine(cinema);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Cinema não encontrado."
                        );
                    }
                }
            }
        }
    }

    // Atualizar
    public void Atualizar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "UPDATE cinemas SET " +
                "precoIngresso = @precoIngresso, " +
                "quantidadeIngressos = @quantidadeIngressos, " +
                "nomeFilme = @nomeFilme, " +
                "poltronas = @poltronas, " +
                "reservarAssento = @reservarAssento " +
                "WHERE id = @id";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@id",
                    id
                );

                comando.Parameters.AddWithValue(
                    "@precoIngresso",
                    preçoIngresso
                );

                comando.Parameters.AddWithValue(
                    "@quantidadeIngressos",
                    quantidadeIngressos
                );

                comando.Parameters.AddWithValue(
                    "@nomeFilme",
                    nomeFilme
                );

                comando.Parameters.AddWithValue(
                    "@poltronas",
                    PoltronasParaTexto()
                );

                comando.Parameters.AddWithValue(
                    "@reservarAssento",
                    reservarAssento
                );

                int linhasAlteradas =
                    comando.ExecuteNonQuery();

                if (linhasAlteradas > 0)
                {
                    Console.WriteLine(
                        "Cinema atualizado com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Cinema não encontrado."
                    );
                }
            }
        }
    }

    // Excluir
    public static void Excluir(int id)
    {
        string conexao =
            "Server=127.0.0.1;" +
            "Database=Cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

            string sql =
                "DELETE FROM cinemas WHERE id = @id";

            using (MySqlCommand comando =
                new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue(
                    "@id",
                    id
                );

                int linhasExcluidas =
                    comando.ExecuteNonQuery();

                if (linhasExcluidas > 0)
                {
                    Console.WriteLine(
                        "Cinema excluído com sucesso!"
                    );
                }
                else
                {
                    Console.WriteLine(
                        "Cinema não encontrado."
                    );
                }
            }
        }
    }

    // ToString
    public override string ToString()
    {
        return
            $"{Id} - {NomeFilme} - " +
            $"R$ {PreçoIngresso:F2} - " +
            $"Ingressos: {QuantidadeIngressos}";
    }
}