using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeAnamneseCorporal
    {
       
            public int Id { get; set; }
            public string PerguntaDepilacao { get; set; }
            public string RespostaDepilacao { get; set; }
            public string PerguntaAlergia { get; set; }
            public string RespostaAlergia { get; set; }
            public string PerguntaAlergia2 { get; set; }
            public string RespostaAlergia2 { get; set; }
            public string PerguntaProblema { get; set; }
            public string RespostaProblema { get; set; }
            public string PerguntaTratamento { get; set; }
            public string RespostaTratamento { get; set; }
            public string PerguntaGestante { get; set; }
            public string RespostaGestante { get; set; }
            public string PerguntaVasos { get; set; }
            public string TipoPele { get; set; }
            public string CeraQuente { get; set; }
            public string CeraFria { get; set; }
            public string Laser { get; set; }
            public string LuzPulsante { get; set; }
            public string Linha { get; set; }
            public string Axilas { get; set; }
            public string Virilha { get; set; }
            public string Costa { get; set; }
            public string Peito { get; set; }
            public string Braco { get; set; }
            public string CostaPerna { get; set; }
            public string Nadegas { get; set; }

        public CadastroDeAnamneseCorporal(
     int id,
     string perguntaDepilacao, string respostaDepilacao,
     string perguntaAlergia, string respostaAlergia,
     string perguntaAlergia2, string respostaAlergia2,
     string perguntaProblema, string respostaProblema,
     string perguntaTratamento, string respostaTratamento,
     string perguntaGestante, string respostaGestante,
     string perguntaVasos, string tipoPele,
     string ceraQuente, string ceraFria, string laser, string luzPulsante, string linha,
     string axilas, string virilha, string costa, string peito, string braco,
     string costaPerna, string nadegas)
        {

            Id = id;
            PerguntaDepilacao = perguntaDepilacao;
            RespostaDepilacao = respostaDepilacao;
            PerguntaAlergia = perguntaAlergia;
            RespostaAlergia = respostaAlergia;
            PerguntaAlergia2 = perguntaAlergia2;
            RespostaAlergia2 = respostaAlergia2;
            PerguntaProblema = perguntaProblema;
            RespostaProblema = respostaProblema;
            PerguntaTratamento = perguntaTratamento;
            RespostaTratamento = respostaTratamento;
            PerguntaGestante = perguntaGestante;
            RespostaGestante = respostaGestante;
            PerguntaVasos = perguntaVasos;
            TipoPele = tipoPele;
            CeraQuente = ceraQuente;
            CeraFria = ceraFria;
            Laser = laser;
            LuzPulsante = luzPulsante;
            Linha = linha;
            Axilas = axilas;
            Virilha = virilha;
            Costa = costa;
            Peito = peito;
            Braco = braco;
            CostaPerna = costaPerna;
            Nadegas = nadegas;
        }

    }
}