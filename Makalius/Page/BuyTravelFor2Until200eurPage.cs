using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Page
{
    public class BuyTravelFor2Until200eurPage : BasePage
    {
        private IWebElement perkuButton => Driver.FindElement(By.CssSelector("#container-body > div.container > div.content.clearfix.sides.sidebar-floating > div.main-side.pull-left > div > div:nth-child(4) > div.block.clearfix > div.more.pull-right.text-uppercase > a"));
        private IWebElement checkbox => Driver.FindElement(By.Id("payment-type_full"));
        public BuyTravelFor2Until200eurPage(IWebDriver webdriver) : base(webdriver) { }

        public void ClickOnPerkuButton()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(perkuButton);
            actions.Perform();
            perkuButton.Click();
            checkbox.Click();
        }

        public void VerifyPrice()
        {

        }
    }
}
