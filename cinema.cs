using System;
using MySqlConnector;

public class Cinema
{
    private string conexao = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";
   
    private int id;
    private double preçoIngresso;
    private string nomeFilme;
<<<<<<< HEAD
    private bool[,]poltronas = new bool[5,5];
    private bool reservarAssento;
=======
    private bool[,] poltronasMatriz = new bool[5, 5]; 
    private int quantidadePoltronasOcupadas;
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9
    
    // Construtor vazio essencial para o Listar e Buscar
    public Cinema()
    {
    }

    public Cinema(double preçoIngresso, string nomeFilme)
    {
        this.PreçoIngresso = preçoIngresso;
        this.NomeFilme = nomeFilme;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public double PreçoIngresso
    {
        get { return preçoIngresso; }
        set
        {
            if (value < 22.50) Console.WriteLine("Valor inválido.");
            else preçoIngresso = value;
        }
    }

    public string NomeFilme
    {
        get { return nomeFilme; }
        set
        {
            if (string.IsNullOrWhiteSpace(value)) Console.WriteLine("Nome inválido.");
            else nomeFilme = value;
        }
    }

    public int QuantidadePoltronasOcupadas
    {
        get { return quantidadePoltronasOcupadas; }
        set { quantidadePoltronasOcupadas = value; }
    }

    public bool ReservarAssento(int linha, int coluna)
    {
        if (poltronasMatriz[linha, coluna]) return false; 
        
        poltronasMatriz[linha, coluna] = true;
        quantidadePoltronasOcupadas++; 
        return true;
    }

    public void Cadastrar()
    {
        using (MySqlConnection banco = new MySqlConnection(conexao))
        {
            banco.Open();

<<<<<<< HEAD
            string sql = "INSERT INTO cinemas (preçoingresso, quantidadeingressos, nomeFilme, poltronas) " +
                         "VALUES (@ingresso, @nomeFilme, @poltronas)";
=======
            string sql = "INSERT INTO cinemas (ingresso, nomeFilme, poltronas) VALUES (@ingresso, @nomeFilme, @poltronas)";
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@ingresso", PreçoIngresso);
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue("@poltronas", QuantidadePoltronasOcupadas);

                comando.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Cinema cadastrado com sucesso!");
    }

    public static void Listar()
    {
        string conexaoLocal = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

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
<<<<<<< HEAD

                    cinema.Id = leitor.GetInt32("ID");
                        cinema.PreçoIngresso = leitor.GetDouble("Preço do Ingresso");
                        cinema.QuantidadeIngressos = leitor.GetInt32("Número de Ingressos");
                        cinema.NomeFilme = leitor.GetString("Nome do Filme");
                        cinema.Poltronas = leitor.GetBoolean("Número das Poltronas da Sala");
=======
                    cinema.Id = leitor.GetInt32("id");
                    cinema.PreçoIngresso = leitor.GetDouble("ingresso");
                    cinema.NomeFilme = leitor.GetString("nomeFilme");
                    cinema.QuantidadePoltronasOcupadas = leitor.GetInt32("poltronas");
                    
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9
                    Console.WriteLine(cinema);
                }
            }
        }
    }

    public static void Buscar(int id)
    {
        string conexaoLocal = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

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
<<<<<<< HEAD

                        cinema.Id = leitor.GetInt32("ID");
                        cinema.PreçoIngresso = leitor.GetDouble("Preço do Ingresso");
                        cinema.QuantidadeIngressos = leitor.GetInt32("Número de Ingressos");
                        cinema.NomeFilme = leitor.GetString("Nome do Filme");
                        cinema.Poltronas = leitor.GetBoolean("Número das Poltronas da Sala");
=======
                        cinema.Id = leitor.GetInt32("id");
                        cinema.PreçoIngresso = leitor.GetDouble("ingresso");
                        cinema.NomeFilme = leitor.GetString("nomeFilme");
                        cinema.QuantidadePoltronasOcupadas = leitor.GetInt32("poltronas");
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9

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

            string sql = "UPDATE cinemas SET ingresso = @ingresso, nomeFilme = @nomeFilme, poltronas = @poltronas WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", Id);
<<<<<<< HEAD
                comando.Parameters.AddWithValue("@preçoingresso", preçoIngresso);
                comando.Parameters.AddWithValue("@quantidadeingresso", quantidadeIngressos);
=======
                comando.Parameters.AddWithValue("@ingresso", PreçoIngresso);
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9
                comando.Parameters.AddWithValue("@nomeFilme", NomeFilme);
                comando.Parameters.AddWithValue("@poltronas", QuantidadePoltronasOcupadas);

                int linhasAlteradas = comando.ExecuteNonQuery();
                if (linhasAlteradas > 0) Console.WriteLine("Cinema atualizado com sucesso!");
                else Console.WriteLine("Cinema não encontrado.");
            }
        }
    }

    public static void Excluir(int id)
    {
        string conexaoLocal = "Server=127.0.0.1;Database=Cinema;User ID=root;Password=Senac2026;";

        using (MySqlConnection banco = new MySqlConnection(conexaoLocal))
        {
            banco.Open();
            string sql = "DELETE FROM cinemas WHERE id = @id";

            using (MySqlCommand comando = new MySqlCommand(sql, banco))
            {
                comando.Parameters.AddWithValue("@id", id);

                int linhasExcluidas = comando.ExecuteNonQuery();
                if (linhasExcluidas > 0) Console.WriteLine("Cinema excluído com sucesso!");
                else Console.WriteLine("Cinema não encontrado.");
            }
        }
    }

    public override string ToString()
    {
<<<<<<< HEAD
        return $"{Id} || {NomeFilme} || R$: {PreçoIngresso} || Quantidade de Ingressos: {QuantidadeIngressos} || Poltronas Escolhidas: {Poltronas}";
=======
        return $"ID: {Id} | Filme: {NomeFilme} | Preço: R$ {PreçoIngresso:F2} | Poltronas Ocupadas: {QuantidadePoltronasOcupadas}";
>>>>>>> 312661897b4cb9cc56030b47b8ffed1a7e9d5ba9
    }
}
