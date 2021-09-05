USE EXERCICIO_OPTUS_Livia;

SELECT * FROM TipoUsuario;

SELECT * FROM Estilo;

SELECT * FROM Usuario;

SELECT * FROM Artista;

SELECT * FROM ALBUM;

SELECT * FROM EstiloAlbum;

-- listar todos os usuários administradores, sem exibir suas senhas
SELECT NomeUsuario, TipoPermissoes,Email
FROM Usuario
INNER JOIN TipoUsuario
ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario
WHERE TipoPermissoes = 'Administrador';
GO

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT * FROM ALBUM
WHERE DataLancamento > '2018';
GO

-- listar os dados de um usuário através do e-mail e senha
SELECT * FROM Usuario
WHERE Email = 'livia@gmail.com' AND Senha = 123
GO

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 
SELECT NomeAlbum, DataLancamento, NomeArtista, NomeEstilo
FROM ALBUM
INNER JOIN Artista
ON ALBUM.IdArtista = Artista.IdArtista
INNER JOIN EstiloAlbum
ON ALBUM.IdAlbum = EstiloAlbum.IdAlbum
INNER JOIN Estilo
ON EstiloAlbum.IdEstilo = Estilo.IdEstilo
GO