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