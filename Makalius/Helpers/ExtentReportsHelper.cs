﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;
namespace ReportingLibrary
{
namespace Makalius.Helpers
{
    public class ExtentReportsHelper
    {
        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }
        public ExtentReportsHelper()
        {
            extent = new ExtentReports();

            string reportDirectory = Path.GetDirectoryName(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
            string screenshotFolder = Path.Combine(reportDirectory, "Reports");
            Directory.CreateDirectory(screenshotFolder);
            reporter = new ExtentV3HtmlReporter(Path.Combine(screenshotFolder, "ExtentReports_"
                + $"{TestContext.CurrentContext.Test.Name}" + "_" + $"{DateTime.Now:HH_mm_ss}" + ".html"));

            reporter.Config.DocumentTitle = "Automation Testing Report";
            reporter.Config.ReportName = "Regression Testing";
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(reporter);

            extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
                test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        public void Close()
        {
            extent.Flush();
        }
    }
} }
