using NUnit.Framework;
using VeriffDemo.UI.PageObjectModel;
using VeriffDemo.UI.PageObjectModel.Pages;

namespace VeriffDemo.Tests.UI
{
    public class VeriffDemoTests : BaseTest
    {
        // Variables
        private readonly string baseURL = "https://demo.saas-3.veriff.me/";
        private VeriffDemoHomePage vdHomePage;
        private VeriffDemoRedirectPage vdRedirectPage;

        // Tests
        [Test(Description = "It creates a new session"), Category("UI")]
        [TestCase("Armando Cifuentes", "Español (México)", "Mexico", "ID Card", LaunchVia.InContext)]
        [TestCase("Malala Yousafzai", "English", "United Kingdom of Great Britain and Northern Ireland", "Passport", LaunchVia.Redirect)]
        [Order(1)]
        public void CreateNewSession(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            vdHomePage = new VeriffDemoHomePage(Driver);
            vdRedirectPage = new VeriffDemoRedirectPage(Driver);

            vdHomePage.GoTo(baseURL);
            vdHomePage.FillForm(fullName, sessionLanguage, docCountry, docType, launchVia);
            vdHomePage.ClickOnVeriffMeButton();

            switch (launchVia)
            {
                case LaunchVia.InContext:
                    Assert.IsTrue(vdHomePage.QRCodeIsLoaded());
                    break;
                case LaunchVia.Redirect:
                    Assert.IsTrue(vdRedirectPage.QRCodeIsLoaded());
                    break;
                default:
                    break;
            }
        }
    }
}
