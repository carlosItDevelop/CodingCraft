using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CpfCnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;
            string cpfOuCnpj = value.ToString().Replace(".", "").Replace("-", "").Replace("/", "");
            switch (cpfOuCnpj.Length)
            {
                case 11:
                    return ValidarCpf(cpfOuCnpj);
                case 14:
                    return ValidarCnpj(cpfOuCnpj);
            }

            return new ValidationResult("O valor não parece ser um CPF ou CNPJ. Um CPF deve ter 11 dígitos e um CNPJ, 14 dígitos, todos numéricos, sem contar caracteres de separação.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpfTentado"></param>
        /// <returns></returns>
        private ValidationResult ValidarCpf(string cpfTentado)
        {
            int soma = 0, resto = 0;
            string digito;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpfTentado.Length != 11)
                return new ValidationResult("CPF Inválido.");

            if (Convert.ToUInt64(cpfTentado) % 11111111111 == 0)
                return new ValidationResult("CPF Inválido.");

            string tempCpf = cpfTentado.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cpfTentado.EndsWith(digito))
                return null;
            else
                return new ValidationResult("CPF Inválido.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpjTentado"></param>
        /// <returns></returns>
        private ValidationResult ValidarCnpj(string cnpjTentado)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;

            string digito, tempCnpj;

            if (cnpjTentado.Length != 14)
                return new ValidationResult("CNPJ Inválido.");

            tempCnpj = cnpjTentado.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cnpjTentado.EndsWith(digito))
                return null;
            else
                return new ValidationResult("CNPJ Inválido.");
        }

        public override string FormatErrorMessage(string name)
        {
            return name;
        }
    }
}
