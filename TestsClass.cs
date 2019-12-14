using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using Variant4TestingLoremIpsum.PageObjects;

namespace Variant4TestingLoremIpsum.TestCases
{
    [TestClass]
    public class TestsClass
    {
        private static IWebDriver driver;
        private BusinessLogicLayer bll = new BusinessLogicLayer();

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }

        [DataTestMethod]
        [DataRow(10)]
        public void GenerateParagraphs (int number)
        {
            Assert.AreEqual(number, bll.GenerateParagraphs(number, driver)
                                       .CountParagraphsInText());
        }

        [DataTestMethod]
        [DataRow(500)]
        public void GenerateCharacters(int characters) 
        {
            Assert.AreEqual(characters, bll.GenerateCharacters(characters, driver)
                                           .CountCharacters());
        }

        [DataTestMethod]
        [DataRow(2, 1)]
        public void CountParagraphsContainingWord(int timesReload, int parameter) 
        {
            Assert.IsTrue(bll.CountWordsInParagraphs(timesReload, driver) >= parameter);
        }

        [TestMethod]
        [DataRow("рыба")]
        public void TextContainsWord(string word) 
        {
            Assert.IsTrue(bll.IfPageContainsWord(word, driver) > 0);
        }
    }
}
