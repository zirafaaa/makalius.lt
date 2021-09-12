using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Page
{
    

    public class SearchResultPage : BasePage
    {
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".column-block-row"));
        string message => Driver.FindElement(By.CssSelector(".offer-description")).Text;
        public SearchResultPage(IWebDriver webDriver) : base(webDriver)  {}

        private IWebElement selectedSearchText => Driver.FindElement(By.CssSelector("div[class='category-heading text-uppercase'] h1"));
        public void VerifySearch(string travel)
        {
            Assert.AreEqual("PAIEŠKOS REZULTATAI:" + travel, selectedSearchText.Text, "Text is wrong");
        }
        public void VerifyIfTravelsIsInJamaika(string text)
        {           
                                  
            foreach(IWebElement result in results)
            {
                if (message.Contains(text)==true)
                {
                    Console.WriteLine("Text was found");
                } else
                {
                    Console.WriteLine("Text wasn't found");
                }
            }
        }
    }
}
