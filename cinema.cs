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

    // Construtor
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

    // ID
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    // Preço do ingresso
    public double PreçoIngresso
    {
        get { return preçoIngresso; }
        set
        {
            if (value < 22.50)
            {
                Console.WriteLine(
                    "O preço do ingresso deve ser no mínimo R$ 22,50."
                );
            }
            else
            {
                preçoIngresso = value;
            }
        }
    }

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
    public string NomeFilme
    {
        get { return nomeFilme; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine(
                    "O nome do filme não pode estar vazio."
                );
            }
            else
            {
                nomeFilme = value;
            }
        }
    }

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

        return true;
    }

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
                "(@preco, @quantidade, @filme, @poltronas, @reservar)";

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
    }
}