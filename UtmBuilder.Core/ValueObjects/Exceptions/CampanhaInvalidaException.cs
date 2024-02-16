namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public class CampanhaInvalidaException : Exception
    {
        private const string MensagemErroPadrao = "Invalid UTM Parameter";
        public CampanhaInvalidaException(
            string mensagem = MensagemErroPadrao) : base(mensagem) { }

        public static void ThrowIfNull(string? item, string mensagem = MensagemErroPadrao)
        {
            if (string.IsNullOrEmpty(item))
                throw new CampanhaInvalidaException(mensagem);
        }
    }
}
