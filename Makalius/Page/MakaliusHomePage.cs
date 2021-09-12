using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Makalius.Page
{
    public class MakaliusHomePage : BasePage
    {
        private const string PageAddress = "https://www.makalius.lt/";        
        private IWebElement egzotinesButton => Driver.FindElement(By.CssSelector("#container-body > div.container > div.menu-line-container.clearfix > div > div.categories.text-uppercase.pull-left > ul > li:nth-child(5) > h2"));
        private IWebElement searchField => Driver.FindElement(By.CssSelector("ul[class='search-holder'] input[placeholder='Ieškok']"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector("ul[class='search-holder'] input[type='submit']"));
        private IWebElement iki100eurButton => Driver.FindElement(By.CssSelector("div[class='sidebar pull-right hidden-xs'] a[id='filter-price-1']"));
        private IWebElement contactButton => Driver.FindElement(By.CssSelector(".email"));
        private IWebElement problemInput => Driver.FindElement(By.XPath("//input[@name='message']"));
        private IWebElement nameInput => Driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement phoneInput => Driver.FindElement(By.XPath("//input[@name='phone']"));
        private IWebElement emailInput => Driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement contactSubmitButton => Driver.FindElement(By.CssSelector(".btn.btn-primary.btn-md.btn-block.btn-primary-big"));
        private IWebElement errorMessage => Driver.FindElement(By.CssSelector(".alert-message-box"));
        private IWebElement hotelButton => Driver.FindElement(By.XPath("//body/div[@id='container-body']/div[@class='container']/div[@class='main-line clearfix sides']/ul[@class='pull-left']/li[2]"));

        public MakaliusHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void AcceptCookies()
        {
            Cookie myCookie = new Cookie("cookieconsent_status",
                "dismiss",
               ".makalius.lt",
               "/",
                DateTime.Now.AddMonths(24));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }
        public void ClickOnEgzotinesKelionesButton()
        {
            egzotinesButton.Click();
        }
        public void SearchField(string text)
        {
            searchField.Clear();
            searchField.SendKeys(text);
            searchIcon.Click();
        }
        public void ClickOnIki100eurButton()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(iki100eurButton);
            actions.Perform();
            iki100eurButton.Click();
        }
        public void ClickOnContactButton()
        {
            contactButton.Click();
        }
        public void ClickContactSubmitButton()
        {
            contactSubmitButton.Click();
        }
        public void VerifyErrorMessage()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".alert-message-box")));
            Assert.AreEqual("Prašome užpildyti privalomus laukus!", errorMessage.Text, "Class attribute value is wrong");
            
        }       
      
        public void InsertData(string name, string phone, string mail)
        {
            nameInput.SendKeys(name);
            phoneInput.SendKeys(phone);
            emailInput.SendKeys(mail);
            
        }
        public void ClickHotelButton()
        {
            hotelButton.Click();
        }
        
    }
}
