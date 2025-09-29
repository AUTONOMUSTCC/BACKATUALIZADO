CREATE DATABASE AUTONOMUS;
USE  AUTONOMUS;

CREATE TABLE Cliente(
id_cliente INT PRIMARY KEY identity,
nome_cliente CHAR(20) NOT NULL,
sobrenome_cliente CHAR(20) NOT NULL,
email_cliente CHAR(30) NOT NULL,
genero_cliente CHAR(20) NOT NULL,
cidade_cliente CHAR(30) NOT NULL,
data_nasc_cliente DATE NOT NULL,
tel_cliente VARCHAR(15) NOT NULL,
senha_cliente VARCHAR(20) NOT NULL,
avaliacao_cliente DECIMAL (2,1)
)

INSERT INTO Cliente VALUES
( 'karina', 'uraue', 'karina@gmail.com', 'Feminino', 'São Paulo', '2007-10-02', '119999999', 'karina123', 5.0),
( 'dora', 'ferraz', 'dora@gmail.com', 'Feminino','São Paulo', '2008-06-09', '118888888', 'dora123', 5.0),
( 'nathalia', 'mori', 'nathalia@gmail.com', 'Feminino','São Paulo', '2008-02-10', '117777777', 'nathalia123', 5.0),
( 'juliana', 'castro', 'juliana@gmail.com', 'Feminino','São Paulo', '2007-09-24', '116666666', 'juliana123', 5.0), 
( 'elisa', 'cardoso', 'elisa@gmail.com', 'Feminino','São Paulo', '2007-07-18', '115555555', 'elisa123', 5.0)

CREATE TABLE Prestador(
id_prestador INT PRIMARY KEY identity,
tel_prestador VARCHAR(15) NOT NULL,
email_prestador CHAR(20) NOT NULL,
genero_prestador CHAR(20) NOT NULL,
cidade_prestador CHAR(30) NOT NULL,
senha_prestador VARCHAR(20) NOT NULL,
data_nasc_prestador DATE NOT NULL,
sobrenome_prestador CHAR(20) NOT NULL,
nome_prestador CHAR(20) NOT NULL,
avaliacao_prestador DECIMAL (2,1) NOT NULL
)

INSERT INTO Prestador VALUES
('luiz', 'ricardo', 'luiz@gmail.com','Masculino','São Paulo','2000-01-01', '114444444', 'luiz123', 3.2),
('rubens', 'ricardo', 'rubens@gmail.com','Masculino','São Paulo', '2000-01-01', '113333333', 'rubens123', 1.7),
('marcia', 'x', 'marcia@gmail.com', 'Feminino','São Paulo', '2000-01-01', '112222222', 'marcia123', 4.6),
('nair', 'hara', 'nair@gmail.com', 'Feminino', 'São Paulo','2000-01-01', '111111111', 'nair123', 4.9),
('matheus', 'brunetti', 'matheus@gmail.com','Masculino','São Paulo', '2000-01-01', '111234567', 'matheus123', 5.0)

CREATE TABLE Atividade(
id_atividade INT PRIMARY KEY,
id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
cargo CHAR(20) NOT NULL,
experiencia VARCHAR(500) NOT NULL,
tempo_cargo CHAR(20) NOT NULL
)

INSERT INTO Atividade VALUES
(1, 1, 'professoluizricardo', 'banco de dados', '11 anos'),
(2, 2, 'faz programa', 'php e android', '40 anos '),
(3, 3, 'matemática', 'matemática', '1003 E.C.'),
(4, 4, 'matemática', 'falabaixo', 'muitos'),
(5, 5, 'química', 'aux. docente', '12948753horas')


CREATE TABLE publicacao_Prestador(
id_publicacao_prestador INT PRIMARY KEY,
id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
id_atividade INT FOREIGN KEY REFERENCES Atividade(id_atividade),
titulo_publicacao_prestador CHAR(50) NOT NULL,
descricao_publicacao_prestador CHAR(100) NOT NULL,
data_publicacao_prestador DATE NOT NULL
)

