using System.Text.RegularExpressions;

namespace eAgendaMedica.Api.Config
{
    public static class StringExtensionMethod
    {
        public static string SepararPalavraPorMaiusculas(this string palavra)
        {
            string regex = @"([A-Z][a-z]*)";

            MatchCollection matches = Regex.Matches(palavra, regex);

            string separador = "";

            foreach (Match m in matches)
            {
                separador += m.Value + " ";
            }

            return separador;
        }
    }
}
