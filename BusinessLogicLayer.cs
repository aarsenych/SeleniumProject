using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Variant4TestingLoremIpsum.PageObjects;

namespace Variant4TestingLoremIpsum
{
    public class BusinessLogicLayer
    {
        public FeedPage GenerateParagraphs(int paragraphs, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage.EnterNumberInInput(paragraphs);
            homePage.ClickParagraphButton();
            homePage.PressGenerateLoremIpsum();
            return new FeedPage(driver);
        }

        public FeedPage GenerateCharacters(int characters, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage.EnterNumberInInput(characters);
            homePage.ClickCharactersRadioButton();
            homePage.PressGenerateLoremIpsum();
            return new FeedPage(driver);
        }
        
        public FeedPage OpenFeedPage(IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage.PressGenerateLoremIpsum();
            FeedPage feedPage = new FeedPage(driver);
            return feedPage; 
        }

        public double CountWordsInParagraphs(int timesReload, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            int paragraphs_Sum = 0;
            for (int i = 0; i < timesReload; i++)
            {
                FeedPage feed = homePage.PressGenerateLoremIpsum();
                paragraphs_Sum += feed.CountParagraphsContainingWord("lorem");
                feed.GoBack();
            }
            return (double)paragraphs_Sum / timesReload;
        }

        public int IfPageContainsWord(string word, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickRussianLanguageButton();
            return  homePage.CountWordsInParagraphs(word);
        }
    }
}
