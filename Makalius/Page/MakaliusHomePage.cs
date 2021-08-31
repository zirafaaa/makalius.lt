using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Makalius.Page
{
    public class MakaliusHomePage : BasePage
    {
        private const string PageAddress = "https://www.makalius.lt/";
        private IWebElement cookieButton => Driver.FindElement(By.CssSelector(".cc-compliance"));
        private IWebElement searchField => Driver.FindElement(By.Id("small-searchterms"));
        private IWebElement searchIcon => Driver.FindElement(By.CssSelector(".button-1.search-box-button"));
        public MakaliusHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void CloseCookies()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a[aria-label='dismiss cookie message']")));
            cookieButton.Click();
        }
    }
}
