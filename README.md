# Sistema-De-Cinema

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
