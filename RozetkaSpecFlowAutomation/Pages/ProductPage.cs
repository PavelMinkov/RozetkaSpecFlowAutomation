using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace RozetkaSpecFlowAutomation.Pages
{
    class ProductPage : BasePage
    {
        private readonly By inputBrand = By.XPath("//div[@data-filter-name='producer']//input[@name='searchline']");
        private readonly By brandList = By.XPath("//div[@data-filter-name='producer']//ul[@class='checkbox-filter']//li");
        private readonly By elementSort = By.CssSelector("select[class*='select']");
        private readonly By listProducts = By.CssSelector("span.goods-tile__title");
        private readonly By moveToButtonBuy = By.CssSelector("p[class*='product-prices']");
        private readonly By elementButtonBuy = By.XPath("//ul[@class='product-buttons']//span[contains(@class,'buy-button')]");
        private readonly By elementCartClose = By.CssSelector("div.modal__header button[class*='close']");
        private readonly By elementLogo = By.CssSelector("a.header__logo");
        SelectElement DropdownElement { get { return new SelectElement(FindElement(elementSort)); } }

        private static ProductPage searchResultsPage;
        public static ProductPage Instance => searchResultsPage ??= new ProductPage();


        public ProductPage TextBrand(string textBrand)
        {
            WaitUntillElementIsVisible(inputBrand);
            FindElement(inputBrand).SendKeys(textBrand);
            return this;
        }

        public ProductPage ClickBrand()
        {
            WaitUntillListUpdate(brandList);
            FindElement(brandList).Click();
            return this;
        }
        public ProductPage SortProducts(int sort)
        {
            DropdownElement.SelectByIndex(sort);
            return this;
        }

        public ProductPage ClickListProducts()
        {
            waitForPageLoadComplete();
            FindElements(listProducts)[0].Click();
            return this;
        }

        public ProductPage ClickButtonBuy()
        {
            WaitUntillElementIsVisible(moveToButtonBuy);
            actionMoveToElement(moveToButtonBuy);
            FindElement(elementButtonBuy).Click();
            return this;
        }

        public ProductPage ClickCartClose()
        {
            WaitUntillElementToBeClickable(elementCartClose);
            FindElement(elementCartClose).Click();
            return this;
        }
        public ProductPage ClickLogo()
        {
            WaitUntillElementToBeClickable(elementLogo);
            FindElement(elementLogo).Click();
            return this;
        }


    }
}
