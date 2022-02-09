using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RozetkaSpecFlowAutomation.Driver;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace RozetkaSpecFlowAutomation.Pages
{
    class BasePage
    {
        private string URL = "https://rozetka.com.ua";
        protected int timeout = 30;

        public void OpenRozetkaHomePage()
        {
            DriverManager.Instance().Navigate().GoToUrl(URL);
        }
        protected IWebElement FindElement(By locator)
        {
            return DriverManager.Instance().FindElement(locator);
        }

        protected ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return DriverManager.Instance().FindElements(locator);
        }

        protected void WaitUntillElementIsVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(DriverManager.Instance(), TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        protected void WaitUntillElementToBeClickable(By locator)
        {
            WebDriverWait wait = new WebDriverWait(DriverManager.Instance(), TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void actionMoveToElement(By locator)
        {
            Actions actionProvider = new Actions(DriverManager.Instance());
            actionProvider.MoveToElement(DriverManager.Instance().FindElement(locator)).Build().Perform();
        }
        public void waitForPageLoadComplete()
        {
            new WebDriverWait(DriverManager.Instance(), System.TimeSpan.FromSeconds(timeout))
                .Until(webDriver => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }
        public void WaitUntillListUpdate(By locator)
        {
            WebDriverWait wait = new WebDriverWait(DriverManager.Instance(), TimeSpan.FromSeconds(timeout));
            wait.Until(s => s.FindElements(locator).Count == 1);
        }

    }
}
