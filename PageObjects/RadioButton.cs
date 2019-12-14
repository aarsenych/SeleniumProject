using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Variant4TestingLoremIpsum.PageObjects;

namespace Variant4TestingLoremIpsum.PageObjects1
{
    class RadioButton
    {
        private IWebDriver driver;
        private IWebElement NumberInput => driver.FindElement(By.XPath("//input[@id='amount']"));

        private IWebElement ParagraphButton => driver.FindElement(By.XPath("//input[@id=\'paras\']"));

        private IWebElement GenerateLoremIpsum => driver.FindElement(By.XPath("//input[@id=\'generate\']"));

        private IWebElement CharactersRadioButton => driver.FindElement(By.XPath("//input[@id=\'bytes\']"));

        public RadioButton(IWebDriver driver)
        {
            this.driver = driver;
        }

        public RadioButton ClickCharactersRadioButton()
        {
            CharactersRadioButton.Click();
            return this;
        }

        public RadioButton EnterNumberInInput(int number)
        {
            NumberInput.Clear();
            NumberInput.SendKeys(number.ToString());
            return this;    
        }

        public RadioButton ClickParagraphButton()
        {
            ParagraphButton.Click();
            return this;
        }

        public FeedPage PressGenerateLoremIpsum()
        {
            GenerateLoremIpsum.Click();
            return new FeedPage(driver);
        }
    }
}
