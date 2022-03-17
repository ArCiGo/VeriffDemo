using System;
using OpenQA.Selenium;

namespace VeriffDemo.Tests.UI.PageObjectModel.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver { get; set; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
