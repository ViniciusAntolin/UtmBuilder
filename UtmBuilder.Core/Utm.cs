using UtmBuilder.Core.ValueObjects;

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
    }
}
