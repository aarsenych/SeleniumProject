using System;
using TechTalk.SpecFlow;
using Variant4TestingLoremIpsum.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace Variant4TestingLoremIpsum.SpecFlow
{
    [Binding]
    public class SpecFlowFeature3Steps
    {
        private HomePage homePage;
        private IWebDriver driver = new ChromeDriver();

        [Given(@"I have opened Home Page")]
        public void GivenIHaveOpenedHomePage()
        {
            homePage = new HomePage(driver);
        }
        
        [When(@"I generate Lorem Ipsum (.*) times and count the average result")]
        public double WhenIPressGenerateLoremIpsumTimesAndCountTheAverageResult(int p0)
        {
            int paragraphs_Sum = 0;
            for (int i = 0; i < p0; i++)
            {
                FeedPage feed = homePage.PressGenerateLoremIpsum();
                paragraphs_Sum += feed.CountParagraphsContainingWord("lorem");
                feed.GoBack();
            }
            return (double)paragraphs_Sum / p0;
        }
        
        [Then(@"the average result should not be less than (.*) paragraphs containing word Lorem in (.*) times reload")]
        public void ThenTheAverageResultShouldNotBeLessThanParagraphsContainingWordLoremInTimesReload(int p0, int p1)
        {
            Assert.IsTrue(WhenIPressGenerateLoremIpsumTimesAndCountTheAverageResult(p1) >= p0);
            driver.Quit();
        }
    }
}
