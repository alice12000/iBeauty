using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class CadastroDeAnamneseCapilar
    {
        public int Id { get; set; }
        public string TipoCabelo { get; set; }
        public string Caracteristica { get; set; }
        public string PigmentoPredominante { get; set; }
        public string Observacao { get; set; }
        public string Comprimento { get; set; }
        public string Elasticidade { get; private set; }
        public string Espessura { get; set; }

        public CadastroDeAnamneseCapilar(int id, string tipoCabelo, string caracteristica, string pigmento, string observacao, string comprimento, string elasticidade, string espessura)
        {
            Id = id;
            TipoCabelo = tipoCabelo;
            Caracteristica = caracteristica;
            PigmentoPredominante = pigmento;
            Observacao = observacao;
            Comprimento = comprimento;
            Elasticidade = elasticidade;
            Espessura = espessura;
        }
    }
}
