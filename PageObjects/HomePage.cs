
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Variant4TestingLoremIpsum.PageObjects1;

namespace Variant4TestingLoremIpsum.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private RadioButton radioButton;
        private IWebElement RussianLanguageButton => driver.FindElement(By.XPath("//div[@id=\"Languages\"]/a[@class=\"ru\"]"));

        public HomePage(IWebDriver driver) 
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("https://www.lipsum.com/");
            radioButton = new RadioButton(driver);
        }

        public HomePage ClickCharactersRadioButton()
        {
            radioButton.ClickCharactersRadioButton();
            return this;
        }

        public HomePage EnterNumberInInput(int number) 
        {
            radioButton.EnterNumberInInput(number);
            return this;
        }

        public HomePage ClickParagraphButton()
        {
            radioButton.ClickParagraphButton();
            return this;
        }

        public void ClickRussianLanguageButton() 
        {
            RussianLanguageButton.Click();
        }

        public FeedPage PressGenerateLoremIpsum()
        {
            radioButton.PressGenerateLoremIpsum();
            return new FeedPage(driver);
        }

        public int CountWordsInParagraphs(string word)
        {
            ReadOnlyCollection<IWebElement> words = driver.FindElements(By.XPath("//p[contains(text(),\'" + word + "\')]"));
            return words.Count;
        }
    }
}
