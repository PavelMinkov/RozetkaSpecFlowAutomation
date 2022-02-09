using NUnit.Framework;
using RozetkaSpecFlowAutomation.Driver;
using RozetkaSpecFlowAutomation.Pages;
using TechTalk.SpecFlow;

namespace RozetkaSpecFlowAutomation.Steps
{
    [Binding]
    public sealed class BuyProductSteps
    {

        private readonly ScenarioContext _scenarioContext;

        public BuyProductSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I open official Rozetka web site")]
        public void OpenOfficialRozetkaWebSite()
        {
            HomePage.Instance
                .OpenRozetkaHomePage();
        }

        [When(@"I choose a product by text '(.*)'")]
        public void ChooseProductByText(string text)
        {
            HomePage.Instance
                .EnterTextProduct(text);
        }

        [When(@"I sort a product by brand '(.*)'")]
        public void SortProductByBrand(string brand)
        {
            ProductPage.Instance
                .TextBrand(brand)
                .ClickBrand();
        }

        [When(@"I sort a products '(.*)'")]
        public void SortProducts(int sort)
        {
            ProductPage.Instance
                .SortProducts(sort);
            DriverManager.DriverRefresh();
        }

        [When(@"I choose a products from list")]
        public void ChooseProductsFromList()
        {
            ProductPage.Instance
                .ClickListProducts()
                .ClickButtonBuy()
                .ClickCartClose()
                .ClickLogo();
        }

        [Then(@"check amount '(.*)'")]
        public void ThenCheckAmount(int amount)
        {
            BucketPage.Instance.ClickCart();
            Assert.That(BucketPage.Instance.GetOrderSum(), Is.LessThan(amount));
        }

        [AfterScenario]
        public static void AfterTestRun()
        {
            DriverManager.QuitDriver();
        }

    }
}
