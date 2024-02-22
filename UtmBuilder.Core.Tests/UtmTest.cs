using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests
{
    [TestClass]
    public class UtmTest
    {
        private const string Result = "https://balta.io/" +
                                  "?utm_source=src" +
                                  "&utm_medium=med" +
                                  "&utm_campaign=nme" +
                                  "&utm_id=id" +
                                  "&utm_term=ter" +
                                  "&utm_content=ctn";

        private readonly Url _url = new("https://balta.io/");

        private readonly Campanha _campanha = new("src",
                                                  "med",
                                                  "nme",
                                                  "id",
                                                  "ter",
                                                  "ctn");


        [TestMethod]
        public void Deve_retornar_uma_url_do_utm()
        {
            var utm = new Utm(_url, _campanha);
            Assert.AreEqual(Result, utm.ToString());
            Assert.AreEqual(Result, (string)utm);
        }

        [TestMethod]
        public void Deve_retornar_um_utm_da_url()
        {
            Utm utm = Result;
            Assert.AreEqual("https://balta.io/", utm.Url.Address);
            Assert.AreEqual("src", utm.Campanha.Source);
            Assert.AreEqual("med", utm.Campanha.Medium);
            Assert.AreEqual("nme", utm.Campanha.Name);
            Assert.AreEqual("id", utm.Campanha.Id);
            Assert.AreEqual("ter", utm.Campanha.Term);
            Assert.AreEqual("ctn", utm.Campanha.Content);
        }
    }
}
