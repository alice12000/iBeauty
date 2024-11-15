using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeServico
    {
        public int Id { get; set; }
        public string Servico { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public double Comissao { get; set; }
        public int Funcionario { get; set; }
        public int Retorno { get; set; }
        public int Duracao { get; set; }
        public double PrecoFinal { get; private set; }

        // Método construtor
        public CadastroDeServico(int id, string descricao, string categoria, double precoUnitario, double comissao, int funcionario, int retorno, int duracao, double precofinal, string servico)
        {
            Id = id;
            Servico = servico;
            Descricao = descricao;
            Categoria = categoria;
            PrecoUnitario = precoUnitario;
            Comissao = comissao;
            Funcionario = funcionario;
            Retorno = retorno;
            Duracao = duracao;
            PrecoFinal = precofinal;
        }


    }
}
