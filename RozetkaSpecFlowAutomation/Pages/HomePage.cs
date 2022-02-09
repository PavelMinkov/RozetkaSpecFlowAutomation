using OpenQA.Selenium;

namespace RozetkaSpecFlowAutomation.Pages
{
    class HomePage : BasePage
    {

        private readonly By choiseTitle = By.CssSelector("input.search-form__input");

        private static HomePage homePage;
        public static HomePage Instance => homePage ??= new HomePage();

        public HomePage EnterTextProduct(string text)
        {
            FindElement(choiseTitle).Clear();
            FindElement(choiseTitle).SendKeys(text + "\n");
            return this;
        }

    }
}
