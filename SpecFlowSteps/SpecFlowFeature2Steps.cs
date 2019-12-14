using System;
using TechTalk.SpecFlow;
using Variant4TestingLoremIpsum.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Variant4TestingLoremIpsum
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        private HomePage homePage;
        private FeedPage feedPage;
        private IWebDriver driver = new ChromeDriver();

        [Given(@"I have opened homepage")]
        public void GivenIHaveOpenedHomepage()
        {
            homePage = new HomePage(driver);
        }
        
        [Given(@"I have chosen (.*) characters to generate")]
        public void GivenIHaveChosenCharactersToGenerate(int p0)
        {
            homePage.EnterNumberInInput(p0);
            homePage.ClickCharactersRadioButton();
        }
        
        [When(@"I generate Lorem Ipsum")]
        public void WhenIPressGenerate()
        {
            feedPage = homePage.PressGenerateLoremIpsum();
        }
        
        [Then(@"the result should be (.*) characters")]
        public void ThenTheResultShouldBeCharacters(int p0)
        {
            Assert.AreEqual(feedPage.CountCharacters(), p0);
            driver.Quit();
        }
    }
}