CREATE TABLE comentario_Prestador (
    id_comentario_prestador INT PRIMARY KEY identity,
    texto_prestador NVARCHAR(500) NOT NULL,
    data_comentario_prestador DATE NOT NULL,
    id_prestador INT foreign key references Prestador(id_prestador),
);

INSERT INTO publicacao_Prestador VALUES
(1, 1, 1, 'especialista em banco de dados!', 'faço a parte de banco de dados do seu projeto de maneira eficaz (ou eficiente?)', '2025-01-01'),
(2, 2, 2, 'faço programas, me contratem', 'desenvolvo a parte de php e android do seu projeto!',  '2025-01-01'),
(3, 3, 3, 'professora particular de matematica', 'dou aulas sobre todo o conteudo de matematica existente',  '2025-01-01'),
(4, 4, 4, 'aula de geometria espacial', 'ensino sobre todos os conteudos de geometria',  '2025-01-01'),
(5, 5, 5, 'professor de quimica', 'dou aulas sobre os conteudos de quimica e adoro meus alunos do 3ds',  '2025-01-01')

CREATE TABLE publicacao_Cliente(
id_publicacao_cliente INT PRIMARY KEY NOT NULL,
id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
titulo_publicacao_cliente CHAR(50) NOT NULL,
descricao_publicacao_cliente CHAR(100) NOT NULL,
data_publicacao_prestador DATE NOT NULL
)

INSERT INTO publicacao_Cliente VALUES
(1, 1, 'procuro professor de banco de dados', 'quero um professor que seja meio calvo mas saiba ensinar', '2025-01-01'),
(2, 2, 'PRECISO DE PROGRAMADOR!!!!', 'urgente preciso de aulas de php pra minha prova', '2025-01-01'),
(3, 3, 'sou ruim em matematica', 'preciso de aulas em que a professora seja didática e gentil','2025-01-01'),
(4, 4, 'quero uma prof', 'sou ruim em geometria e preciso aprender funcao tambem, ajudaa', '2025-01-01'),
(5, 5, 'aulas de quimica!!!! urgente', 'minha prova vai estar muit dificil e preciso de aulas urgentemente', '2025-01-01')


CREATE TABLE comentario_Cliente (
    id_comentario_cliente INT PRIMARY KEY identity,
    texto_cliente NVARCHAR(500) NOT NULL,
    data_comentario_cliente DATE NOT NULL,
    id_cliente INT foreign key references Cliente(id_cliente),
);

CREATE TABLE Funcionario(
id_func INT PRIMARY KEY,
id_publicacao_prestador INT FOREIGN KEY REFERENCES publicacao_Prestador(id_publicacao_prestador),
id_publicacao_cliente INT FOREIGN KEY REFERENCES publicacao_Cliente(id_publicacao_cliente),
email_func CHAR(30) NOT NULL,
senha_func VARCHAR(20) NOT NULL
)

INSERT INTO Funcionario VALUES
(1, 1, 1, 'clarice@gmail.com', 'clarice123'),
(2, 2, 2, 'bombom@gmail.com', 'clarice123'),
(3, 3, 3, 'patricia@gmail.com', 'clarice123'),
(4, 4, 4, 'cris@gmail.com', 'clarice123'),
(5, 5, 5, 'sueli@gmail.com', 'clarice123')


CREATE TABLE Agenda_Cliente(
id_agenda_cliente INT PRIMARY KEY,
id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
agendamento_cliente BIT NOT NULL,
compromisso_cliente CHAR(50) NOT NULL
)

INSERT INTO Agenda_Cliente VALUES
(1, 1, 1, 'banco de dados do projeto quinta feira'),
(2, 2, 0, 'aula de php terça feira'),
(3, 3, 1, 'matematica na quarta feira'),
(4, 4, 1, 'geometria na sexta'),
(5, 5, 0, 'reforço de quimica segunda feira')


