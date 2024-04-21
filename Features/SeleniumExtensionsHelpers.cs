using OpenQA.Selenium;
using System.Collections.ObjectModel;

internal static class SeleniumExtensionsHelpers
{

    //######################################################################################################################
    /// <summary>
    /// 
    /// </summary>
    /// <param name="elementlocator"></param>
    /// <returns></returns>
    public static IWebElement GetWebElement(By elementlocator)
    {
        ReadOnlyCollection<IWebElement>? clxnFindElements = null;
        DateTime timeout = DateTime.Now.Add(TimeSpan.FromSeconds(20));
        while (DateTime.Now <= timeout)
        {
            clxnFindElements = webDriver.FindElements(elementlocator);
            if (clxnFindElements.Count > 0)
                break;

            // wait for 1 Sec before trying again                
            Thread.Sleep(1000);
        }

        //if no Items are found return null
        if (clxnFindElements.Count == 0)
        {
            Console.WriteLine("Element with locator: '" + elementlocator.ToString() + "' was not found in current context page.");
        }

        IWebElement element = clxnFindElements.FirstOrDefault();
        return element;
    }//GetWebElement
}