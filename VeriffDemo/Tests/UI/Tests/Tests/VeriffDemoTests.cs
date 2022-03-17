using System;
using NUnit.Framework;
using VeriffDemo.Tests.UI.PageObjectModel;
using VeriffDemo.Tests.UI.PageObjectModel.Pages;

namespace VeriffDemo.Tests.UI.Tests.Tests
{
    public class VeriffDemoTests : BaseTest
    {
        // Variables
        private readonly string baseURL = "https://demo.saas-3.veriff.me/";
        private VeriffDemoHomePage vdHomePage;

        // Tests
        [Test(Description = "It creates a new session")]
        [TestCase("Armando Cifuentes", "Español (México)", "Mexico", "ID Card", LaunchVia.InContext)]
        [Order(1)]
        public void CreateNewSession(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            vdHomePage = new VeriffDemoHomePage(Driver);
            vdHomePage.GoTo(baseURL);
            vdHomePage.FillForm(fullName, sessionLanguage, docCountry, docType, launchVia);
            vdHomePage.ClickOnVeriffMeButton();
        }
    }
}
