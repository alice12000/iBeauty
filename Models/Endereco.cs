using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Endereco(int id, string rua, string bairro, int numero, string complemento, string cidade, string estado, string cep)
        {
            Id = id;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
        }
    }
}
