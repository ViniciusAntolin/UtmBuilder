using System.Data;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string UrlInvalida = "Banana";
        private const string UrlValida = "https://balta.io";

        [TestMethod]
        public void Dado_uma_url_invalida_deve_retornar_uma_excecao()
        {
            try
            {
                var url = new Url(address: UrlInvalida);
                Assert.Fail();
            }
            catch (UrlInvalidaException)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(UrlInvalidaException))]
        public void Dado_uma_url_invalida_deve_retornar_uma_excecao_forma2()
        {
            new Url(address: UrlInvalida);
        }

        [TestMethod]
        public void Nao_deve_retornar_exececao_quando_url_for_valida()
        {
            _ = new Url(address: UrlValida);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow(" ", true)]
        [DataRow("Banana", true)]
        [DataRow("Teste", true)]
        [DataRow("https://balta.io", true)]
        public void Nao_deve_retornar_exececao_quando_url_for_valida_dataRow(string link, bool exceptionEsperada)
        {
            if (exceptionEsperada)
            {
                try
                {
                    _ = new Url(address: UrlInvalida);
                    Assert.Fail();
                }
                catch (UrlInvalidaException)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                _ = new Url(address: UrlValida);
                Assert.IsTrue(true);
            }
        }
    }
}
