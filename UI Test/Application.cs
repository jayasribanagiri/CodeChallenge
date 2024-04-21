
using CodeChallenge.UI_Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge.Features;

namespace CodeChallenge
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Application : BasePage
    {
        [TestMethod] 
        public void AddNewOrder()
        {
            try
            {
                // create a unique number 
                var accessionNum = CommonVars.instance.UnqTestNumber;

                //launch the application
                var tmp = Utility.launchEverLight();

                var loginPage = BasePage.GetAutPageAs<HomePage>();
                var ordersPage = BasePage.GetAutPageAs<OrdersPage>();
                var newOrderPage = BasePage.GetAutPageAs<NewOrdersPage>();

                loginPage.goToOrders();
                ordersPage.createNewOrder();
                newOrderPage.createOrder(accessionNum);

            }
            catch (Exception exCpn)
            {
                Assert.Fail(exCpn.Message);
            }
        }//Test


    }//class
}//namespace