using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public CadastroUsuario(int id, string nome, string dataNascimento, string senha, string genero, string email, string telefone, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Senha = senha;
            Genero = genero;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
