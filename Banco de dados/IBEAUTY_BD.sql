create database Ibeauty_bd;
use Ibeauty_bd;
#drop database Ibeauty_bd;
	
create table Endereco(
id_end int primary key auto_increment,
rua_end varchar(200),
bairro_end varchar(200),
numero_end int,
complemento_end varchar(200),
cidade_end varchar(200),
estado_end varchar(200),
cep_end varchar(200)
 
);

create table Cadastro(
id_cad int primary key auto_increment,
nome_cad varchar(300),
data_nascimento_cad varchar(100),
senha_cad varchar(100),
genero_cad varchar(100),
email_cad varchar(300),
telefone_cad varchar(100),
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end)
);

create table Usuario(
id_usu int primary key auto_increment,
email_usu varchar(300),
senha_usu varchar(100)
);

create table Produto(
id_pro int primary key auto_increment,
nome_pro varchar(200),
unidades_pro int,
descricao_pro varchar(300),
preco_unitario_pro double,
comissao_pro double,
preco_venda_pro double,
categoria_pro varchar(100),
imagem_pro blob
);

create table Fornecedor(
id_for int primary key auto_increment,
nome_for varchar(400),
empresa_for varchar(300),
cpfcnpj_for varchar(30),
telefone_for varchar(100),
website_for varchar(100),
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end)
);
 
 SELECT Fornecedor.nome_for, Fornecedor.empresa_for, Fornecedor.cpfcnpj_for, Fornecedor.telefone_for, Fornecedor.website_for, Fornecedor.id_end_fk,
 Endereco.id_end, Endereco.rua_end, Endereco.bairro_end, Endereco.numero_end, Endereco.complemento_end, Endereco.cidade_end, Endereco.estado_end, Endereco.cep_end 
 FROM Fornecedor INNER JOIN Endereco ON (Endereco.id_end = Fornecedor.id_end_fk);

create table Funcionario(
id_fun int primary key auto_increment, 
nome_fun varchar(300),
telefone_fun varchar(100),
genero_fun varchar(100),
email_fun varchar(400),
observacao_fun varchar(400),
data_nascimento_fun date,
expediente_fun varchar(200),
categoria_fun varchar(50),
acesso_fun varchar(30)
);

create table Servico(
id_ser int primary key auto_increment,
descricao_ser varchar(200),
preco_unitario_ser double,
comissao_ser double,
preco_venda_ser double,
duracao_ser time, 
retorno_ser int,
categoria_ser varchar(300),
id_fun_fk int,
foreign key(id_fun_fk) references Funcionario(id_fun)
);

create table Expediente(
id_exp int primary key auto_increment,
mes_exp varchar(30),
ano_exp int,
carga_horaria_exp int,
salario_exp double
);

create table AnamneseCapilar (
id_ancap int primary key auto_increment,
tipo_cabelo_ancap varchar(50) not null,
comprimento_ancap varchar(50),
caracteristica_ancap varchar(100),
elasticidade_ancap varchar(50),
pigmento_ancap varchar(50),
espessura_ancap varchar(50),
observacao_ancap text,
tingimento boolean default false,
alisamento  boolean default false,
relaxamento boolean default false,
escova_progressiva boolean default false,
escova boolean default false,
luzes boolean default false,
tinturas boolean default false,
alisantes boolean default false,
medicamentos boolean default false,
liq_permanentes boolean default false,
tratamentos_capilares text,
outro text
);
desc Cadastro;
create table Cliente(
id_cli int primary key auto_increment,
data_nascimento_cli date,
genero_cli varchar(300),
cpf_cli varchar(30),
email_cli varchar(400),
celular_cli int, 
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end),
id_cad_fk int, 
foreign key(id_cad_fk) references Cadastro(id_cad),
id_anc_fk int,
foreign key(id_anc_fk) references AnamneseCapilar(id_ancap)
);

SELECT * FROM Endereco;
SELECT * FROM Cadastro;
select * from Fornecedor;
select * from Produto;
select * from AnamneseCapilar;
ALTER TABLE Produto DROP COLUMN imagem_pro;
ALTER TABLE Produto DROP COLUMN categoria_pro;
select * from Funcionario;		
desc Servico;
select * from Servico;
alter table Servico add servico_ser varchar(300);
insert into Funcionario values(1, 'Alice', '99999999', 'feminino', 'alicero', 'nada', '2006-05-16', 'Nenhum', null, null);
DELETE FROM Servico;