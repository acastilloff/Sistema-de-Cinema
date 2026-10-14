<!-- # Sistema-De-Cinema

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
O sistema utiliza a biblioteca MySqlConnector para conectar o programa C# ao banco de dados Cinema, que está no MySQL. A conexão é feita por meio de uma string contendo o servidor, porta, banco, usuário e senha. O programa abre a conexão com MySqlConnection, envia comandos SQL usando MySqlCommand e recebe os dados do banco através do MySqlDataReader. Após realizar a operação, a conexão é fechada automaticamente pelo using.

<!-- # COMANDOS SQL

# 4. Parte 1 — Pesquisa: C# e Banco de Dados

## 4.1 Conexão

1. Como C# realiza uma conexão com um banco de dados?

O C# realiza a conexão com um banco de dados por meio de uma biblioteca ou driver específico. No sistema de filmes, é utilizada a classe MySqlConnection, que recebe uma string de conexão com as informações necessárias para acessar o banco de dados. Depois, o método Open() estabelece a conexão.

2. Qual biblioteca/driver é utilizado pelo banco escolhido?

O banco de dados escolhido foi o MySQL, e a biblioteca utilizada no projeto é o MySqlConnector. Ela permite que o C# se comunique com o MySQL, execute comandos SQL e receba os resultados das consultas.

3. Como essa biblioteca é adicionada ao projeto?

A biblioteca pode ser instalada pelo gerenciador de pacotes NuGet, utilizando o Visual Studio ou o terminal do projeto. Pelo terminal, o comando é:

||dotnet add package MySqlConnector||

Depois, é possível utilizar a biblioteca no código com:

||using MySqlConnector;||

4. O que é uma string de conexão?

Uma string de conexão é um texto que reúne as informações necessárias para conectar um programa a um banco de dados. Ela informa ao sistema qual banco será acessado e quais configurações serão utilizadas para estabelecer a conexão.

5. Quais informações normalmente aparecem em uma string de conexão?

As informações mais comuns são o servidor, a porta, o nome do banco de dados, o usuário e a senha. No projeto, a string de conexão utiliza o servidor 127.0.0.1, a porta 3306, o banco Cinema e o usuário root.

## 4.2 Comandos SQL

Os comandos SQL permitem cadastrar, consultar, atualizar e excluir informações armazenadas no banco de dados. No C#, eles são executados utilizando classes como MySqlCommand.

INSERT — Inserir dados

O comando INSERT serve para adicionar novos registros a uma tabela. No sistema de filmes, ele é utilizado para cadastrar o nome do filme, o preço do ingresso e a quantidade de ingressos disponíveis.

Exemplo:

||INSERT INTO filmes (nomeFilme, precoIngresso, quantidadeIngressos) VALUES (@nome, @preco, @quantidade);||

No C#, os valores são enviados por parâmetros e o comando é executado com ExecuteNonQuery().

SELECT — Consultar dados

O comando SELECT serve para consultar e recuperar informações armazenadas no banco de dados. No sistema, ele permite listar todos os filmes ou buscar um filme específico pelo seu ID.

Exemplo:

||SELECT * FROM filmes;||

Para executar a consulta no C#, utiliza-se ExecuteReader(), que permite ler os registros retornados pelo banco.

UPDATE — Atualizar dados

O comando UPDATE serve para modificar informações de registros que já existem. No sistema de filmes, pode ser utilizado para alterar o nome, o preço do ingresso e a quantidade de ingressos de um filme.

Exemplo:

UPDATE filmes SET nomeFilme = @nome, precoIngresso = @preco WHERE id = @id;

A condição WHERE identifica qual registro deve ser atualizado. Sem essa condição, todos os registros da tabela poderiam ser alterados.

DELETE — Excluir dados

O comando DELETE serve para remover registros de uma tabela. No sistema, ele permite excluir um filme específico por meio do seu ID.

Exemplo:

DELETE FROM filmes WHERE id = @id;

No projeto, antes da exclusão, o programa pode verificar se o filme existe e solicitar a confirmação do usuário. A condição WHERE é importante porque, sem ela, todos os registros da tabela poderiam ser excluídos.

## 4.3 Consulta de dados

1. Como o C# recebe os dados retornados por um SELECT?

O C# recebe os dados de uma consulta utilizando o método ExecuteReader() da classe MySqlCommand. Esse método retorna um objeto MySqlDataReader, que permite acessar os registros retornados pelo banco de dados.

2. Como percorrer os resultados de uma consulta?

Os resultados podem ser percorridos utilizando um laço while junto com o método Read() do MySqlDataReader. O método Read() avança para o próximo registro e retorna true enquanto houver dados disponíveis.

Exemplo:

while (leitor.Read())

Dentro do laço, os valores podem ser acessados pelo nome da coluna, como leitor["nomeFilme"].

3. Como transformar os dados retornados pelo banco em objetos de uma classe?

Para transformar os dados em objetos, o programa cria uma instância da classe desejada e atribui a ela os valores retornados pelo banco. No sistema de filmes, é criado um objeto da classe Filme, preenchendo suas propriedades Id, NomeFilme, PrecoIngresso e QuantidadeIngressos.
Dessa forma, os dados do banco podem ser utilizados pelo programa como objetos, facilitando sua organização e manipulação.

## 4.4 Segurança

1. O que são parâmetros em comandos SQL e por que são importantes?

Parâmetros são valores enviados separadamente do texto do comando SQL. No C#, eles podem ser adicionados utilizando comando.Parameters.AddWithValue().
No sistema de filmes, são utilizados parâmetros como @nome, @preco, @quantidade e @id. Eles ajudam a evitar que os dados informados pelo usuário sejam interpretados como parte do código SQL, reduzindo o risco de ataques de injeção de SQL.

2. O que pode acontecer quando um sistema monta comandos SQL diretamente utilizando textos digitados pelo usuário?

Quando o programa concatena diretamente os textos digitados pelo usuário em um comando SQL, pode ocorrer uma injeção de SQL (SQL Injection). Nesse tipo de ataque, uma entrada maliciosa pode alterar o significado do comando e permitir consultas, alterações ou exclusões não autorizadas.
Por isso, é recomendado utilizar consultas parametrizadas, validar os dados recebidos e limitar as permissões do usuário do banco de dados. Essas medidas ajudam a proteger as informações armazenadas no sistema.
