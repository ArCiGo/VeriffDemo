using OpenQA.Selenium;
using VeriffDemo.Tests.UI.PageObjectModel.Components.Home;

namespace VeriffDemo.Tests.UI.PageObjectModel.Pages
{
    public class VeriffHomePage : BasePage
    {
        // Attributes
        private readonly HomeBodyComponent homeBodyComponent;

        // Constructor
        public VeriffHomePage(IWebDriver driver) : base(driver)
        {
            homeBodyComponent = new HomeBodyComponent(driver);
        }

        // Actions
        public void FillForm(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            homeBodyComponent.FillForm(fullName, sessionLanguage, docCountry, docType, launchVia);
        }

        public void ClickOnVeriffMeButton()
        {
            homeBodyComponent.ClickOnVeriffMeButton();
        }
    }
}
