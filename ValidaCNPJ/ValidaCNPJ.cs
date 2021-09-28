using System.Linq;

namespace ValidaCNPJ
{
    public static class ValidaCNPJ
    {
        public static bool Validate(string cnpj)
        {
            var firstMultiplier = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var secondMultiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum, rest;
            string digit, cnpjAux;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14 || !long.TryParse(cnpj, out var parsed))
                return false;
            if (cnpjInvalid.Contains(cnpj))
                return false;
            cnpjAux = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
                sum += int.Parse(cnpjAux[i].ToString()) * firstMultiplier[i];
            rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;
            digit = rest.ToString();
            cnpjAux = cnpjAux + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(cnpjAux[i].ToString()) * secondMultiplier[i];
            rest = (sum % 11);
            rest = rest < 2 ? 0 : 11 - rest;
            digit = digit + rest;
            return cnpj.EndsWith(digit);
        }
        private static readonly string[] cnpjInvalid =
        {
            "00000000000000", "11111111111111", "22222222222222", "33333333333333",
            "44444444444444", "55555555555555", "66666666666666", "77777777777777",
            "88888888888888", "99999999999999",
        };
    }
}
