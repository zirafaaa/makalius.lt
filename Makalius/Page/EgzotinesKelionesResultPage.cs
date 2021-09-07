using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Makalius.Page
{
    public class EgzotinesKelionesResultPage : BasePage
    {
        
        private IWebElement orderBySausis => Driver.FindElement(By.XPath("//div[contains(@class,'sidebar pull-right hidden-xs')]//a[contains(@class,'active')]"));
        private IWebElement moveToSausis => Driver.FindElement(By.XPath("//div[contains(@class,'sidebar pull-right hidden-xs')]//a[contains(@class,'active')]"));
        
        IReadOnlyCollection<IWebElement> results = Driver.FindElements(By.CssSelector(".offer"));
        
        public EgzotinesKelionesResultPage(IWebDriver webdriver) : base(webdriver) { }
    

        public void OrderBySausisTravel()
        {
            Thread.Sleep(2000);
            
            //Actions action = new Actions(Driver);
            
            //action.MoveToElement(moveToSausis);
            //action.Build().Perform();
            orderBySausis.Click();
           
            IWebElement firstResultElement = results.ElementAt(0);

        }
        
       
    }
}
