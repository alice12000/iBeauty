using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class CadastroUsuario
    {
        public int Id { get; set; } 
        public string Nome {get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public CadastroUsuario(int id, string nome, DateTime dataNascimento, string genero, string email, int telefone, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
