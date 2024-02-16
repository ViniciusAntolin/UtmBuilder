using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions
{
    public partial class UrlInvalidaException : Exception
    {
        private const string MensagemErroPadrao = "Url Invalida";
        public UrlInvalidaException(string mensagem = MensagemErroPadrao) : base(mensagem) {}
        public static void ThrowIfInvalid(string address, string message = MensagemErroPadrao)
        {
            if(string.IsNullOrEmpty(address))
                throw new UrlInvalidaException(message);

            if(!UrlRegex().IsMatch(address))
                throw new UrlInvalidaException(message);
        }

        [GeneratedRegex(
        "^(http|https):(\\/\\/www\\.|\\/\\/www\\.|\\/\\/|\\/\\/)[a-z0-9]+([\\-\\.]{1}[a-z0-9]+)*\\.[a-z]{2,5}(:[0-9]{1,5})?(\\/.*)?$|(http|https):(\\/\\/localhost:\\d*|\\/\\/127\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))(:[0-9]{1,5})?(\\/.*)?$")]
        private static partial Regex UrlRegex();
    }
}
