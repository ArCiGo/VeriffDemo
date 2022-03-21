using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using VeriffDemo.Tests.UI.PageObjectModel;

namespace VeriffDemo.UI.PageObjectModel.Components.Home
{
    public class HomeBodyComponent : VeriffDemoComponent
    {
        // Variables & Constants
        private readonly WebDriverWait wait;

        // Elements
        public By FullNameInputField => By.XPath("//input[contains(@class, 'TextField-module_input')]");
        public By SessionLanguageButton => By.CssSelector("[name='language']");
        public By SessionLanguageOptions => By.CssSelector("ul[id='downshift-0-menu'] > li");
        public By DocumentCountryButton => By.CssSelector("[name='documentCountry']");
        public By DocumentCountryOptions => By.CssSelector("ul[id='downshift-1-menu'] > li");
        public By DocumentTypeButton => By.CssSelector("[name='documentType']");
        public By DocumentTypeOptions => By.CssSelector("ul[id='downshift-2-menu'] > li");
        public By InContextRadioButton => By.XPath("//input[@type='radio' and @value='incontext']");
        public By RedirectRadioButton => By.XPath("//input[@type='radio' and @value='redirect']");
        public By VeriffMeButton => By.XPath("//button[contains(text(), 'Veriff')]");
        public By IFrameVeriffVerification => By.Id("veriffFrame");
        public By QRCode => By.XPath("//p[contains(text(), 'QR')]");

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Actions
        public void FillForm(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            EnterFullName(fullName);
            ChooseSessionLanguageOption(sessionLanguage);
            ChooseDocumentCountryOption(docCountry);
            ChooseDocumentTypeOption(docType);
            ChooseLauncViaOption(launchVia);
        }

        private void EnterFullName(string fullName)
        {
            var fullNameInputField = wait.Until(ExpectedConditions.ElementIsVisible(FullNameInputField));
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].value = ''", fullNameInputField);
            fullNameInputField.SendKeys(fullName);
        }

        private void ChooseSessionLanguageOption(string sessionLanguage)
        {
            var sessionLanguageButton = wait.Until(ExpectedConditions.ElementExists(SessionLanguageButton));
            sessionLanguageButton.Click();
            var sessionLanguageOptions = Driver.FindElements(SessionLanguageOptions);

            foreach (var item in sessionLanguageOptions)
            {
                if (item.Text.Contains(sessionLanguage))
                {
                    item.Click();
                    break;
                }
            }
        }

        private void ChooseDocumentCountryOption(string docCountry)
        {
            var documentCountryButton = wait.Until(ExpectedConditions.ElementExists(DocumentCountryButton));
            documentCountryButton.Click();
            var documentCountryOptions = Driver.FindElements(DocumentCountryOptions);

            foreach (var item in documentCountryOptions)
            {
                if(item.Text.Contains(docCountry))
                {
                    item.Click();
                    break;
                }
            }
        }

        private void ChooseDocumentTypeOption(string docType)
        {
            var documentTypeButton = wait.Until(ExpectedConditions.ElementExists(DocumentTypeButton));
            documentTypeButton.Click();
            var documentTypeOptions = Driver.FindElements(DocumentTypeOptions);

            foreach (var item in documentTypeOptions)
            {
                if (item.Text.Contains(docType))
                {
                    item.Click();
                    break;
                }
            }
        }

        private void ChooseLauncViaOption(LaunchVia launchVia)
        {
            switch (launchVia)
            {
                case LaunchVia.InContext:
                    Driver.FindElement(InContextRadioButton).Click();
                    break;
                case LaunchVia.Redirect:
                    Driver.FindElement(RedirectRadioButton).Click();
                    break;
                default:
                    ArgumentException ex = new ArgumentException("No such option exists!");
                    throw ex;
            }
        }

        public void ClickOnVeriffMeButton()
        {
            Driver.FindElement(VeriffMeButton).Click();
        }

        public bool QRCodeIsLoaded()
        {
            var iFrameVeriffVerification = wait.Until(ExpectedConditions.ElementIsVisible(IFrameVeriffVerification));
            Driver.SwitchTo().Frame(iFrameVeriffVerification);
            return wait.Until(ExpectedConditions.ElementIsVisible(QRCode)).Displayed;
        }
    }
}
