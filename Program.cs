using System.Xml;


Cinema meuCinema = new Cinema();

if(meuCinema.Poltronas[1,c])
{
    Console.WriteLine(" [ XX ] ");
}

if(meuCinema.ReservarAssento(indiceLinha,indiceColuna))
{
    Console.WriteLine("Assento reservado com sucesso!");
}
else
{
    Console.WriteLine("Este assento ja esta ocupado!");
}