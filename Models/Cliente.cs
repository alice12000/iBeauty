using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class Cliente
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string EnderecoCliente { get; set; }
        public Cliente(string nomeCompleto, DateTime dataNascimento, string genero, string email, string cpf, string celular)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Genero = genero;
            Email = email;
            CPF = cpf;
            Celular = celular;
        }

        public Cliente()
        {

        }

    }

}
