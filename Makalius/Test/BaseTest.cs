using Makalius.Drivers;
using Makalius.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;

        public static MakaliusHomePage _makaliusHomePage;



        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _makaliusHomePage = new MakaliusHomePage(driver);

        }

        //[OneTimeTearDown]
        //public static void TearDown()
        //{
        //    driver.Quit();
        //}
    }
}
