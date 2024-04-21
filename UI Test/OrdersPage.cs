using CodeChallenge.Features;
using OpenQA.Selenium;


namespace CodeChallenge.UI_Test
{
    public class OrdersPage : BasePage
    {
      
            IWebElement CreateNewbtn { get { return SeleniumExtensions.GetWebElement(By.ClassName("//button[contains(@class,'btn btn-primary')]")); } }
            IWebElement Orderstable { get { return SeleniumExtensions.GetWebElement(By.ClassName("//table[contains(@class,'table table-striped')]")); } }

        public bool createNewOrder()
            {
                CreateNewbtn.Click();
                return true;

            }//goToOrders      



        }//class
    }//namespace

