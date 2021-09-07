using OpenQA.Selenium;
using System;

namespace Makalius.Page
{
    public class MakaliusHomePage : BasePage
    {
        private const string PageAddress = "https://www.makalius.lt/";
        private IWebElement egzotinesButton => Driver.FindElement(By.CssSelector(".hidden-md:nth-child(7) a"));

       
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
        public void ClickOnEgzotinesButton()
        {
            egzotinesButton.Click();
        }
    }
}
