using CodeChallenge.Features;
using OpenQA.Selenium;


namespace CodeChallenge.UI_Test
{
    public class HomePage : BasePage
    {
        
            IWebElement Home { get { return SeleniumExtensions.GetWebElement(By.ClassName("//a[contains(@class,'nav-link text-dark')])[1]")); } }
            IWebElement Orders { get { return SeleniumExtensions.GetWebElement(By.ClassName("(//a[contains(@class,'nav-link text-dark')])[2]")); } }

            
            public bool goToOrders()
            {
                Orders.Click();
                return true;

            }//goToOrders      

            public bool goToHomePage()
            {
                Home.Click();
                return true;

            }//goToOrders   

            public override bool Equals(object? obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override string? ToString()
            {
                return base.ToString();
            }
       

}
}
