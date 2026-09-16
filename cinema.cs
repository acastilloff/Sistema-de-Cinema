using MySqlConnector;

public class Cinema
{
  private string conexao = """
    Server=127.0.0.1;
    Database=Cinema;
    User ID=root;
    Password=Senac2026;
    """;
   
    public int Id { get; set; }
    public double Ingresso { get; set; }
    public string NomeFilme { get; set; }
    public int Poltronas { get; set; }

       public Cinema()
    {
    }

    
    public Cinema(double ingresso, string nomeFilme, int poltronas)
    {
        Ingresso = ingresso;
        NomeFilme = nomeFilme;
        Poltronas = poltronas;
    }

    
    public void Cadastrar()
    {
        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

            string sql = "INSERT INTO cinemas (ingresso, nomeFilme, poltronas) " +
                         "VALUES (@ingresso, @nomeFilme, @poltronas)";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@ingresso", Ingresso);
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue("@poltronas", Poltronas);

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

                    cinema.Id = leitor.GetInt32("id");
                    cinema.Ingresso = leitor.GetDouble("ingresso");
                    cinema.NomeFilme = leitor.GetString("nomeFilme");
                    cinema.Poltronas = leitor.GetInt32("poltronas");

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

                        cinema.Id = leitor.GetInt32("id");
                        cinema.Ingresso = leitor.GetDouble("ingresso");
                        cinema.NomeFilme = leitor.GetString("nomeFilme");
                        cinema.Poltronas = leitor.GetInt32("poltronas");

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
                comando.Parameters.AddWithValue("@ingresso", Ingresso);
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
        return $"{Id} - {NomeFilme} - R$ {Ingresso:F2} - Poltronas: {Poltronas}";
    }
}