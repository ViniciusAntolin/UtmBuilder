using System.Text.RegularExpressions;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        public Url(string address)
        {
            Address = address;
            UrlInvalidaException.ThrowIfInvalid(Address);
        }

        public string Address { get; }
    }
}
