using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeFuncionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public string DataNascimento { get; set; }
        public string Expediente { get; set; }
        public string Categoria { get; set; }
        public Endereco Endereco { get; set; }
        public CadastroDeFuncionario(int id, string nome, string telefone, string genero, string email, string observacao, string dataNascimento, string expediente, string categoria, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Genero = genero;
            Email = email;
            Observacao = observacao;
            DataNascimento = dataNascimento;
            Expediente = expediente;
            Categoria = categoria;
            Endereco = endereco;
        }
    }
}
