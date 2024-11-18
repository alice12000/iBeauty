using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeAnamneseCapilar
    {
        public int Id { get; set; }
        public string TipoCabelo { get; set; }
        public string Comprimento { get; set; }
        public string Caracteristica { get; set; }
        public string Elasticidade { get; set; }
        public string Pigmento { get; set; }
        public string Espessura { get; set; }
        public string Observacao { get; set; }

        public string Tingimento { get; set; }
        public string Alisamento { get; set; }
        public string Relaxamento { get; set; }
        public string EscovaProgressiva { get; set; }
        public string Escova { get; set; }
        public string Luzes { get; set; }

        public string Tinturas { get; set; }
        public string Alisantes { get; set; }
        public string Medicamentos { get; set; }
        public string LiquidosPermanentes { get; set; }
        public string TratamentosCapilares { get; set; }
        public string Outro { get; set; }

        public CadastroDeAnamneseCapilar(int id, string tipoCabelo, string comprimento, string caracteristica, string elasticidade, string pigmento, string espessura, string observacao, string tingimento, string alisamento, string relaxamento, string escovaProgressiva, string escova, string luzes, string tinturas, string alisantes, string medicamentos, string liquidosPermanentes, string tratamentosCapilares, string outro)
        {
            Id = id;
            TipoCabelo = tipoCabelo;
            Comprimento = comprimento;
            Caracteristica = caracteristica;
            Elasticidade = elasticidade;
            Pigmento = pigmento;
            Espessura = espessura;
            Observacao = observacao;
            Tingimento = tingimento;
            Alisamento = alisamento;
            Relaxamento = relaxamento;
            EscovaProgressiva = escovaProgressiva;
            Escova = escova;
            Luzes = luzes;
            Tinturas = tinturas;
            Alisantes = alisantes;
            Medicamentos = medicamentos;
            LiquidosPermanentes = liquidosPermanentes;
            TratamentosCapilares = tratamentosCapilares;
            Outro = outro;
        }
    }
}
