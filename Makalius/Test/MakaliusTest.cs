using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makalius.Test
{
    public class MakaliusTest : BaseTest
    {
        [Test]
        public static void TestMakalius()
        {
            _makaliusHomePage.NavigateToPage();
            _makaliusHomePage.AcceptCookies();
            _makaliusHomePage.ClickOnEgzotinesButton();
            _egzotinesKelionesResultPage.OrderBySausisTravel();

        }
    }
}
