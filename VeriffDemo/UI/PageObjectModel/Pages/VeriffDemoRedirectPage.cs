using OpenQA.Selenium;
using VeriffDemo.Tests.UI.PageObjectModel.Pages;
using VeriffDemo.UI.PageObjectModel.Components.Redirect;

namespace VeriffDemo.UI.PageObjectModel.Pages
{
    public class VeriffDemoRedirectPage : BasePage
    {
        // Variables & Constants
        private readonly RedirectBodyComponent redirectBodyComponent;

        // Constructor
        public VeriffDemoRedirectPage(IWebDriver driver) : base(driver)
        {
            redirectBodyComponent = new RedirectBodyComponent(driver);
        }

        // Actions
        public bool QRCodeIsLoaded()
        {
            return redirectBodyComponent.QRCodeIsLoaded();
        }
    }
}
