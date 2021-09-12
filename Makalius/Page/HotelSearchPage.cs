using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Makalius.Page
{
    public class HotelSearchPage : BasePage
    {
        private IWebElement cookiesButton => Driver.FindElement(By.CssSelector(".cc-btn.cc-dismiss"));
        private IWebElement cityInput => Driver.FindElement(By.Id("HotelsSearchDestination"));
        private IWebElement checkInHotel => Driver.FindElement(By.Id("HotelsSearchCheckInVisual"));
        private IWebElement checkOutHotel => Driver.FindElement(By.Id("HotelsSearchCheckOutVisual"));
        private SelectElement dropdown => new SelectElement(Driver.FindElement(By.Id("Rooms1Children")));
        private SelectElement ageDropdown => new SelectElement(Driver.FindElement(By.CssSelector("#room-1 > div.child-ages > div:nth-child(2) > select")));
       
        private IWebElement searchHotelButton => Driver.FindElement(By.XPath("//form[@id='HotelsSearchSearchRedirectForm']/div[2]/div/div[4]/button"));
        
        public HotelSearchPage(IWebDriver webdriver) : base(webdriver) { }
        public void AcceptCookies()
        {
            cookiesButton.Click();
        }

        public void InsertData(string city,  string value, string age1)
        {
            Driver.SwitchTo().Frame("waavoiframe0");
            cityInput.SendKeys(city);      
            dropdown.SelectByValue(value);
            ageDropdown.SelectByValue(age1);
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//form[@id='HotelsSearchSearchRedirectForm']/div[2]/div/div[4]/button")));
            searchHotelButton.Click();

        }
        
    }

}
