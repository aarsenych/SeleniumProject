using System;
using TechTalk.SpecFlow;
using Variant4TestingLoremIpsum.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Variant4TestingLoremIpsum
{
    [Binding]
    public class SpecFlowFeature4Steps
    {
        private HomePage homePage;
        private IWebDriver driver = new ChromeDriver();

        [Given(@"Open the home page")]
        public void GivenOpenTheHomePage()
        {
            homePage = new HomePage(driver);
        }
        
        [Given(@"I choose russian language")]
        public void GivenIPressRussianLanguageButton()
        {
            homePage.ClickRussianLanguageButton();
        }

        [Then(@"the text should contain at least (.*) word  defined ""(.*)""")]
        public void ThenTheTextShouldContainAtLeastWordDefined(int p0, string p1)
        {
            int res = homePage.CountWordsInParagraphs(p1);
            Assert.IsTrue(res >= p0);
            driver.Quit();
        }
    }
    

}
