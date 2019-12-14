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
            homePage.EnterNumberInInput(paragraphs)
                    .ClickParagraphButton();
            FeedPage feedPage = homePage.PressGenerateLoremIpsum();
            return feedPage;
        }

        public FeedPage GenerateCharacters(int characters, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            homePage.EnterNumberInInput(characters)
                    .ClickCharactersRadioButton();
            FeedPage feedPage = homePage.PressGenerateLoremIpsum();
            return feedPage;
        }

        public double CountWordsInParagraphs(int timesReload, IWebDriver driver)
        {
            HomePage homePage = new HomePage(driver);
            int paragraphs_Sum = 0;
            for (int i = 0; i < timesReload; i++)
            {
                FeedPage feedPage = homePage.PressGenerateLoremIpsum();
                paragraphs_Sum += feedPage.CountParagraphsContainingWord("lorem");
                feedPage.GoBack();
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
