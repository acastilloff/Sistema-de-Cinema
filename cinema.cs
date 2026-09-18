using System.Reflection.Metadata.Ecma335;
using MySqlConnector;

public class Cinema
{
  private string conexao = """
    Server=127.0.0.1;
    Database=Cinema;
    User ID=root;
    Password=Senac2026;
    """;
   
    private int Id;
    private double preçoIngresso;
    private int quantidadeIngressos;
    private string nomeFilme;
    private bool[,]poltronas = new bool[5,5];
    private bool reservarAssento;
    
    public Cinema(double PreçoIngresso, int QuantidadeIngressos, string NomeFilme, bool[,] Poltronas, bool ReservarAssento)
    {
        preçoIngresso = PreçoIngresso;
        quantidadeIngressos = QuantidadeIngressos;
        nomeFilme = NomeFilme;
        poltronas = Poltronas;
        reservarAssento = ReservarAssento;
    }

    public double PreçoIngresso
    {
        get{return preçoIngresso;}
        set
        {
            if(value < 22.50)
            {
                Console.WriteLine("Valor inválido.");
            }
            else
            {
                preçoIngresso = value;
            }
        }
    }

    public int QuantidadeIngressos
    {
        get{return quantidadeIngressos;}
        set
        {
            if(value<0 || value > 10)
            {
                Console.WriteLine("Quantidade inválida ou ultrapassada do limite. Tente Novamente.");
            }
            else
            {
                quantidadeIngressos = value;
            }
        }
    }

    public string NomeFilme
    {
        get{return nomeFilme;}
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Nome inválido.");
            }
            else
            {
                nomeFilme = value;
            }

        }
    }

    public bool[,]Poltronas
    {
        get{return poltronas;}
        set{poltronas = value;}
    }

    public bool ReservarAssento(int linha, int coluna)
    {
        if(poltronas[linha,coluna]) return false;
        poltronas[linha,coluna] = true;
        return true;
    }

    
    public void Cadastrar()
    {
        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

            string sql = "INSERT INTO cinemas (preçoingresso, quantidadeingressos, nomeFilme, poltronas) " +
                         "VALUES (@ingresso, @nomeFilme, @poltronas)";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@ingresso", PreçoIngresso);
                comando.Parameters.AddWithValue("@ingresso", QuantidadeIngressos);
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue("@poltronas", Poltronas);
                comando.Parameters.AddWithValue("@poltronas", ReservarAssento);

                comando.ExecuteNonQuery();
            }
        }

        Console.WriteLine("Cinema cadastrado com sucesso!");
    }

    
    public static void Listar()
    {
        string conexao =
            "Server=localhost;" +
            "Database=cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

            string sql = "SELECT * FROM cinemas";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            using (MySqlDataReader leitor = comando.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Cinema cinema = new Cinema();

                    cinema.Id = leitor.GetInt32("ID");
                        cinema.PreçoIngresso = leitor.GetDouble("Preço do Ingresso");
                        cinema.QuantidadeIngressos = leitor.GetInt32("Número de Ingressos");
                        cinema.NomeFilme = leitor.GetString("Nome do Filme");
                        cinema.Poltronas = leitor.GetBoolean("Número das Poltronas da Sala");
                    Console.WriteLine(cinema);
                }
            }
        }
    }

    public static void Buscar(int id)
    {
        string conexao =
            "Server=localhost;" +
            "Database=cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco = new MySqlConnection(conexao))
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

                        cinema.Id = leitor.GetInt32("ID");
                        cinema.PreçoIngresso = leitor.GetDouble("Preço do Ingresso");
                        cinema.QuantidadeIngressos = leitor.GetInt32("Número de Ingressos");
                        cinema.NomeFilme = leitor.GetString("Nome do Filme");
                        cinema.Poltronas = leitor.GetBoolean("Número das Poltronas da Sala");

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

  
    public void Atualizar()
    {
        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

            string sql = "UPDATE cinemas SET ingresso = @ingresso, " +
                         "nomeFilme = @nomeFilme, poltronas = @poltronas " +
                         "WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", Id);
                comando.Parameters.AddWithValue("@preçoingresso", preçoIngresso);
                comando.Parameters.AddWithValue("@quantidadeingresso", quantidadeIngressos);
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue("@poltronas", Poltronas);

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

    
    public static void Excluir(int id)
    {
        string conexao =
            "Server=localhost;" +
            "Database=cinema;" +
            "User ID=root;" +
            "Password=SUA_SENHA;";

        using (MySqlConnection banco = new MySqlConnection(conexao))
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

    public override string ToString()
    {
        return $"{Id} || {NomeFilme} || R$: {PreçoIngresso} || Quantidade de Ingressos: {QuantidadeIngressos} || Poltronas Escolhidas: {Poltronas}";
    }
}