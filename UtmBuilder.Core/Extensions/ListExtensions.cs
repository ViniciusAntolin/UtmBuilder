namespace UtmBuilder.Core.Extensions
{
    public static class ListExtensions
    {
        public static void AddSeNaoNulo(this List<string> list, string key, string? value)
        {
            if (!string.IsNullOrEmpty(value))
                list.Add($"{key}={value}");
        }

        public static string ObterParametros(this IEnumerable<string> parametros, string prefixo)
        {
            return parametros.Where(x => x.StartsWith(prefixo)).FirstOrDefault("").Split('=')[1];
        }
    }
}
