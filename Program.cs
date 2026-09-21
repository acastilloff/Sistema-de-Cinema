class Program
{
    static void Main(string[] args)
    {
        // ==========================================
        // CINEMAS / FILMES
        // ==========================================

        Cinema cinema1 = new Cinema(25.00, "Vingadores: Ultimato");
        Cinema cinema2 = new Cinema(30.00, "Homem-Aranha: Sem Volta Para Casa");
        Cinema cinema3 = new Cinema(22.50, "Interestelar");
        Cinema cinema4 = new Cinema(28.00, "Divertida Mente 2");
        Cinema cinema5 = new Cinema(27.50, "Jurassic World");

        // ==========================================
        // CADASTRAR NO BANCO DE DADOS
        // ==========================================

        cinema1.Cadastrar();
        cinema2.Cadastrar();
        cinema3.Cadastrar();
        cinema4.Cadastrar();
        cinema5.Cadastrar();

        // ==========================================
        // RESERVAR ALGUNS ASSENTOS
        // ==========================================

        cinema1.ReservarAssento(0, 0);
        cinema1.ReservarAssento(0, 1);
        cinema1.ReservarAssento(1, 2);

        cinema2.ReservarAssento(2, 2);
        cinema2.ReservarAssento(2, 3);

        cinema3.ReservarAssento(1, 1);

        // ==========================================
        // ATUALIZAR QUANTIDADE DE POLTRONAS
        // ==========================================

        cinema1.Atualizar();
        cinema2.Atualizar();
        cinema3.Atualizar();

        // ==========================================
        // LISTAR TODOS OS CINEMAS
        // ==========================================

        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("         CINEMAS CADASTRADOS");
        Console.WriteLine("==========================================");

        Cinema.Listar();

        // ==========================================
        // BUSCAR UM CINEMA
        // ==========================================

        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("            BUSCAR CINEMA");
        Console.WriteLine("==========================================");

        // Altere o número para o ID que quiser buscar
        Cinema.Buscar(1);

        Console.WriteLine();
        Console.WriteLine("Programa finalizado.");
    }
}