CREATE TABLE Agenda_Prestador(
id_agenda_prestador INT PRIMARY KEY,
id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
agendamento_prestador BIT NOT NULL,
compromisso_prestador CHAR(50) NOT NULL
)

INSERT INTO Agenda_Prestador VALUES
(1, 1, 1, 'dar aula de banco de dados quinta'),
(2, 2, 0, 'dar aula de php terça'),
(3, 3, 1, 'dar aula particular na quarta'),
(4, 4, 1, 'geometria na casa de fulano sexta feira'),
(5, 5, 0, 'quimica aula na segunda')


CREATE TABLE Localizacao(
id_localizacao INT PRIMARY KEY,
id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador),
id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
cidade CHAR(20) NOT NULL,
estado CHAR(20) NOT NULL,
cep NUMERIC NOT NULL
)

INSERT INTO Localizacao VALUES
(1, 1, 1, 'São Paulo', 'São Paulo', 00000000),
(2, 2, 2, 'Osasco', 'São Paulo', 11111111),
(3, 3, 3, 'Carapicuiba', 'São Paulo', 22222222),
(4, 4, 4, 'Viçosa', 'Minas Gerais', 33333333),
(5, 5, 5, 'Florianópolis', 'Santa Catarina', 44444444)

CREATE TABLE Chat (
    id_chat INT PRIMARY KEY IDENTITY,
    texto_chat NVARCHAR(500) NOT NULL,
    data_envio DATETIME NOT NULL,
    id_cliente INT FOREIGN KEY REFERENCES Cliente(id_cliente),
    id_prestador INT FOREIGN KEY REFERENCES Prestador(id_prestador)
);

CREATE PROCEDURE sp_InserirCliente
@NomeCliente NVARCHAR(100),
@SobrenomeCliente NVARCHAR(100),
@TelefoneCliente NVARCHAR(20),
@EmailCliente NVARCHAR(150),
@GeneroCliente CHAR(20),
@CidadeCliente CHAR(30),
@DataNascimentoCliente DATE,
@AvaliacaoCliente DECIMAL(10, 2),
@SenhaCliente NVARCHAR(100)
AS
BEGIN
INSERT INTO Cliente (
nome_cliente,
sobrenome_cliente,
tel_cliente,
email_cliente,
genero_cliente,
cidade_cliente,
data_nasc_cliente,
avaliacao_cliente,
senha_cliente
)
VALUES (
@NomeCliente,
@SobrenomeCliente,
@TelefoneCliente,
@EmailCliente,
@GeneroCliente,
@CidadeCliente,
@DataNascimentoCliente,
@AvaliacaoCliente,
@SenhaCliente
);
SELECT SCOPE_IDENTITY() AS NovoIdCliente;
END; 


create procedure sp_LoginCliente
@EmailCliente NVARCHAR(150),
@SenhaCliente NVARCHAR (100)
AS
BEGIN
SELECT email_cliente, senha_cliente from Cliente
where email_cliente = @EmailCliente and
senha_cliente = @SenhaCliente
END

create procedure sp_LoginPrestador
@EmailPrestador NVARCHAR(150),
@SenhaPrestador NVARCHAR (100)
AS
BEGIN
SELECT email_prestador, senha_prestador from Prestador
where email_prestador = @EmailPrestador and
senha_prestador = @SenhaPrestador
END



