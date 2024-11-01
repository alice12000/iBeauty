using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class Cadastro
    {
        public int Id { get; set; } 
        public string Nome {get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }

    }
}
