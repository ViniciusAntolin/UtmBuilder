using System.ComponentModel.Design;
using System.Text;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core
{
    public class Utm
    {
        public Utm(Url url, Campanha campanha)
        {
            Url = url;
            Campanha = campanha;
        }
        /// <summary>
        /// URL (Link do WebSite)
        /// </summary>
        public Url Url { get; }

        /// <summary>
        /// Detalhes da campanha
        /// </summary>
        public Campanha Campanha { get; init; } // permite que apenas no construtor seja setado valor

        public static implicit operator string(Utm utm) => utm.ToString();
        public static implicit operator Utm(string link)
        {
            var url = new Url(link);
            var segmentos = url.Address.Split('?');
            if (segmentos.Length == 1)
                throw new UrlInvalidaException("Nenhum segmento foi preenchido");
            var parametros = segmentos[1].Split('&');

            var source = parametros.ObterParametros("utm_source");
            var medium = parametros.ObterParametros("utm_medium");
            var name = parametros.ObterParametros("utm_campaign");
            var id = parametros.ObterParametros("utm_id");
            var term = parametros.ObterParametros("utm_term");
            var content = parametros.ObterParametros("utm_content");

            return new Utm(
                new Url(segmentos[0]),
                new Campanha(source, medium, name, id, term, content));
        }

        public override string ToString()
        {
            var segments = new List<string>();
            segments.AddSeNaoNulo("utm_source", Campanha.Source);
            segments.AddSeNaoNulo("utm_medium", Campanha.Medium);
            segments.AddSeNaoNulo("utm_campaign", Campanha.Name);
            segments.AddSeNaoNulo("utm_id", Campanha.Id);
            segments.AddSeNaoNulo("utm_term", Campanha.Term);
            segments.AddSeNaoNulo("utm_content", Campanha.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }
}
