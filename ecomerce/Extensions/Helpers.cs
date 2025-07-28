using Microsoft.CodeAnalysis.Options;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Ecomerce.Extensions
{
    public static class Helpers
    {

        public static string FormatarCep(string cep)
        {
            if (cep.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return Convert.ToUInt64(cep).ToString(@"00\.000\-000");
            }
        }

        public static string DesformatarCep(string cep)
        {
            if (cep.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return cep.Replace(".", "").Replace("-", "");
            }
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", "");
        }

        public static string OnlyNumbers(string str)
        {
            return Regex.Replace(str, "[^0-9]+", "");
        }

        public static string OnlyLetters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z]+", "");
        }

        public static string OnlyLettersAndSpaces(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z ]+", "");
        }

        public static string OnlyNumbersAndLetters(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z]+", "");
        }

        public static string OnlyNumbersAndLettersAndSpaces(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z ]+", "");
        }

        public static string OnlyNumbersAndLettersAndSpacesAndSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^0-9a-zA-Z ]+", "");
        }

        /* Para formatar telefones no formato 64999998888 com 11 caracteres */
        public static string FormatCellPhone(string cell)
        {
            if (cell.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return Convert.ToUInt64(cell).ToString(@"(00) 0 0000-0000");
            }
            
        }

        /* Para formatar telefones no formato 64999998888 com 10 caracteres */
        public static string FormatPhone(string cell)
        {
            if (cell.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return Convert.ToUInt64(cell).ToString(@"(00) 0000-0000");
            }
        }

        public static string DesformatarTelefone(string telefone)
        {
            if(telefone.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                // Remove todos os caracteres não numéricos do número de telefone
                return Regex.Replace(telefone, @"\D", "");
            }            
        }

        public static string DesformatarCpfCnpj(string documento)
        {
            if (documento.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                return documento.Replace(".", "").Replace("-", "").Replace("/", "").Replace("-", "");
            }
            
        }

        /// <summary>
        /// Validação se é um CPF ou um CNPJ pela quantidade de caracteres.
        /// </summary>
        /// <param valor="00000000000">Valida se é um CPF (11) ou um CNPJ(14) e precisa estar desformatado para que seja possivel passar pela validação, para desformatar utilize a classe Helper de Extensions.</param>        
        /// <returns>true se for um CPF/CNPJ, caso não tenha 11 ou 14 caracteres é retornado false</returns>
        public static bool IsCpfCnpj(string valor)
        {
            if (valor.Length == 11)
            {
                return true;
            }

            else if (valor.Length == 14)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retorna o tipo de pessoa para uso em locais da Aplicação
        /// </summary>
        /// <param documento="00000000000">Valida se é um CPF ou um CNPJ.</param>        
        /// <returns>O tipo em formato de string.</returns>
        public static string TipoPessoa(string documento)
        {
            if (documento.Length == 11)
            {
                return "CPF (FÍSICA)";
            }
            else if (documento.Length == 14)
            {
                return "CNPJ (JURIDICA)";
            }
            else
            {
                return "";
            }
        }

        public static string FormatarCpfCnpj(string? valor)
        {
            if (valor.IsNullOrEmpty())
            {
                return "";
            }
            else
            {
                if (valor.Length == 11)
                {
                    return Convert.ToUInt64(valor).ToString(@"000\.000\.000\-00");
                }
                else if (valor.Length == 14)
                {
                    return Convert.ToUInt64(valor).ToString(@"00\.000\.000\/0000\-00");
                }
                else
                {
                    return "";
                }
            }            
        }        
    }
}
