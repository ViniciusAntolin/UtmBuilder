using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class CampanhaTests
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("source", "", "", true)]
        [DataRow("source", "medium", "", true)]
        [DataRow("source", "medium", "name", false)]
        public void TesteCampaing(string source, string medium, string name, bool exceptionEsperada)
        {
            if (exceptionEsperada)
            {
                try
                {
                    _ = new Campanha(source, medium, name);
                    Assert.Fail();
                }
                catch (CampanhaInvalidaException e)
                    when(e.Message == "Source é invalida")
                {
                    Assert.IsTrue(true);
                }
                catch (CampanhaInvalidaException e)
                    when(e.Message == "Medium é invalida")
                {
                    Assert.IsTrue(true);
                }
                catch (CampanhaInvalidaException e)
                    when(e.Message == "Name é invalida")
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                _ = new Campanha(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}
