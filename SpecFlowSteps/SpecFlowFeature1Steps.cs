using System;
using TechTalk.SpecFlow;
using Variant4TestingLoremIpsum.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Variant4TestingLoremIpsum.SpecFlow
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private HomePage homePage;
        private FeedPage feedPage;
        private IWebDriver driver = new ChromeDriver();

        [Given(@"I have opened home page")]
        public void GivenIHaveOpenedHomePage()
        {
            homePage = new HomePage(driver);
        }
        
        [Given(@"I have chosen (.*) paragraphs to generate")]
        public void GivenIHaveChosenPagarpaphsToGenerate(int p0)
        {
            homePage.EnterNumberInInput(p0);
            homePage.ClickParagraphButton();
        }
        
        [When(@"I generate paragraphs")]
        public void WhenIPressGenerateButton()
        {
           feedPage = homePage.PressGenerateLoremIpsum();
        }
        
        [Then(@"the result should be (.*) paragraphs generated")]
        public void ThenTheResultShouldBeParagraphsGenerated(int p0)
        {
            Assert.AreEqual(p0, feedPage.CountParagraphsInText());
            driver.Quit();
        }
    }
}
