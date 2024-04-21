using CodeChallenge.Features;
using OpenQA.Selenium;



namespace CodeChallenge.UI_Test
{
    public class NewOrdersPage : BasePage
    {
        IWebElement Mrn { get { return SeleniumExtensions.GetWebElement(By.Id("//input[@id='mrn']")); } }
        IWebElement FirstName { get { return SeleniumExtensions.GetWebElement(By.Id("//input[@id='first-name']")); } }

        IWebElement LastName { get { return SeleniumExtensions.GetWebElement(By.Id("//input[@id='last-name']")); } }

        IWebElement AccessionNum { get { return SeleniumExtensions.GetWebElement(By.Id("//input[@id='accession-number']")); } }

        IWebElement Organisation { get { return SeleniumExtensions.GetWebElement(By.Id("//Select[@id='org-code']")); } }

        IWebElement SiteID { get { return SeleniumExtensions.GetWebElement(By.Id("//Select[@id='site-id']")); } }

        IWebElement Modality { get { return SeleniumExtensions.GetWebElement(By.Id("//Select[@id='modality']")); } }

        IWebElement StudyDateTime { get { return SeleniumExtensions.GetWebElement(By.Id("//input[@id='study-date-time']")); } }
       
        IWebElement submitbtn { get { return SeleniumExtensions.GetWebElement(By.Id("//button[contains(@class,'btn btn-primary mr-1')]")); } }

        // IWebElement Cancelbtn { get { return SeleniumExtension.GetWebElement(By.ClassName("//button[contains(@class,'btn btn-warning')]")); } }  for cancel button
        //To delete the created record
        //IWebElement Orders { get { return SeleniumExtensions.GetWebElement(By.ClassName("(//a[contains(@class,'nav-link text-dark')])[2]")); } }
        //IWebElement deleteOrder { get { return SeleniumExtensions.GetWebElement(By.ClassName("(//i[contains(@class,'bi bi-x cursor-pointer')])[10]")); } }
        public void createOrder(string unqNumber)
        {
            object value = Mrn.editSetText("Mrn222");
            FirstName.editSetText("Jaya");
            LastName.editSetText("B");
            AccessionNum.editSetText(unqNumber);

            Organisation.comboSelectBySendKeys("The Ultrasound Clinic (USC)");
            SiteID.comboSelectBySendKeys("Clinic");
            Modality.comboSelectBySendKeys("Xray (XR)");

            StudyDateTime.setDateTime("18/04/2024", "11:11 AM");
            submitbtn.Click();
            //  cancelbtn.click();  for cancel button is used
            //  deleteOrder.click(); To delete the created order

        }



    }
}


