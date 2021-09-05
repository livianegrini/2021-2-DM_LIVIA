USE EXERCICIO_LOCADORA_LIVIA;
GO

INSERT INTO Empresa (NomeEmpresa)
VALUES ('Localiza'), ('NomeEmpresa')

SELECT * FROM Empresa

INSERT INTO Cliente(NomeCliente,CPF)
VALUES ('Ana',222),('Pedro',777),('Fernanda',444)

SELECT * FROM  Cliente

INSERT INTO Marca(NomeMarca)
VALUES ('GM'),('Ford'),('Fiat')

SELECT * FROM Marca

INSERT INTO Modelo(NomeModelo,IdMarca)
VALUES ('Onix',1),('Focus',2),('Mobli',3)

SELECT * FROM Modelo;

INSERT INTO Veiculo (IdEmpresa,Placa,IdModelo)
VALUES (2,777,1),(1,555,2),(2,888,3)

SELECT * FROM Veiculo

INSERT INTO Aluguel(IdCliente,IdVeiculo,Preco,[Data])
VALUES (3,2,250,'30/05/2021'),(1,1,300,'07/07/2021'),(2,3,200,'10/08/2021')

SELECT * FROM Aluguel




