using OpenQA.Selenium;

namespace VeriffDemo.Tests.UI.PageObjectModel
{
    public class VeriffDemoComponent
    {
        protected IWebDriver Driver { get; set; }

        public VeriffDemoComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
