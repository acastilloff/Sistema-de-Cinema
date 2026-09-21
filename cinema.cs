using MySqlConnector;

public class Cinema
{
<<<<<<< HEAD
    private string conexao = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

    private int id;
    private double preçoIngresso;
    private string nomeFilme;
    private bool[,] poltronasMatriz = new bool[5, 5];
    private int quantidadePoltronasOcupadas;
=======
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
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa

    // Construtor vazio
    public Cinema()
    {
    }

<<<<<<< HEAD
    // Construtor com parâmetros
    public Cinema(double preçoIngresso, string nomeFilme)
=======
    // Construtor
    public Cinema(
        double PreçoIngresso,
        int QuantidadeIngressos,
        string NomeFilme,
        bool[,] Poltronas,
        bool ReservarAssento)
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
    {
        preçoIngresso = PreçoIngresso;
        quantidadeIngressos = QuantidadeIngressos;
        nomeFilme = NomeFilme;
        poltronas = Poltronas;
        reservarAssento = ReservarAssento;
    }

<<<<<<< HEAD
    // Propriedade ID
=======
    // ID
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
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

<<<<<<< HEAD
    // Propriedade Preço do Ingresso
=======
    // Preço do ingresso
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
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
<<<<<<< HEAD
                Console.WriteLine("Valor inválido. O ingresso deve custar pelo menos R$ 22,50.");
=======
                Console.WriteLine(
                    "O preço do ingresso deve ser no mínimo R$ 22,50."
                );
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
            }
            else
            {
                preçoIngresso = value;
            }
        }
    }

<<<<<<< HEAD
    // Propriedade Nome do Filme
=======
    // Quantidade de ingressos
    public int QuantidadeIngressos
    {
        get { return quantidadeIngressos; }
        set
        {
            if (value < 0 || value > 10)
            {
                Console.WriteLine(
                    "A quantidade deve estar entre 0 e 10."
                );
            }
            else
            {
                quantidadeIngressos = value;
            }
        }
    }

    // Nome do filme
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
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
<<<<<<< HEAD
                Console.WriteLine("Nome do filme inválido.");
=======
                Console.WriteLine(
                    "O nome do filme não pode estar vazio."
                );
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
            }
            else
            {
                nomeFilme = value;
            }
        }
    }

<<<<<<< HEAD
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
=======
    // Poltronas
    public bool[,] Poltronas
    {
        get { return poltronas; }
        set { poltronas = value; }
    }

    // Reservar assento
    public bool ReservarAssento(int numeroPoltrona)
    {
        // Verifica se o número existe
        if (numeroPoltrona < 1 || numeroPoltrona > 25)
        {
            Console.WriteLine(
                "Número de poltrona inválido! Escolha entre 1 e 25."
            );

            return false;
        }

        // Converte o número da poltrona para linha e coluna
        int numero = numeroPoltrona - 1;

        int linha = numero / 5;
        int coluna = numero % 5;

        // Verifica se já está ocupada
        if (poltronas[linha, coluna])
        {
            Console.WriteLine(
                "Esta poltrona já está ocupada!"
            );

            return false;
        }

        // Reserva a poltrona
        poltronas[linha, coluna] = true;

        reservarAssento = true;
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa

        return true;
    }

<<<<<<< HEAD
    // Cadastrar cinema
=======
    // Transforma as poltronas em texto
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

    // Cadastrar no banco
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
    public void Cadastrar()
    {
        using (MySqlConnection banco =
            new MySqlConnection(conexao))
        {
            banco.Open();

<<<<<<< HEAD
            string sql = "INSERT INTO cinemas (ingresso, nomeFilme, poltronas) " +
                         "VALUES (@ingresso, @nomeFilme, @poltronas)";
=======
            string sql =
                "INSERT INTO cinemas " +
                "(precoIngresso, quantidadeIngressos, nomeFilme, poltronas, reservarAssento) " +
                "VALUES " +
                "(@preco, @quantidade, @filme, @poltronas, @reservar)";
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa

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

<<<<<<< HEAD
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
=======
        Console.WriteLine(
            "Cinema cadastrado com sucesso!"
        );
    }

    // ToString
    public override string ToString()
    {
        return
            $"{Id} - {NomeFilme} - " +
            $"R$ {PreçoIngresso:F2} - " +
            $"Ingressos: {QuantidadeIngressos}";
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
    }
}