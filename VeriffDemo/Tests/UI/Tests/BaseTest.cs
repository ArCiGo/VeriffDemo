using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VeriffDemo.Tests.UI.Tests.AutomationResources;

namespace VeriffDemo.Tests.UI.Tests
{
    public class BaseTest
    {
        // Properties
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        // Actions
        [SetUp]
        public void SetUp()
        {
            var factory = new WebDriverFactory();
            Driver = factory.GetDriver(BrowserType.Chrome);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            try
            {
                StopBrowser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Close();
            Driver.Quit();
            Driver = null;
        }
    }
}
