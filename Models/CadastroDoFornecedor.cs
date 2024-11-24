using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    public class CadastroDoFornecedor
    {     

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Website { get; set; }
        public Endereco Endereco { get; set; }
        public CadastroDoFornecedor(int id, string nome, string empresa, string cpfCnpj, string telefone, string website, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Empresa = empresa;
            CpfCnpj = cpfCnpj;
            Telefone = telefone;
            Website = website;
            Endereco = endereco;
        }
    }

}
