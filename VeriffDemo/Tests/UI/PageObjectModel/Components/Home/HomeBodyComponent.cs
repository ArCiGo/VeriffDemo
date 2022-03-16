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

        // Constructor
        public HomeBodyComponent(IWebDriver driver) : base(driver) { }

        // Actions
    }
}
