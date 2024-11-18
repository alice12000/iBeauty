using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IBeauty.Models
{
    public class Verificacoes
    {
        public Verificacoes() { }
        public bool ValidarCpf(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            if (cpf.Distinct().Count() == 1)
                return false;
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int primeiroDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            int segundoDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);
            return cpf[9] - '0' == primeiroDigitoVerificador && cpf[10] - '0' == segundoDigitoVerificador;
        }

        public bool ValidarCnpj(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * multiplicador1[i];

            int primeiroDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * multiplicador2[i];

            int segundoDigitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);

            return cnpj[12] - '0' == primeiroDigitoVerificador && cnpj[13] - '0' == segundoDigitoVerificador;
        }
        public bool ValidarEmail(string email)
        {
            if ((email == null) || (email.Length < 4))
                return false;

            var partes = email.Split('@');
            if (partes.Length < 2) return false;

            var pre = partes[0];

            if (pre.Length == 0) return false;

            var validadorPre = new Regex("^[a-zA-Z0-9_.-/+]+$");

            if (!validadorPre.IsMatch(pre))
                return false;

            // gmail.com, outlook.com, terra.com.br, etc.
            var partesDoDominio = partes[1].Split('.');
            if (partesDoDominio.Length < 2) return false;

            var validadorDominio = new Regex("^[a-zA-Z0-9-]+$");
            for (int indice = 0; indice < partesDoDominio.Length; indice++)
            {
                var parteDoDominio = partesDoDominio[indice];

                // Evitando @gmail...com
                if (parteDoDominio.Length == 0) return false;

                if (!validadorDominio.IsMatch(parteDoDominio))
                    return false;
            }

            return true;
        }
    }
}