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
        //BBC variant 1 or 2

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
            BusinessLogicLayer loremIpsumPage = new BusinessLogicLayer();
            Assert.AreEqual(number, loremIpsumPage.GenerateParagraphs(number, driver)
                                                  .CountParagraphsInText());
        }

        [DataTestMethod]
        [DataRow(500)]
        public void GenerateCharacters(int characters) 
        {
            BusinessLogicLayer loremIpsumPage = new BusinessLogicLayer();
            Assert.AreEqual(characters, loremIpsumPage.GenerateCharacters(characters, driver)
                                                      .CountCharacters());
        }

        [DataTestMethod]
        [DataRow(2, 1)]
        public void CountParagraphsContainingWord(int timesReload, int parameter) 
        {
            BusinessLogicLayer loremIpsumPage = new BusinessLogicLayer();
            Assert.IsTrue(loremIpsumPage.CountWordsInParagraphs(timesReload, driver) >= parameter);
        }

        [TestMethod]
        [DataRow("рыба")]
        public void TextContainsWord(string word) 
        {
            BusinessLogicLayer loremIpsumPage = new BusinessLogicLayer();
            Assert.IsTrue(loremIpsumPage.IfPageContainsWord(word, driver) > 0);
        }
    }
}
