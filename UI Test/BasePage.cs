using OpenQA.Selenium;
using CodeChallenge.Features;

namespace CodeChallenge.UI_Test
{
    public class BasePage
    {
        public static IWebDriver driver = CommonVars.instance.webDriver;

      
        public static T GetAutPageAs<T>()
        {
            dynamic pageobject = null;
            var type = typeof(T);

            // getiing the default constructor
            var ctor = type.GetConstructor(Type.EmptyTypes);
            if (ctor != null)
            {
                pageobject = (T)ctor.Invoke(new object[] { });
            }

            return pageobject;
        }// TestMethod


    }//class
}//namespace


