USE ExercicioPClinics_1_3;
GO

SELECT * FROM Clinica;

SELECT * FROM Veterinario;

SELECT * FROM Dono;

SELECT * FROM PET;

SELECT * FROM Atendimento;

SELECT * FROM TipoPet;

SELECT * FROM Raca;



--listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
SELECT NomeVeterinario, CRMV, RazaoSocial
FROM Clinica
INNER JOIN Veterinario
ON Clinica.IdClinica = Veterinario.IdClinica;
GO

--listar todas as raças que começam com a letra S
SELECT * FROM Raca
WHERE NomeRaca LIKE 'S%';
GO

-- listar todos os tipos de pet que terminam com a letra O
SELECT * FROM TipoPet
WHERE TipoPet LIKE '%o';
GO

-- listar todos os pets mostrando os nomes dos seus donos
SELECT IdPet, NomePet, NomeDono 
FROM PET
INNER JOIN Dono
ON PET.IdDono= Dono.IdDono;
GO

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome,
--a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica 
--onde o pet foi atendido
SELECT IdAtendimento, NumeroAtendimento, DataAtendimento, NomeVeterinario,  NomePet, NomeRaca, TipoPet, NomeDono, NomeClinca
FROM Atendimento
INNER JOIN Veterinario
ON Atendimento.IdVeterinario= Veterinario.IdVeterinario
INNER JOIN PET
ON PET.IdPet= Atendimento.IdPet
INNER JOIN Raca
ON PET.IdRaca= Raca.IdRaca
INNER JOIN TipoPet
ON Raca.IdTipoPet = TipoPet.IdTipoPet
INNER JOIN Dono
ON PET.IdDono = Dono.IdDono
INNER JOIN Clinica
ON Clinica.IdClinica = Veterinario.IdClinica
GO


