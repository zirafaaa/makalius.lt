using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Page
{
    public class Iki100eurPage : BasePage
    {
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".offer"));
        private IWebElement travelPrice => Driver.FindElement(By.CssSelector("body > div:nth-child(3) > div:nth-child(3) > div:nth-child(6) > div:nth-child(1) > div:nth-child(2) > div:nth-child(5) > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > strong:nth-child(1)"));
        private IWebElement placiauButton => Driver.FindElement(By.CssSelector("#category-content > div:nth-child(5) > div.offer-description.clearfix > div.button-holder.pull-right > a.btn.text-uppercase.btn-primary.hidden-xs"));
        public Iki100eurPage(IWebDriver webdriver) : base(webdriver) { }
        public void VerifyIf(double suma)
        {
            double allPrice = double.Parse(travelPrice.Text.Replace("€",""));
            foreach (IWebElement result in results) { 
            if (suma <= allPrice)
            {
                Console.WriteLine("pasieke");
            } else
            {
                Console.WriteLine("susimovei");
            }
            }
        }
        public void ChooseTravel(string price)
        {
            IWebElement resultElement = results.ElementAt(4);
            
            Assert.AreEqual(price, travelPrice.Text, "Travel is wrong");
            if (travelPrice.Equals(price)) {
                placiauButton.Click();
            } else
            {
                Console.WriteLine("Nieko gero");
            }

        }
    }
}
