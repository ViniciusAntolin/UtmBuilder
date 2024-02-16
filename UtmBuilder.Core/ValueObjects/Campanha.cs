using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Campanha : ValueObject
    {
        /// <summary>
        /// Gera uma nova campanha para uma URL.
        /// </summary>
        /// <param name="source">O referenciador (por exemplo, google, newsletter).</param>
        /// <param name="medium">Médio de marketing (por exemplo, cpc, banner, email).</param>
        /// <param name="name">Produto, código promocional ou slogan (por exemplo, spring_sale). Um dos nomes da campanha ou identificador da campanha é obrigatório.</param>
        /// <param name="id">O ID da campanha de anúncios.</param>
        /// <param name="term">Identifica as palavras-chave pagas.</param>
        /// <param name="content">Usado para diferenciar anúncios.</param>

        public Campanha(string source, string medium, string name, string? id = null, string? term = null, string? content = null)
        {
            CampanhaInvalidaException.ThrowIfNull(source, "Source é invalida");
            CampanhaInvalidaException.ThrowIfNull(medium, "Medium é invalida");
            CampanhaInvalidaException.ThrowIfNull(name, "Name é invalida");

            Source = source;
            Medium = medium;
            Name = name;
            Id = id;
            Term = term;
            Content = content;
        }

        /// <summary>
        /// O ID da campanha de anúncios.
        /// </summary>
        public string? Id { get; }

        /// <summary>
        /// O referenciador (por exemplo, google, newsletter).
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Médio de marketing (por exemplo, cpc, banner, email).
        /// </summary>
        public string Medium { get; }

        /// <summary>
        /// Produto, código promocional ou slogan (por exemplo, spring_sale). Um dos nomes da campanha ou identificador da campanha é obrigatório.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Identifica as palavras-chave pagas.
        /// </summary>
        public string? Term { get; }

        /// <summary>
        /// Usado para diferenciar anúncios.
        /// </summary>
        public string? Content { get; }
    }
}
