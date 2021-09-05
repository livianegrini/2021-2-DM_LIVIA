USE ExercicioPClinics_1_3;
GO

INSERT INTO Clinica(NomeClinca,Endereco,RazaoSocial)
VALUES ('PetCare','rua a','Clinica Veterinaria Care Mais'),('BichoZen','rua b','Clinica Veterinaria BichoZen')

SELECT * FROM Clinica


INSERT INTO TipoPet(TipoPet)
VALUES ('Gato'),('Cachorro'),('Peixe')

SELECT * FROM TipoPet;


INSERT INTO Raca(NomeRaca,IdTipoPet)
VALUES ('Persa',1),('Golden',2),('Beta',3),('Siames',1)


SELECT * FROM Raca;


INSERT INTO PET(IdDono, NomePet, IdRaca)
VALUES (1,'Mel',1),(2,'Layca',2),(3,'Dino',3),(4,'Luke',4)

SELECT * FROM PET;


INSERT INTO Veterinario(IdClinica,NomeVeterinario,CRMV)
VALUES (1,'Adriano',14297),(2,'Pedro',19075),(2,'Maria',07116)

SELECT * FROM Veterinario;


INSERT INTO Dono(NomeDono)
VALUES ('Adão'),('Elisete'),('Ana'),('Samuel')

SELECT * FROM Dono;


INSERT INTO Atendimento(IdPet,IdVeterinario,NumeroAtendimento,DataAtendimento)
VALUES (4,1,25,'07/08/2021'),(5,1,26,'08/08/2021'),(6,2,27,'09/08/2021'), (7,2,28,'10/08/2021')

SELECT * FROM Atendimento;





