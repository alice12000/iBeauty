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
            if (!ValidarCpfCnpj(cpfCnpj))
            {
                throw new ArgumentException("CPF ou CNPJ inválido.");
            }

            Id = id;
            Nome = nome;
            Empresa = empresa;
            CpfCnpj = cpfCnpj;
            Telefone = telefone;
            Website = website;
            Endereco = endereco;
        }
        private static bool ValidarCpf(string cpf)
        {
            // Remove qualquer caractere não numérico
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
                return false;

            // Cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int primeiroDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int segundoDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            // Verifica se os dígitos verificadores estão corretos
            return cpf[9] - '0' == primeiroDigitoVerificador && cpf[10] - '0' == segundoDigitoVerificador;
        }

        private static bool ValidarCnpj(string cnpj)
        {
            // Remove qualquer caractere não numérico
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Cálculo do primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * multiplicador1[i];

            int primeiroDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            // Cálculo do segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * multiplicador2[i];

            int segundoDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            // Verifica se os dígitos verificadores estão corretos
            return cnpj[12] - '0' == primeiroDigitoVerificador && cnpj[13] - '0' == segundoDigitoVerificador;
        }

        public static bool ValidarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            if (cpfCnpj.Length == 11)
                return ValidarCpf(cpfCnpj);
            else if (cpfCnpj.Length == 14)
                return ValidarCnpj(cpfCnpj);

            return false;
        }

    }

}
