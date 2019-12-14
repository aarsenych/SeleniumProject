using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace Variant4TestingLoremIpsum.PageObjects
{
    public class FeedPage
    {
        private IWebDriver driver;

        private ReadOnlyCollection <IWebElement> paragraphsInText 
        {
            get
            {
                return driver.FindElements(By.XPath("//*[@id=\'lipsum\']/p"));
            }
        }

        private IWebElement LoremIpsumText
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"lipsum\"]/p"));
            }
        }

        public FeedPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int CountParagraphsInText() 
        {
            int paragraphsCount = paragraphsInText.Count;
            return paragraphsCount;
        }

        public int CountCharacters() 
        {
            string text = LoremIpsumText.Text;
            return text.Length;
        }

        public int CountParagraphsContainingWord(string word) 
        {
            ReadOnlyCollection<IWebElement> paragraphs = driver.FindElements(By.XPath("//p[contains(text(),\'" + word + "\')]"));
            return paragraphs.Count;
        }

        public void GoBack()
        {
            driver.Navigate().Back();
        }
    }
}
