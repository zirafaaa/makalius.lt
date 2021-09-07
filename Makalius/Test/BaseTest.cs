using Makalius.Drivers;
using Makalius.Page;
using Makalius.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
        protected static IWebDriver driver;

        public static MakaliusHomePage _makaliusHomePage;
        public static EgzotinesKelionesResultPage _egzotinesKelionesResultPage;
        protected static ExtentReportsHelper extent;



        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeWithSpecOptions();
            extent = new ExtentReportsHelper();
            _makaliusHomePage = new MakaliusHomePage(driver);
            _egzotinesKelionesResultPage = new EgzotinesKelionesResultPage(driver);                 

        }
        [SetUp]
        public static void SetUp()
        {
            extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
            MyReport.GenerateReport(driver, extent);
        }

        //[OneTimeTearDown]
        //public static void TearDown()
        //{
        //extent.Close();
        //    driver.Quit();
        //}
    }
}
