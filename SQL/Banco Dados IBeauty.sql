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

insert into Endereco (rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end) values ('Flores', 'Centro', '1234', 'Apartamento 10', 'Ji-Parana', 'Rondonia (RO)', '12345678');
select * from Endereco;

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

insert into Cadastro (nome_cad, data_nascimento_cad, senha_cad, genero_cad, email_cad, telefone_cad, id_end_fk) values ('Tata', '03/04/2007', '123', 'Feminino', 'Tata', '69 99999-9999', 1);
select * from Cadastro;

create table Usuario(
id_usu int primary key auto_increment,
email_usu varchar(300),
senha_usu varchar(100),
id_cad_fk int,
foreign key(id_cad_fk) references Cadastro(id_cad)
);

insert into Usuario (email_usu, senha_usu, id_cad_fk) values ('Tata', '123', 1);
select * from Usuario;

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
tipo_cabelo_ancap varchar(50),
comprimento_ancap varchar(50),
caracteristica_ancap varchar(100),
elasticidade_ancap varchar(50),
pigmento_ancap varchar(50),
espessura_ancap varchar(50),
observacao_ancap text,
tingimento varchar(50),
alisamento  varchar(50),
relaxamento varchar(50),
escova_progressiva varchar(50),
escova varchar(50),
luzes varchar(50),
tinturas varchar(50),
alisantes varchar(50),
medicamentos varchar(50),
liq_permanentes varchar(50),
tratamentos_capilares varchar(50),
outro varchar(50)
);

create table Cliente(
id_cli int primary key auto_increment,
nome_cli varchar(200),
dataNascimento_cl varchar(45),
genero_cli varchar(100),
email_cli varchar(100),
celular_cli varchar(100),
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end),
id_ancap_fk int,
foreign key(id_ancap_fk) references AnamneseCapilar(id_ancap),
id_ancor_fk int,
foreign key(id_ancor_fk) references AnamneseCorporal(id_ancor)
);


SELECT * FROM Endereco;
SELECT * FROM Cadastro;
select * from Fornecedor;
select * from Produto;
select * from AnamneseCapilar;
ALTER TABLE Produto DROP COLUMN imagem_pro;
ALTER TABLE Produto DROP COLUMN categoria_pro;