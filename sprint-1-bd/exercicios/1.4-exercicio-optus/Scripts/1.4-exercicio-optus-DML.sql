USE EXERCICIO_OPTUS_Livia;

INSERT INTO TipoUsuario(TipoPermissoes)
VALUES ('Administrador'),('Comum')

SELECT * FROM TipoUsuario;


INSERT INTO Estilo(NomeEstilo)
VALUES ('Pop'),('Pagode'),('Gospel')

SELECT * FROM Estilo;


INSERT INTO Usuario(IdTipoUsuario,NomeUsuario,Email,Senha)
VALUES (2,'Lívia','livia@gmail.com',123),(2,'Carol','carol@gmail.com',321), (1,'Lana','lana@gmail.com',152)

SELECT * FROM Usuario;


INSERT INTO Artista(IdUsuario,NomeArtista)
VALUES (1,'Justin'),(2,'Pixote')

SELECT * FROM Artista;


INSERT INTO ALBUM(IdArtista,NomeAlbum,DataLancamento)
VALUES (1,'Justice','21/02/2021'),(2,'Drive in','10/07/2021')

SELECT * FROM ALBUM;


INSERT INTO EstiloAlbum(IdAlbum,IdEstilo)
VALUES (1,1),(2,2)

SELECT * FROM EstiloAlbum;
