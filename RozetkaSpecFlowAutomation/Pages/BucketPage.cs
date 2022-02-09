using OpenQA.Selenium;

namespace RozetkaSpecFlowAutomation.Pages
{
    class BucketPage : BasePage
    {
        private readonly By cart = By.XPath("//li[contains(@class,'cart')]");
        private readonly By cartSumm = By.XPath("//div[@class='cart-receipt__sum-price']/span[1]");

        private static BucketPage bucketPage;
        public static BucketPage Instance => bucketPage ??= new BucketPage();

        public BucketPage ClickCart()
        {
            FindElement(cart).Click();
            return this;
        }
        public int GetOrderSum()
        {
            return int.Parse(FindElement(cartSumm).Text);
        }
    }
}