CREATE PROCEDURE sp_InserirPrestador
@NomePrestador NVARCHAR(100),
@SobrenomePrestador NVARCHAR(100),
@TelefonePrestador NVARCHAR(20),
@EmailPrestador NVARCHAR(150),
@GeneroPrestador CHAR(20),
@CidadePrestador CHAR(30),
@DataNascimentoPrestador DATE,
@AvaliacaoPrestador DECIMAL(10, 2),
@SenhaPrestador NVARCHAR(100)
AS
BEGIN
INSERT INTO Prestador (
nome_prestador,
sobrenome_prestador,
tel_prestador,
email_prestador,
genero_prestador,
cidade_prestador,
data_nasc_prestador,
avaliacao_prestador,
senha_prestador
)
VALUES (
@NomePrestador,
@SobrenomePrestador,
@TelefonePrestador,
@EmailPrestador,
@GeneroPrestador,
@CidadePrestador,
@DataNascimentoPrestador,
@AvaliacaoPrestador,
@SenhaPrestador
);
SELECT SCOPE_IDENTITY() AS NovoIdPrestador;
END; 


CREATE PROCEDURE sp_UpdateCliente
@NomeCliente NVARCHAR(100),
@SobrenomeCliente NVARCHAR(100),
@TelefoneCliente NVARCHAR(20),
@EmailCliente NVARCHAR(150),
@GeneroCliente CHAR(20),
@CidadeCliente CHAR(30),
@DataNascimentoCliente DATE,
@AvaliacaoCliente DECIMAL(10, 2),
@SenhaCliente NVARCHAR(100),
@IdCliente INT
as
begin
update Cliente 
set 
nome_cliente = @NomeCliente, 
sobrenome_cliente = @SobrenomeCliente, 
email_cliente = @EmailCliente, 
genero_cliente = @GeneroCliente,
tel_cliente = @TelefoneCliente, 
cidade_cliente = @CidadeCliente,
data_nasc_cliente = @DataNascimentoCliente, 
avaliacao_cliente = @AvaliacaoCliente,
senha_cliente = @SenhaCliente
where
id_cliente = @IdCliente
end;


CREATE PROCEDURE sp_UpdatePrestador
@NomePrestador NVARCHAR(100),
@SobrenomePrestador NVARCHAR(100),
@TelefonePrestador NVARCHAR(20),
@EmailPrestador NVARCHAR(150),
@GeneroPrestador CHAR(20),
@CidadePrestador CHAR(30),
@DataNascimentoPrestador DATE,
@AvaliacaoPrestador DECIMAL(10, 2),
@SenhaPrestador NVARCHAR(100),
@IdPrestador INT
as
begin
update Prestador
set 
nome_prestador = @NomePrestador, 
sobrenome_prestador= @SobrenomePrestador, 
email_prestador = @EmailPrestador, 
genero_prestador = @GeneroPrestador,
tel_prestador = @TelefonePrestador, 
cidade_prestador = @CidadePrestador,
data_nasc_prestador = @DataNascimentoPrestador, 
avaliacao_prestador = @AvaliacaoPrestador,
senha_prestador = @SenhaPrestador
where
id_prestador = @IdPrestador
end;


CREATE PROCEDURE sp_FiltrarClientes
    @NomeCliente NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        id_cliente,
        nome_cliente,
        sobrenome_cliente,
        tel_cliente,
        genero_cliente,
        email_cliente,
        data_nasc_cliente,
        cidade_cliente,
        avaliacao_cliente,
        senha_cliente
    FROM Cliente
    WHERE (@NomeCliente IS NULL OR nome_cliente LIKE '%' + @NomeCliente + '%');
END;

CREATE PROCEDURE sp_FiltrarPrestadores
    @NomePrestador NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        id_prestador,
        nome_prestador,
        sobrenome_prestador,
        tel_prestador,
        genero_prestador,
        email_prestador,
        data_nasc_prestador,
        cidade_prestador,
        avaliacao_prestador,
        senha_prestador
    FROM Prestador
    WHERE (@NomePrestador IS NULL OR nome_prestador LIKE '%' + @NomePrestador + '%');
END;


CREATE PROCEDURE sp_FiltrarClienteCidade
    @CidadeCliente NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Cliente
    WHERE (@CidadeCliente IS NULL OR cidade_cliente LIKE '%' + @CidadeCliente + '%')
    ORDER BY nome_cliente;
END;


