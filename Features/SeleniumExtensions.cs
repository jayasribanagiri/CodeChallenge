﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace CodeChallenge.Features
{
    public static class SeleniumExtensions 
    {
        public static IWebDriver webDriver = CommonVars.instance.webDriver;

        //######################################################################################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementlocator"></param>
        /// <returns></returns>
        public static IWebElement GetWebElement(By elementlocator)
        {
            ReadOnlyCollection<IWebElement> clxnFindElements = null;
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
                Console.WriteLine("Element with locator: '" + elementlocator.ToString() + "' was not found in current context page.");


            IWebElement element = clxnFindElements.FirstOrDefault();
            return element;
        }//GetWebElement


        //######################################################################################################################
        public static bool setDateTime(this IWebElement webElement, string dateValue, string timeValue)
        {
            //var tmpArray = dateValue.Split(new[] { "/" }, StringSplitOptions.None);
            //foreach(var tmpStr in tmpArray)
            //{
            //    webElement.SendKeys(tmpStr);
            //    Thread.Sleep(1000);
            //}

            //tmpArray = timeValue.Split(new[] { "/" }, StringSplitOptions.None);
            //foreach (var tmpStr in tmpArray)
            //{
            //    webElement.SendKeys(tmpStr);
            //    Thread.Sleep(1000);
            //}


            webElement.SendKeys(dateValue);
            webElement.SendKeys(Keys.ArrowRight);

            string amPM = timeValue.Substring(timeValue.Length - 2).Trim();
            timeValue = timeValue.Replace(amPM, "", StringComparison.OrdinalIgnoreCase).Trim();
            webElement.SendKeys(timeValue);
            webElement.SendKeys(Keys.ArrowRight);
            webElement.SendKeys(amPM.ToUpper());
            return true;
        }//setDateTime


        public static bool editSetText(this IWebElement webElement, string dataValue, bool clearFlag = true)
        {
            if (clearFlag)
                webElement.Clear();

            webElement.SendKeys(dataValue);
            return true;
        }//editSetText

        public static bool comboSelectByIndex(this IWebElement webElement, int itemIndex)
        {
            // Select the actual item
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByIndex(itemIndex);
            return true;
        }//comboSelectByIndex

        public static bool comboSelectBySendKeys(this IWebElement webElement, string dataValue)
        {
            webElement.Click();
            webElement.SendKeys(dataValue);
            webElement.Click();
            return true;
        }//comboSelectBySendKeys

        public static bool Click(this By elementlocator)
        {
            IWebElement element = GetWebElement(elementlocator);
            element.Click();
            return true;
        }// Click


        
        public static bool Submit(this By elementlocator)
        {
            IWebElement element = GetWebElement(elementlocator);
            element.Submit();
            return true;
        }// Click


        
        public static bool SendKeys(this By elementlocator, string value)
        {
            IWebElement element = GetWebElement(elementlocator);
            element.SendKeys(value);
            return true;
        }// SendKeys


        
        public static bool SelectByText(this By elementlocator, string value)
        {
            IWebElement element = GetWebElement(elementlocator);
            new SelectElement(element).SelectByText(value);
            return true;
        }// SelectByText


    }//class
}//namespace
    
