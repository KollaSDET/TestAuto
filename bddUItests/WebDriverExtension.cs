using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace bddUItests
{
    public static class WebDriverExtension
    {

        public static IWebElement Find(this IWebDriver driver, By by)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = null;
            wait.Until(d =>
            {
                try
                {
                    element = d.FindElement(by);
                    if (element.Displayed && element.Enabled)
                        return element;
                }
                catch (StaleElementReferenceException)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                    return element;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("NO such element with the locator {0} is present", by);
                    d.Close();
                    return null;
                }
                return null;
            });
            return element;
        }
        public static IWebElement Find(this IWebDriver driver, By by, int timeOutOfSeconds)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutOfSeconds));
            IWebElement element = null;
            wait.Until(d =>
            {
                try
                {
                    element = d.FindElement(by);
                    if (element.Displayed && element.Enabled)
                        return element;
                }
                catch (StaleElementReferenceException)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutOfSeconds));
                    element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                    return element;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("NO such element with the locator {0} is present", by);
                    d.Close();
                    return null;
                }
                return null;
            });
            return element;
        }
    }
}
