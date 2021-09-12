using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Page
{
    public class HotelPage : BasePage
    {
        private IWebElement searchText => Driver.FindElement(By.CssSelector("#results > h1"));
        public HotelPage(IWebDriver webdriver) : base(webdriver) { }
        public void VerifySearchText()
        {
            Assert.AreEqual("Viešbučiai - Marakešas, Marokas", searchText.Text, "Text is wrong");
        }
    }
    
}
