using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using ReportingLibrary.Makalius.Helpers;

namespace Makalius.Tools
{
    class MyReport
    {
        public static void GenerateReport(IWebDriver driver, ExtentReportsHelper extent)
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            string stacktrace = TestContext.CurrentContext.Result.StackTrace;
            string errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
            switch (status)
            {
                case TestStatus.Failed:
                    extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                    extent.AddTestFailureScreenshot(MyScreenshot.ScreenCaptureAsBase64String(driver));
                    break;
                case TestStatus.Skipped:
                    extent.SetTestStatusSkipped();
                    break;
                default:
                    extent.SetTestStatusPass();
                    break;
            }
        }
    }
}
