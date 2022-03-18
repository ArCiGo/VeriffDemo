using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace VeriffDemo.Tests.UI.PageObjectModel.Components.Home
{
    public class HomeBodyComponent : VeriffDemoComponent
    {
        // Variables
        private readonly WebDriverWait wait;

        // Elements
        public IWebElement FullNameInputField => Driver.FindElement(By.XPath("//input[contains(@class, 'TextField-module_input')]"));
        public IWebElement SessionLanguageButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Select-module_select') and @name='language']"));
        public IList<IWebElement> SessionLanguageOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li"));
        public IWebElement DocumentCountryButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Autocomplete-module_iconButton')]"));
        public IList<IWebElement> DocumentCountryOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li"));
        public IWebElement DocumentTypeButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Select-module_select') and @name='documentType']"));
        public IList<IWebElement> DocumentTypeOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li"));
        public IWebElement InContextRadioButton => Driver.FindElement(By.XPath("//input[@type='radio' and @value='incontext']"));
        public IWebElement RedirectRadioButton => Driver.FindElement(By.XPath("//input[@type='radio' and @value='redirect']"));
        public IWebElement VeriffMeButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Veriff')]"));
        public IWebElement IFrameVeriffVerification => Driver.FindElement(By.Id("#veriffFrame"));
        public IWebElement QRCode => Driver.FindElement(By.XPath("//p[contains(text(), 'QR')]"));

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Actions
        public void FillForm(string fullName, string sessionLanguage, string docCountry, string docType, LaunchVia launchVia)
        {
            FullNameInputField.Clear();
            FullNameInputField.SendKeys(fullName);

            SessionLanguageButton.Click();
            ChooseSessionLanguageOption(sessionLanguage);

            DocumentCountryButton.Click();
            ChooseDocumentCountryOption(docCountry);

            DocumentTypeButton.Click();
            ChooseDocumentTypeOption(docType);

            ChooseLauncViaOption(launchVia);
        }

        private void ChooseSessionLanguageOption(string sessionLanguage)
        {
            int index = 0;

            foreach (var item in SessionLanguageOptions)
            {
                if (item.Text.Contains(sessionLanguage))
                {
                    SessionLanguageOptions[index].Click();
                }

                index++;
            }
        }

        private void ChooseDocumentCountryOption(string docCountry)
        {
            int index = 0;

            foreach (var item in DocumentCountryOptions)
            {
                if(item.Text.Contains(docCountry))
                {
                    DocumentCountryOptions[index].Click();
                }

                index++;
            }
        }

        private void ChooseDocumentTypeOption(string docType)
        {
            int index = 0;

            foreach (var item in DocumentTypeOptions)
            {
                if (item.Text.Contains(docType))
                {
                    DocumentTypeOptions[index].Click();
                }

                index++;
            }
        }

        private void ChooseLauncViaOption(LaunchVia launchVia)
        {
            switch (launchVia)
            {
                case LaunchVia.InContext:
                    InContextRadioButton.Click();
                    break;
                case LaunchVia.Redirect:
                    RedirectRadioButton.Click();
                    break;
                default:
                    ArgumentException ex = new ArgumentException("No such option exists!");
                    throw ex;
            }
        }

        public void ClickOnVeriffMeButton()
        {
            VeriffMeButton.Click();
        }

        public bool QRCodeIsLoaded()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("#veriffFrame")));
                Driver.SwitchTo().Frame(IFrameVeriffVerification);
                return wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(), 'QR')]"))).Displayed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
