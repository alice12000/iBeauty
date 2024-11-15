using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Unidades { get; set; }
        public double PrecoUnitario { get; set; }
        public double Comissao { get; set; }
        public string Descricao { get; set; }
        public double PrecoFinal { get; private set; }


        public CadastroDeProduto(int id, string nome, int unidades, string descricao, double precoUnitario, double comissao, double precoVenda)
        {
            Id = id;
            Nome = nome;
            Unidades = unidades;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Comissao = comissao;
            PrecoFinal = precoVenda;
        }

    }
}