CREATE PROCEDURE sp_FiltrarPrestadorCidade
    @CidadePrestador NVARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Prestador
    WHERE (@CidadePrestador IS NULL OR cidade_prestador LIKE '%' + @CidadePrestador + '%')
    ORDER BY nome_prestador;
END;


CREATE PROCEDURE sp_FiltrarClientesAvaliacao
@MinAvaliacao DECIMAL(10, 2),
@MaxAvaliacao DECIMAL(10, 2)
as
begin 
select * from Cliente where avaliacao_cliente>= @MinAvaliacao and avaliacao_cliente <= @MaxAvaliacao
end;


CREATE PROCEDURE sp_FiltrarPrestadorAvaliacao
@MinAvaliacao DECIMAL(10, 2),
@MaxAvaliacao DECIMAL(10, 2)
as
begin 
select * from Prestador where avaliacao_prestador>= @MinAvaliacao and avaliacao_prestador <= @MaxAvaliacao
end;


CREATE PROCEDURE dboDeletarCliente
@id_cliente INT
AS
BEGIN
DELETE Cliente WHERE id_cliente = @id_cliente
END; 


CREATE PROCEDURE dboDeletarPrestador
@id_prestador INT
AS
BEGIN
DELETE Prestador WHERE @id_prestador = @id_prestador
END; 


create procedure sp_SelecionarCliente
AS
BEGIN
    SELECT 
        *
    FROM Cliente;
END;


CREATE PROCEDURE sp_SelecionarComentarioCliente
AS
BEGIN
    SELECT * FROM comentario_Cliente;
END


CREATE PROCEDURE sp_InserirComentarioCliente
    @Texto NVARCHAR(500),
    @IdCliente INT,
    @DataCriacao DATE
AS
BEGIN
    INSERT INTO comentario_Cliente(texto_cliente, id_cliente, data_comentario_cliente)
    VALUES (@Texto, @IdCliente, @DataCriacao);
END


CREATE PROCEDURE sp_DeletarComentarioCliente
    @id_comentario_cliente INT
AS
BEGIN
    DELETE FROM comentario_Cliente
    WHERE id_comentario_cliente = @id_comentario_cliente;
END




CREATE PROCEDURE sp_SelecionarComentarioPrestador
AS
BEGIN
    SELECT * FROM comentario_Prestador;
END


CREATE PROCEDURE sp_InserirComentarioPrestador
    @TextoP NVARCHAR(500),
    @IdPrestador INT,
    @DataCriacaoP DATE
AS
BEGIN
    INSERT INTO comentario_Prestador(texto_prestador, id_prestador, data_comentario_prestador)
    VALUES (@TextoP, @IdPrestador, @DataCriacaoP);
END


CREATE PROCEDURE sp_DeletarComentarioPrestador
    @id_comentario_prestador INT
AS
BEGIN
    DELETE FROM comentario_Prestador
    WHERE id_comentario_prestador = @id_comentario_prestador;
END


CREATE PROCEDURE sp_InserirMensagem
    @texto_chat NVARCHAR(500),
    @id_cliente INT,
    @id_prestador INT
AS
BEGIN
    INSERT INTO Chat (texto_chat, data_envio, id_cliente, id_prestador)
    VALUES (@texto_chat, GETDATE(), @id_cliente, @id_prestador);
    SELECT SCOPE_IDENTITY() AS NovoIdMensagem;
END;

CREATE PROCEDURE sp_ObterMensagensChat
    @id_cliente INT,
    @id_prestador INT
AS
BEGIN
    SELECT *
    FROM Chat
    WHERE (id_cliente = @id_cliente AND id_prestador = @id_prestador)
    OR (id_cliente = @id_prestador AND id_prestador = @id_cliente)
    ORDER BY data_envio ASC;
END;


CREATE PROCEDURE sp_DeletarMensagem
    @id_chat INT
AS
BEGIN
    DELETE FROM Chat
    WHERE id_chat = @id_chat;
END;