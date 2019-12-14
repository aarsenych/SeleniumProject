using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
//using DotNetSeleniumExtras.PageObjects;



namespace Variant4TestingLoremIpsum.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private IWebElement NumberInput 
        { 
            get 
            {
                return driver.FindElement(By.XPath("//input[@id='amount']"));
            }      
        }

        private IWebElement ParagraphButton 
        { 
            get
            {
                return driver.FindElement(By.XPath("//input[@id=\'paras\']"));
            }
        }

        private IWebElement GenerateLoremIpsum
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@id=\'generate\']"));
            }
        }

        private IWebElement CharactersRadioButton 
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@id=\'bytes\']"));
            }
        }

        private IWebElement RussianLanguageButton
        {
            get
            {
                return driver.FindElement(By.XPath("//div[@id=\"Languages\"]/a[@class=\"ru\"]"));
            }
        }


        public HomePage(IWebDriver driver) 
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
        }

        public void ClickCharactersRadioButton()
        {
            CharactersRadioButton.Click();
        }

        public void EnterNumberInInput(int number) 
        {
            NumberInput.Clear();
            NumberInput.SendKeys(number.ToString());
        }

        public void ClickParagraphButton()
        {
            ParagraphButton.Click();   
        }

        public void ClickRussianLanguageButton() 
        {
            RussianLanguageButton.Click();
        }

        public FeedPage PressGenerateLoremIpsum()
        {
            GenerateLoremIpsum.Click();
            return new FeedPage(driver);
        }

        public int CountWordsInParagraphs(string word)
        {
            ReadOnlyCollection<IWebElement> words = driver.FindElements(By.XPath("//p[contains(text(),\'" + word + "\')]"));
            return words.Count;
        }
    }
}
