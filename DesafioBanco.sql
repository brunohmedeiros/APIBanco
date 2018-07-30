-- Database: "DesafioBanco"

DROP DATABASE "DesafioBanco";

CREATE DATABASE "DesafioBanco";

CREATE TABLE pessoas (
  idpessoa SERIAL PRIMARY KEY NOT NULL,
  nome TEXT,
  cpf varchar(11),
  datanascimento DATE NOT NULL
)

CREATE TABLE contas (
  idconta SERIAL PRIMARY KEY NOT NULL,
  idpessoa INTEGER NOT NULL,
  datacriacao DATE NOT NULL,
  saldo NUMERIC(18, 4) NOT NULL,
  limitesaquediario NUMERIC(18, 4) NOT NULL,
  tipoconta INTEGER NOT NULL,
  flagativo BOOLEAN NOT NULL,
  constraint fk_pessoa
    foreign key (idpessoa) 
    REFERENCES pessoas (idpessoa)
)

CREATE TABLE transacoes (
  idtransacao SERIAL PRIMARY KEY NOT NULL,
  idconta INTEGER NOT NULL,
  valor NUMERIC(18, 4),
  datatransacao DATE NOT NULL,
    constraint fk_conta
    foreign key (idconta) 
    REFERENCES contas (idconta)
)

INSERT INTO pessoas ("nome","cpf","datanascimento")
            VALUES ('Bruno Medeiros','11111111111','1997-01-17');

INSERT INTO pessoas ("nome","cpf","datanascimento")
            VALUES ('João','22222222222','2018-01-01');

INSERT INTO contas ("idpessoa","datacriacao","saldo","limitesaquediario","tipoconta","flagativo")
            VALUES (1,'2018-05-12',3.2874,1000,1,'t');

INSERT INTO contas ("idpessoa","datacriacao","saldo","limitesaquediario","tipoconta","flagativo")
            VALUES (1,'2018-05-12',2.3000,500,2,'t');

INSERT INTO contas ("idpessoa","datacriacao","saldo","limitesaquediario","tipoconta","flagativo")
            VALUES (1,'2018-05-01',1.2874,1000,2,'f');

INSERT INTO contas ("idpessoa","datacriacao","saldo","limitesaquediario","tipoconta","flagativo")
            VALUES (1,'2018-05-12',2.2874,1000,2,'t');

INSERT INTO transacoes ("idconta","valor","datatransacao")
            VALUES (1,1.0000,'2018-05-12');

INSERT INTO transacoes ("idconta","valor","datatransacao")
            VALUES (1,-1.0000,'2018-05-13');

INSERT INTO transacoes ("idconta","valor","datatransacao")
            VALUES (2,1.0000,'2018-05-12');

INSERT INTO transacoes ("idconta","valor","datatransacao")
            VALUES (1,1.1200,'2018-05-13');