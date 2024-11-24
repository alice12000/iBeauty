using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeCategoria
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int Profissional { get; set; }

        public CadastroDeCategoria(string nome, string tipo, int profissional)
        {
            Nome = nome;
            Tipo = tipo;
            Profissional = profissional;
        }
    }
}
