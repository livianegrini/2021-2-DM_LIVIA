USE EXERCICIO_LOCADORA_LIVIA;
GO


-- listar todos os alugueis mostrando as datas de in�cio e fim, 
--o nome do cliente que alugou e nome do modelo do carro
SELECT [Data], NomeCliente, NomeModelo
FROM Aluguel
INNER JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo


-- listar os alugueis de um determinado cliente mostrando seu nome,
--as datas de in�cio e fim e o nome do modelo do carro
SELECT  NomeCliente,[Data], NomeModelo
FROM Aluguel
INNER JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo
WHERE NomeCliente = 'Fernanda';