using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public int Unidades { get; set; }
        public double PrecoUnitario { get; set; }
        public double Comissao { get; set; }
        public string Descricao { get; set; }
        public double PrecoFinal { get; private set; }
        public byte[] Imagem { get; set; }

        //metodo construtor vazio
        public Produto()
        {

        }

        public Produto(string nome, int unidades, double precoUnitario, double comissao, string descricao, byte[] imagem)
        {
            Nome = nome;
            Unidades = unidades;
            PrecoUnitario = precoUnitario;
            Comissao = comissao;
            Descricao = descricao;
            Imagem = imagem;
            CalcularPrecoFinal();
        }

        // Calcula o preço final do produto
        private void CalcularPrecoFinal()
        {
            PrecoFinal = PrecoUnitario + (PrecoUnitario * (Comissao / 100));
        }
    }
}