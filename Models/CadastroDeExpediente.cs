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
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Carga_horaria { get; set; }
        public string Salario { get; set; }

        public CadastroDeExpediente(int id, string mes, string nome, string ano, string carga_horaria, string salario)
        {
            Id = id;
            Mes = mes;
            Nome = nome;
            Ano = ano;
            Carga_horaria = carga_horaria;
            Salario = salario;
         
        }
    }
}
