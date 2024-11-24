using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public Endereco Endereco { get; set; }
        public CadastroDeAnamneseCapilar AnamneseCapilar { get; set; }
        public CadastroDeAnamneseCorporal AnamneseCorporal { get; set; }

        public Cliente(int id, string nome, string dataNascimento, string genero, string email, string cPF, string celular, Endereco endereco, CadastroDeAnamneseCapilar anamneseCapilar, CadastroDeAnamneseCorporal anamneseCorporal)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            Email = email;
            CPF = cPF;
            Celular = celular;
            Endereco = endereco;
            AnamneseCapilar = anamneseCapilar;
            AnamneseCorporal = anamneseCorporal;
        }
    }

}
