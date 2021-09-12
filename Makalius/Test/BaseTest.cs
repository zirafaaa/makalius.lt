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
        public static SearchResultPage _searchResultPage;
        public static Iki100eurPage _iki100EurPage;
        public static BuyTravelFor2Until200eurPage _buyTravelFor2Until200EurPage;
        public static HotelSearchPage _hotelSearchPage;
        public static HotelPage _hotelPage;
     




        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDriver.GetChromeWithSpecOptions();
            
            _makaliusHomePage = new MakaliusHomePage(driver);
            _egzotinesKelionesResultPage = new EgzotinesKelionesResultPage(driver);
            _searchResultPage = new SearchResultPage(driver);
            _iki100EurPage = new Iki100eurPage(driver);
            _buyTravelFor2Until200EurPage = new BuyTravelFor2Until200eurPage(driver);
            _hotelSearchPage = new HotelSearchPage(driver);
            _hotelPage = new HotelPage(driver);

        }
       

        [TearDown]
        public static void Screenshots()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MyScreenshot.TakeScreenshot(driver);
            }
            
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
        
          //  driver.Quit();
        }
    }
}
