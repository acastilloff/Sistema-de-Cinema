CREATE DATABASE IF NOT EXISTS Cinema;

USE Cinema;

DROP TABLE IF EXISTS cinemas;

CREATE TABLE cinemas
(
    id INT PRIMARY KEY AUTO_INCREMENT,
    precoIngresso DECIMAL(10,2),
    quantidadeIngressos INT,
    nomeFilme VARCHAR(100),
    poltronas TEXT,
    reservarAssento BOOLEAN
);

SELECT * FROM cinemas;