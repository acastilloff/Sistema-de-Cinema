using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== INICIANDO TESTES DO CRUD COMPLETO ===\n");

        // ==========================================
        // 1. CREATE (CADASTRAR)
        // ==========================================
        Console.WriteLine("--- 1. Testando Cadastro (CREATE) ---");
        
        string filmeCadastro = "Vingadores: Ultimato";
        double precoCadastro = 45.50;

        Cinema novoCinema = new Cinema(precoCadastro, filmeCadastro);
        
        // Reservando assentos no código
        novoCinema.ReservarAssento(1, 1);
        novoCinema.ReservarAssento(1, 2);

        novoCinema.Cadastrar();


        // ==========================================
        // 2. READ (LISTAR TODOS)
        // ==========================================
        Console.WriteLine("\n--- 2. Testando Listagem Geral (READ) ---");
        Cinema.Listar();


        // ==========================================
        // 3. READ (BUSCAR POR ID)
        // ==========================================
        Console.WriteLine("\n--- 3. Testando Busca por ID (READ) ---");
        
        int idParaBuscar = 1; 
        Cinema.Buscar(idParaBuscar);


        // ==========================================
        // 4. UPDATE (ATUALIZAR)
        // ==========================================
        Console.WriteLine("\n--- 4. Testando Atualização (UPDATE) ---");
        
        int idParaEditar = 1;
        string filmeNovoNome = "Vingadores: Ultimato (Versão Estendida)";
        double precoNovoValor = 50.00;

        Cinema cinemaEditado = new Cinema(precoNovoValor, filmeNovoNome);
        cinemaEditado.Id = idParaEditar;
        cinemaEditado.QuantidadePoltronasOcupadas = 4;

        cinemaEditado.Atualizar();


        // ==========================================
        // 5. DELETE (EXCLUIR)
        // ==========================================
        Console.WriteLine("\n--- 5. Testando Exclusão (DELETE) ---");
        
        int idParaDeletar = 2; 
        Cinema.Excluir(idParaDeletar);


        // ==========================================
        // FINALIZAÇÃO
        // ==========================================
        Console.WriteLine("\n=========================================");
        Console.WriteLine("===    TODOS OS TESTES FINALIZADOS    ===");
        Console.WriteLine("=========================================");
    }
}
