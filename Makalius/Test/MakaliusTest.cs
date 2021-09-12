using NUnit.Framework;


namespace Makalius.Test
{
    public class MakaliusTest : BaseTest
    {
        [TestCase("vasario 13 - vasario 26", TestName ="Egzotine kelione vasari")]
        public static void EgzotinesKelionesTest(string month)
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.ClickOnEgzotinesKelionesButton();
            _egzotinesKelionesResultPage.OrderByVasaris();
            _egzotinesKelionesResultPage.VerifyTravel(month);
            
        }

        [TestCase("Jamaika", "Jamaik", TestName = "Keliones i Jamaika")]
        public static void SearchFieldTest(string travel, string text)
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.SearchField(travel);
            _searchResultPage.VerifySearch(travel);
            _searchResultPage.VerifyIfTravelsIsInJamaika(text);
        }

        [TestCase("100", "89 €", TestName ="Kelione dviems iki 200eur")]
        public static void BuyTravelFor2Until200EurTest(double filterprice, string price)
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.ClickOnIki100eurButton();
            _iki100EurPage.VerifyIf(filterprice);
            _iki100EurPage.ChooseTravel(price);
        }
     
        [TestCase("Vardas", "88888888", "test@test.com", TestName = "Parasyti nepilna uzklausa")]
        public static void ContactFormTest(string name, string phone, string mail)
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.ClickOnContactButton();
            _makaliusHomePage.ClickContactSubmitButton();
            _makaliusHomePage.VerifyErrorMessage();
            _makaliusHomePage.InsertData(name, phone, mail);
            _makaliusHomePage.ClickContactSubmitButton();
            _makaliusHomePage.VerifyErrorMessage();
        }

        [TestCase("Marakešas", "1", "2", TestName ="Viesbucio paieska Marakese")]
        public static void HotelTest(string city, string value, string age1)
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.ClickHotelButton();
            _hotelSearchPage.AcceptCookies();
            _hotelSearchPage.InsertData(city, value, age1);
            _hotelPage.VerifySearchText();
            
        }
        

    }
}
