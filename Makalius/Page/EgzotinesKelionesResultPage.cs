using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Makalius.Page
{
    public class EgzotinesKelionesResultPage : BasePage
    {
        
        private IWebElement orderByVasaris => Driver.FindElement(By.XPath("//div[contains(@class,'content clearfix sides is-category-content')]//div[3]//ul[1]//li[3]"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".offer"));
        
        public EgzotinesKelionesResultPage(IWebDriver webdriver) : base(webdriver) { }
    

        public void OrderByVasaris()
        {
            
            orderByVasaris.Click();        
           

        }
        public void VerifyTravel(string month)
        {
            IWebElement firstResultElement = results.ElementAt(4);
            string firstPaskutinesMinTravel = firstResultElement.FindElement(By.CssSelector(".date-interval")).Text; 
           Assert.AreEqual(month, firstPaskutinesMinTravel, "Travel is wrong");
            
        }             
        
       
    }
}
