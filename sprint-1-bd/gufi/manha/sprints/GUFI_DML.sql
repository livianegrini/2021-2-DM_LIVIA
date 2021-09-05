USE GUFI_LIVIA;
GO

--TIPO USUARIO
INSERT INTO TipoUsuario(TituloTipoUsuario)
VALUES ('Administrador'),('Comum');
GO

--INSTITUICAO
INSERT INTO Instituicao(CNPJ,NomeFantasia,Endereco)
VALUES ('99999999999999', 'Escola SENAI de Informática', 'Al. Barão de Limeira, 539');
GO

--TIPO EVENTO
INSERT INTO TipoEvento(TituloTipoEvento)
VALUES ('CH'),('React35'),('SQL');
GO

--SITUACAO
INSERT INTO Situacao(Descricao)
VALUES ('Aprovada'),('Recusada'),('Aguardando');
GO

--USUARIO
INSERT INTO Usuario (IdTipoUsuario,NomeUsuario,Email,Senha)
VALUES  (1,'Administrador', 'Adm@gmail.com', 'senha123'),
		(2, 'Lucas','Lucas@gmail.com','lucas123'),
		(2, 'Saulo', 'Saulo@gmail.com', 'saulo123');
GO

--EVENTO
INSERT INTO Evento(IdTipo,IdInstituicao,NomeEvento,Descricao,AcessoLivre,DataEvento)
VALUES (1,'Administrador', 'Adm@gmail.com', 'senha123'),
	(2, 'Lucas','Lucas@gmail.com','senha'),
	(),
	()
;
GO

