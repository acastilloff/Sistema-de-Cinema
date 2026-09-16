CREATE DATABASE IF NOT EXISTS Cinema;

USE Cinema;

CREATE TABLE IF NOT EXISTS cinemas 
(
     id INT PRIMARY KEY AUTO_INCREMENT,
    ingresso DECIMAL(10,2),
    nomeFilme VARCHAR(100),
    poltronas INT
);
SELECT * FROM  cinemas