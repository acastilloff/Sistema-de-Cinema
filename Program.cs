<<<<<<< HEAD
﻿class Program
=======
﻿// Cria a matriz de poltronas
bool[,] lugares = new bool[5, 5];

// Algumas poltronas já começam ocupadas
lugares[0, 2] = true; // Poltrona 3
lugares[1, 1] = true; // Poltrona 7
lugares[2, 1] = true; // Poltrona 12
lugares[3, 2] = true; // Poltrona 18
lugares[4, 0] = true; // Poltrona 21


// Cria o objeto Cinema
Cinema meuCinema = new Cinema(
    25,
    2,
    "Homem-Aranha",
    lugares,
    true
);


// Número da poltrona que será reservada
int numeroPoltrona = a;


// Mostra as poltronas
Console.WriteLine();
Console.WriteLine("===== POLTRONAS =====");
Console.WriteLine();

int numero = 1;

for (int linha = 0; linha < 5; linha++)
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
{
    for (int coluna = 0; coluna < 5; coluna++)
    {
<<<<<<< HEAD
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
=======
        if (meuCinema.Poltronas[linha, coluna])
        {
            Console.Write($"[{numero:00} XX] ");
        }
        else
        {
            Console.Write($"[{numero:00}   ] ");
        }

        numero++;
    }

    Console.WriteLine();
}

Console.WriteLine();


// Tenta reservar a poltrona escolhida
if (meuCinema.ReservarAssento(numeroPoltrona))
{
    Console.WriteLine(
        $"Assento {numeroPoltrona} reservado com sucesso!"
    );
}


// Mostra novamente as poltronas
Console.WriteLine();
Console.WriteLine("===== APÓS A RESERVA =====");
Console.WriteLine();

numero = 1;

for (int linha = 0; linha < 5; linha++)
{
    for (int coluna = 0; coluna < 5; coluna++)
    {
        if (meuCinema.Poltronas[linha, coluna])
        {
            Console.Write($"[{numero:00} XX] ");
        }
        else
        {
            Console.Write($"[{numero:00}   ] ");
        }

        numero++;
    }

    Console.WriteLine();
>>>>>>> 7488043dd66fd07db1d6153bb6b365b8e36a6aaa
}