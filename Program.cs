Cinema meuCinema = new Cinema(
    25,
    2,
    "Homem-Aranha",
    new bool[5, 5],
    false
);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("===== POLTRONAS =====");
    Console.WriteLine();

    // Mostra as poltronas
    for (int linha = 0; linha < 5; linha++)
    {
        for (int coluna = 0; coluna < 5; coluna++)
        {
            if (meuCinema.Poltronas[linha, coluna])
            {
                Console.Write("[XX] ");
            }
            else
            {
                Console.Write("[  ] ");
            }
        }

        Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Escolha uma poltrona.");
    Console.Write("Digite a linha (0 a 4): ");

    if (!int.TryParse(Console.ReadLine(), out int indiceLinha))
    {
        Console.WriteLine("Linha inválida!");
        continue;
    }

    Console.Write("Digite a coluna (0 a 4): ");

    if (!int.TryParse(Console.ReadLine(), out int indiceColuna))
    {
        Console.WriteLine("Coluna inválida!");
        continue;
    }

    // Verifica se a posição existe
    if (indiceLinha < 0 || indiceLinha >= 5 ||
        indiceColuna < 0 || indiceColuna >= 5)
    {
        Console.WriteLine("Essa poltrona não existe!");
        continue;
    }

    // Tenta reservar
    if (meuCinema.ReservarAssento(indiceLinha, indiceColuna))
    {
        Console.WriteLine("Assento reservado com sucesso!");
    }
    else
    {
        Console.WriteLine("Este assento ja esta ocupado!");
    }

    Console.WriteLine();
    Console.Write("Deseja reservar outro assento? (s/n): ");

    string resposta = Console.ReadLine() ?? "";

    if (resposta.ToLower() != "s")
    {
        break;
    }
}