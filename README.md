# sistema-de-cinema

# Nome do projeto 
Sistema do Cinema Colluz;

# Integrantes
Arthur Castillo, Ester Corrêa e Giovanna Luz;

# Banco de dados utilizado 
Optamos por utilizar o banco MySql, já que estamos mais familiarizados com ele;

# Biblioteca/driver utilizado 
Escolhemos usar a biblioteca MySqlConnector. Ela nos permite que o programa C# se conecte ao MySql, execute comandos SQL e leia os dados retornados;

# Como instalar as dependências
Ao entrar no VS Code, clique Ctrl J. Escreva no terminal 'dotnet add package MySqlConnector', depois, para restaurar as dependências, digite 'dotnet restore'. No fim, para executar todo o programa, escreva 'dotnet run'

# Como configurar o banco
Primeiro, abra o MySql Workbench e se conecte ao servidor MySql. Depois, execute o arquivo ||banco.sql||, que cria o banco ||Cinema|| e a tabela ||filmes||. O C# utiliza dados de conexão do MySql para acessar o banco e realizar o CRUD.

# Como executar o projeto
Abra o projeto no VS Code e, no terminal, execute o comando ||dotnet run||. O programa será iniciado no terminal e apresentará o menu do sistema.

# Breve explicação de como funciona a conexão.
O sistema utiliza o MySqlConnector para conectar o C# ao banco de dados MySQL. A conexão utiliza o servidor, porta, banco de dados, usuário e senha configurados no código. Através dessa conexão, o sistema consegue cadastrar, listar, buscar, atualizar e excluir filmes no banco de dados (CRUD) pedido pelo professor.



# Sistema de cinema colluz

## Integrantes

* Arthur
* Ester
* Luz

## Sobre o projeto

O Gasther Colluz é um sistema de gerenciamento de filmes desenvolvido em **C#**, executado pelo terminal e conectado a um banco de dados **MySQL**.

O sistema permite cadastrar, listar, buscar, atualizar e excluir filmes.

## Tecnologias utilizadas

* C#
* .NET
* MySQL
* MySQL Workbench
* MySqlConnector

## Banco de dados

O banco de dados utilizado no projeto é o **MySQL**.

O banco se chama `Cinema` e possui a tabela `filmes`.

A tabela possui os seguintes campos:

* `id` — identificador do filme;
* `nomeFilme` — nome do filme;
* `precoIngresso` — preço do ingresso;
* `quantidadeIngressos` — quantidade de ingressos.

O arquivo `banco.sql` contém os comandos necessários para criar o banco e a tabela.

## Biblioteca utilizada

Foi utilizada a biblioteca **MySqlConnector**, que permite que o C# se comunique com o MySQL.

Para instalar a biblioteca, execute no terminal do projeto:

```bash
dotnet add package MySqlConnector
```

## Como configurar o banco

1. Abra o MySQL Workbench.
2. Conecte-se ao servidor MySQL.
3. Abra o arquivo `banco.sql`.
4. Execute o script para criar o banco `Cinema` e a tabela `filmes`.

## Como executar o projeto

Abra o projeto no VS Code e, no terminal, execute:

```bash
dotnet run
```

O sistema será iniciado no terminal e apresentará o menu principal.

## Funcionalidades

O sistema possui as seguintes operações:

1. Cadastrar filme
2. Listar filmes
3. Buscar filme
4. Atualizar filme
5. Excluir filme
6. Sair

## Como funciona a conexão

O C# utiliza o **MySqlConnector** para realizar a comunicação com o MySQL.

A conexão utiliza as informações do servidor, porta, banco de dados, usuário e senha. Depois de abrir a conexão, o programa envia comandos SQL para o banco utilizando `MySqlCommand`.

Os comandos utilizados no projeto são:

* `INSERT` para cadastrar filmes;
* `SELECT` para listar e buscar filmes;
* `UPDATE` para atualizar filmes;
* `DELETE` para excluir filmes.

Os resultados das consultas `SELECT` são recebidos através do `MySqlDataReader` e utilizados para criar objetos da classe `Filme`.

Os comandos SQL utilizam parâmetros, como `@id`, `@nome`, `@preco` e `@quantidade`, evitando colocar diretamente os valores digitados pelo usuário dentro do SQL.

## Estrutura do projeto

```text
Sistema-de-Cinema/
│
├── Program.cs
├── cinema.cs
├── banco.sql
├── README.md
└── Sistema-de-Cinema.csproj
```
