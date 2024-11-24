using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDeExpediente
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public string CargaHoraria { get; set; }
        public string Salario { get; set; }
        public string NomeFuncionario { get; set; }
        public int IdFunc { get; set; }

        public CadastroDeExpediente(int id, string mes, string ano, string cargaHoraria, string salario, string nomeFuncionario, int idFunc)
        {
            Id = id;
            Mes = mes;
            Ano = ano;
            CargaHoraria = cargaHoraria;
            Salario = salario;
            NomeFuncionario = nomeFuncionario;
            IdFunc = idFunc;
        }
    }
}
