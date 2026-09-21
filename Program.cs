// Cria a matriz de poltronas
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
}