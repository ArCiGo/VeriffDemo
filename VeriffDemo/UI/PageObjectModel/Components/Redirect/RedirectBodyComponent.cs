using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using VeriffDemo.Tests.UI.PageObjectModel;

namespace VeriffDemo.UI.PageObjectModel.Components.Redirect
{
    public class RedirectBodyComponent : VeriffDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        public By QRCode => By.XPath("//p[contains(text(), 'QR')]");

        // Constructor
        public RedirectBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Actions
        public bool QRCodeIsLoaded()
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(QRCode)).Displayed;
        }
    }
}
