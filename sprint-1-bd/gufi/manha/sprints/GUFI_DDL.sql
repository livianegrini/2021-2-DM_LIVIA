CREATE DATABASE GUFI_LIVIA;
GO

USE GUFI_LIVIA

--TIPO USUÁRIO

CREATE TABLE TipoUsuario(
   IdTipoUsuario INT PRIMARY KEY IDENTITY,
   TituloTipoUsuario  VARCHAR(30) UNIQUE NOT NULL
);
GO

--TIPO EVENTO
CREATE TABLE TipoEvento(
	IdTipoEvento INT PRIMARY KEY  IDENTITY,
	TituloTipoEvento VARCHAR (50) UNIQUE NOT NULL
);
GO

--INSTITUICAO
CREATE TABLE Instituicao(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) UNIQUE NOT NULL,
	NomeFantasia VARCHAR (100) NOT NULL UNIQUE,
	Endereco VARCHAR (250) UNIQUE NOT NULL
);
GO

--SITUACAO
CREATE TABLE Situacao(
	IdSituacao INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR (50)
);
GO

--USUARIO
CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoEvento INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	NomeUsuario VARCHAR (50) NOT NULL,
	Email VARCHAR(200) UNIQUE NOT NULL,
	Senha VARCHAR(10) NOT NULL
);
GO

--EVENTO
CREATE TABLE Evento(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	NomeEvento VARCHAR (100) NOT NULL,
	Descricao VARCHAR(500) NOT NULL,
	AcessoLivre BIT DEFAULT (1),
	DataEvento DATETIME NOT NULL
);
GO

--PRESENCA
CREATE TABLE Presenca(
	IdPresenca INT PRIMARY KEY IDENTITY,
	IdTipoEvento INT FOREIGN KEY REFERENCES TipoEvento(IdTipoEvento),
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao)
);
GO

DROP TABLE Presenca;
GO


--PRESENCA
create table Presenca(
 IdPresenca INT PRIMARY KEY IDENTITY ,
 IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
 IdEvento int  foreign key  references Evento(IdEvento),
 IdSituacao int  foreign key  references Situacao(IdSituacao) DEFAULT (3)
);
GO


/* RESUMO COMANDOS

 PRIMARY KEY = CHAVE PRIMARIA
 FOREIGN KEY = CHAVE ESTRANGEIRA
 IDENTITY = Define que o campo será auto-incremento e unico e (1,1) 
            inicia do 1 e vai de 1 em 1.
 NOT NULL = Não pode ser nulo, ou seja, é obrigatorio.
 UNIQUE = Campo é unique , ou seja , não se repete.
 DEFAULT = Defineum valor padrão, caso nenhum seja informado.
 GO = Pausa a leitura e executa o bloco de codigo acima.

*/


DROP TABLE Evento;
GO

--EVENTO
CREATE TABLE Evento(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoEvento INT FOREIGN KEY REFERENCES TipoEvento(IdTipoEvento),
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	NomeEvento VARCHAR (100) NOT NULL,
	Descricao VARCHAR(500) NOT NULL,
	AcessoLivre BIT DEFAULT (1),
	DataEvento DATETIME NOT NULL
);
GO
