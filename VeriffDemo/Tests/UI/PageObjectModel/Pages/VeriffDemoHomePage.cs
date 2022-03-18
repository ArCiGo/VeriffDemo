using OpenQA.Selenium;
using VeriffDemo.Tests.UI.PageObjectModel.Components.Home;

namespace VeriffDemo.Tests.UI.PageObjectModel.Pages
{
    public class VeriffDemoHomePage : BasePage
    {
        // Variables
        private readonly HomeBodyComponent homeBodyComponent;

        // Constructor
        public VeriffDemoHomePage(IWebDriver driver) : base(driver)
        {
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions
        public void GoTo(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        public void FillForm(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            homeBodyComponent.FillForm(fullName, sessionLanguage, docCountry, docType, launchVia);
        }

        public void ClickOnVeriffMeButton()
        {
            homeBodyComponent.ClickOnVeriffMeButton();
        }

        public bool QRCodeIsLoaded()
        {
            return homeBodyComponent.QRCodeIsLoaded();
        }
    }
}
