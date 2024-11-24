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
senha_usu varchar(100),
id_cad_fk int,
foreign key(id_cad_fk) references Cadastro(id_cad)
);

create table Produto(
id_pro int primary key auto_increment,
nome_pro varchar(200),
unidades_pro int,
descricao_pro varchar(300),
preco_unitario_pro double,
comissao_pro double,
preco_venda_pro double
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
 
create table Funcionario(
id_func int primary key auto_increment, 
nome_func varchar(300),
telefone_func varchar(100),
genero_func varchar(100),
email_func varchar(400),
observacao_func varchar(400),
data_nascimento_func varchar(100),
expediente_func varchar(200),
categoria_func varchar(50),
acesso_func varchar(30),
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end)
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
foreign key(id_fun_fk) references Funcionario(id_func)
);

create table Expediente(
id_exp int primary key auto_increment,
mes_exp varchar(30),
ano_exp int,
carga_horaria_exp int,
salario_exp double,
nome_funcionario varchar(100),
id_fun_fk int,
foreign key(id_fun_fk) references Funcionario(id_func)
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
create table AnamneseCorporal (
id_ancor int primary key auto_increment,
pergunta_depilacao varchar(50),
resposta_depilacao varchar(300),
pergunta_alergia varchar(50),
resposta_alergia varchar(300),
pergunta_alergia2 varchar(50),
resposta_alergia2 varchar(300),
pergunta_problema varchar(50),
resposta_problema varchar(300),
pergunta_tratamento varchar(50),
resposta_tratamento varchar(300),
pergunta_gestante varchar(50),
resposta_gestante varchar(200),
pergunta_vasos varchar(100),
tipo_pele varchar(100),
cera_quente varchar(20),
cera_fria varchar(20),
laser varchar(20),
luz_pulsante varchar(20),
linha varchar(20),
axilas varchar(20),
virilha varchar(20),
costa varchar(20),
peito varchar(20),
braco varchar(20),
costa_perna varchar(20),
nadegas varchar(20)
);

#drop table AnamneseCorporal;
#drop table Cliente;

create table Cliente(
id_cli int primary key auto_increment,
nome_cli varchar(100),
data_nascimento_cli varchar(100),
genero_cli varchar(300),
cpf_cli varchar(30),
email_cli varchar(400),
celular_cli varchar(30), 
id_end_fk int,
foreign key(id_end_fk) references Endereco(id_end),
id_ancap_fk int,
foreign key(id_ancap_fk) references AnamneseCapilar(id_ancap),
id_ancor_fk int,
foreign key(id_ancor_fk) references AnamneseCorporal(id_ancor)
);


alter table Servico add servico_ser varchar(300);
alter table Produto add categoria_pro varchar(300);
DESCRIBE Endereco;
select * from Endereco;
select * from AnamneseCapilar;
select * from AnamneseCorporal;
select * from Cliente;

INSERT INTO Endereco (id_end, rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end)
VALUES 
(1, 'Rua das Flores', 'Jardim Primavera', 123, 'Apartamento 101', 'São Paulo', 'SP', '01001-000'),
(2, 'Avenida Central', 'Centro', 45, 'Sala 200', 'Rio de Janeiro', 'RJ', '20001-000'),
(3, 'Rua dos Pinheiros', 'Pinheiros', 567, 'Casa', 'Belo Horizonte', 'MG', '30110-000');

-- Inserindo na tabela Cadastro
INSERT INTO Cadastro (nome_cad, data_nascimento_cad, senha_cad, genero_cad, email_cad, telefone_cad, id_end_fk)
VALUES 
('João Silva', '1990-08-15', 'senha123', 'Masculino', 'joao@gmail.com', '11999999999', 1),
('Maria Oliveira', '1985-05-20', 'senha456', 'Feminino', 'maria@gmail.com', '21988888888', 2),
('Carlos Pereira', '2000-11-10', 'senha789', 'Masculino', 'carlos@gmail.com', '31977777777', 3);

-- Inserindo na tabela Produto
INSERT INTO Produto (nome_pro, unidades_pro, descricao_pro, preco_unitario_pro, comissao_pro, preco_venda_pro, categoria_pro)
VALUES 
('Shampoo Profissional', 50, 'Shampoo hidratante de uso diário', 25.00, 5.00, 30.00, 'Cabelo'),
('Condicionador Nutritivo', 30, 'Condicionador para cabelos secos', 30.00, 6.00, 36.00, 'Cabelo'),
('Máscara Capilar', 20, 'Máscara de hidratação profunda', 50.00, 10.00, 60.00, 'Cabelo');

-- Inserindo na tabela Fornecedor
INSERT INTO Fornecedor (nome_for, empresa_for, cpfcnpj_for, telefone_for, website_for, id_end_fk)
VALUES 
('Fornecedor A', 'Empresa A', '12345678000101', '11987654321', 'www.empresaA.com.br', 1),
('Fornecedor B', 'Empresa B', '98765432000102', '21987654321', 'www.empresaB.com.br', 2),
('Fornecedor C', 'Empresa C', '56473829000103', '31987654321', 'www.empresaC.com.br', 3);

-- Inserindo na tabela Funcionario
INSERT INTO Funcionario (nome_func, telefone_func, genero_func, email_func, observacao_func, data_nascimento_func, expediente_func, categoria_func, acesso_func, id_end_fk)
VALUES 
('Alice Santos', '100.512.880-44', 'Feminino', 'alice@ibeauty.com', 'Ótima profissional', '1995-01-15', 'Seg-Sex', 'Cabelereira', 'Administrador', 1),
('Pedro Lima', '100.512.880-44', 'Masculino', 'pedro@ibeauty.com', 'Especialista em cortes', '1990-03-20', 'Seg-Sáb', 'Barbeiro', 'Usuário', 2),
('Julia Almeida', '100.512.880-44', 'Feminino', 'julia@ibeauty.com', 'Atenciosa e proativa', '1985-07-25', 'Ter-Sáb', 'Manicure', 'Usuário', 3);

-- Inserindo na tabela Servico
INSERT INTO Servico (descricao_ser, preco_unitario_ser, comissao_ser, preco_venda_ser, duracao_ser, retorno_ser, categoria_ser, id_fun_fk, servico_ser)
VALUES 
('Corte Feminino', 50.00, 10.00, 60.00, '00:30:00', 0, 'Cabelos', 1, 'Corte'),
('Corte Masculino', 40.00, 8.00, 48.00, '00:20:00', 0, 'Cabelos', 2, 'Corte'),
('Manicure Completa', 30.00, 5.00, 35.00, '00:40:00', 0, 'Unhas', 3, 'Manicure');

-- Inserindo na tabela Expediente
INSERT INTO Expediente (mes_exp, ano_exp, carga_horaria_exp, salario_exp, nome_funcionario, id_fun_fk)
VALUES 
('Janeiro', 2024, 160, 3000.00, 'Alice Santos', 1),
('Janeiro', 2024, 140, 2500.00, 'Pedro Lima', 2),
('Janeiro', 2024, 120, 2000.00, 'Julia Almeida', 3);

INSERT INTO AnamneseCapilar (
    tipo_cabelo_ancap, comprimento_ancap, caracteristica_ancap, elasticidade_ancap, 
    pigmento_ancap, espessura_ancap, observacao_ancap, tingimento, alisamento, relaxamento, 
    escova_progressiva, escova, luzes, tinturas, alisantes, medicamentos, 
    liq_permanentes, tratamentos_capilares, outro
)
VALUES 
('Cacheado', 'Longo', 'Seco', 'Boa', 'Castanho', 'Fina', 'Sem observações', 'Não', 'Não', 'Não', 
'Não', 'Não', 'Sim', 'Não', 'Não', 'Não', 
'Não', 'Sim', 'Nenhum'),
('Liso', 'Curto', 'Oleoso', 'Regular', 'Loiro', 'Média', 'Uso diário de shampoo específico', 'Sim', 'Não', 'Sim', 
'Não', 'Não', 'Não', 'Sim', 'Não', 'Não', 
'Não', 'Não', 'Hidratação semanal'),
('Ondulado', 'Médio', 'Normal', 'Ótima', 'Preto', 'Grossa', 'Sem histórico de procedimentos', 'Não', 'Sim', 'Não', 
'Sim', 'Não', 'Não', 'Não', 'Sim', 'Não', 
'Não', 'Sim', 'Produtos naturais');

-- Inserindo na tabela AnamneseCorporal
INSERT INTO AnamneseCorporal (
    pergunta_depilacao, resposta_depilacao, pergunta_alergia, resposta_alergia, 
    pergunta_alergia2, resposta_alergia2, pergunta_problema, resposta_problema, 
    pergunta_tratamento, resposta_tratamento, pergunta_gestante, resposta_gestante, 
    pergunta_vasos, tipo_pele, cera_quente, cera_fria, laser, luz_pulsante, linha, 
    axilas, virilha, costa, peito, braco, costa_perna, nadegas
)
VALUES 
('Já fez depilação?', 'Sim, frequentemente', 'Alergia a cera?', 'Não', 'Alergia a produtos químicos?', 'Não', 
'Problemas de pele?', 'Não', 'Tratamentos recentes?', 'Sim, hidratante para pele seca', 
'É gestante?', 'Não', 'Vasos aparentes?', 'Não', 'Normal', 'Sim', 'Não', 'Não', 'Não', 
'Sim', 'Sim', 'Não', 'Não', 'Não', 'Não', 'Não'),
('Já fez depilação?', 'Não', 'Alergia a cera?', 'Sim', 'Alergia a produtos químicos?', 'Sim', 
'Problemas de pele?', 'Sim', 'Tratamentos recentes?', 'Sim, pomada dermatológica', 
'É gestante?', 'Não', 'Vasos aparentes?', 'Sim', 'Oleosa', 'Não', 'Sim', 'Não', 'Não', 
'Não', 'Sim', 'Sim', 'Não', 'Não', 'Sim', 'Sim'),
('Já fez depilação?', 'Sim', 'Alergia a cera?', 'Não', 'Alergia a produtos químicos?', 'Não', 
'Problemas de pele?', 'Não', 'Tratamentos recentes?', 'Não', 
'É gestante?', 'Sim, no primeiro trimestre', 'Vasos aparentes?', 'Não', 'Mista', 'Sim', 'Não', 'Sim', 'Não', 
'Não', 'Não', 'Não', 'Não', 'Não', 'Sim', 'Não');

-- Inserindo na tabela Cliente
INSERT INTO Cliente (nome_cli, data_nascimento_cli, genero_cli, cpf_cli, email_cli, celular_cli, id_end_fk, id_ancap_fk, id_ancor_fk)
VALUES 
('Luiza Fernandes', '1993-04-15', 'Feminino', '12345678901', 'luiza@gmail.com', 11987654321, 1, 1, 1),
('Rafael Costa', '1988-08-20', 'Masculino', '98765432100', 'rafael@gmail.com', 21987654321, 2, 2, 2),
('Mariana Rocha', '2000-12-30', 'Feminino', '56473829100', 'mariana@gmail.com', 31987654321, 3, 3, 3);

select * from Produto;