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
        public bool Tingimento { get; set; }
        public bool Alisamento { get; set; }
        public bool Relaxamento { get; set; }
        public bool EscovaProgressiva { get; set; }
        public bool Escova { get; set; }
        public bool Luzes { get; set; }
        public bool Tinturas { get; set; }
        public bool Alisantes { get; set; }
        public bool Medicamentos { get; set; }
        public bool LiqPermanentes { get; set; }
        public bool TratamentosCapilares { get; set; }
        public bool Outro { get; set; }

        // Construtor completo, usado ao criar uma nova instância da anamnese
        public CadastroDeAnamneseCapilar(int id, string tipoCabelo, string comprimento, string caracteristica,
                                         string elasticidade, string pigmento, string espessura, string observacao,
                                         bool tingimento, bool alisamento, bool relaxamento, bool escovaProgressiva,
                                         bool escova, bool luzes, bool tinturas, bool alisantes,
                                         bool medicamentos, bool liqPermanentes, bool tratamentosCapilares, bool outro)
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
            LiqPermanentes = liqPermanentes;
            TratamentosCapilares = tratamentosCapilares;
            Outro = outro;
        }
    }

}
