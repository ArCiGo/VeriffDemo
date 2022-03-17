using System.Collections.Generic;
using OpenQA.Selenium;

namespace VeriffDemo.Tests.UI.PageObjectModel.Components.Home
{
    public class HomeBodyComponent : VeriffDemoComponent
    {
        // Variables

        // Elements
        public IWebElement FullNameInputField => Driver.FindElement(By.XPath("//input[@class='TextField - module_input__3FXIK']"));
        public IWebElement SessionLanguageButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Select-module_select') and @name='language']"));
        public IList<IWebElement> SessionLanguageOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li/span"));
        public IWebElement DocumentCountryButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Autocomplete-module_iconButton')]"));
        public IList<IWebElement> DocumentCountryOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li/span"));
        public IWebElement DocumentTypeButton => Driver.FindElement(By.XPath("//button[contains(@class, 'Select-module_select') and @name='documentType']"));
        public IList<IWebElement> DocumentTypeOptions => Driver.FindElements(By.XPath("//reach-portal/div/ul/li/span"));
        public IWebElement InContextRadioButton => Driver.FindElement(By.XPath("//input[@type='radio' and @value='incontext']"));
        public IWebElement RedirectRadioButton => Driver.FindElement(By.XPath("//input[@type='radio' and @value='redirect']"));
        public IWebElement VeriffMeButton => Driver.FindElement(By.XPath("//button[contains(text(), 'Veriff')]"));

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver) { }

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
                index++;

                if (item.Text.Contains(sessionLanguage))
                {
                    SessionLanguageOptions[index].Click();
                }
            }
        }

        private void ChooseDocumentCountryOption(string docCountry)
        {
            int index = 0;

            foreach (var item in DocumentCountryOptions)
            {
                index++;

                if(item.Text.Contains(docCountry))
                {
                    DocumentCountryOptions[index].Click();
                }
            }
        }

        private void ChooseDocumentTypeOption(string docType)
        {
            int index = 0;

            foreach (var item in DocumentTypeOptions)
            {
                index++;

                if (item.Text.Contains(docType))
                {
                    DocumentTypeOptions[index].Click();
                }
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
                    WebDriverArgumentException ex = new WebDriverArgumentException("No such option exists!");
                    throw ex;
            }
        }

        public void ClickOnVeriffMeButton()
        {
            VeriffMeButton.Click();
        } 
    }
}
