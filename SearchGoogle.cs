using Microsoft.VisualStudio.TestTools.UnitTesting;  // I had to add this manually;
// using System;
// using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Diagnostics;
// using OpenQA.Selenium.Support.UI;

// 1-14-20 based on https://www.youtube.com/watch?v=vTWV1x1lg6Q
// 1-14-20 added to local GIT repository; 

namespace SeleniumDemo2
{
    [TestClass]
    public class SearchGoogle
    {
        [TestMethod]
        public void SearchForCheese()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");  // Need this  - comment it out to turn headless off.
            // https://sqa.stackexchange.com/questions/33778/chromedriver-in-headless-mode-doesnt-work-correctly-because-of-windows-user-pol 
            // chromeOptions.AddArguments("--window-size=1920,1080");
            chromeOptions.AddArguments("--disable-gpu"); // Need this
           // chromeOptions.AddArguments("--disable-extensions");
           //  chromeOptions.setExperimentalOption("useAutomationExtension", false);
            chromeOptions.AddArguments("--proxy-server='direct://'"); // Need this
            chromeOptions.AddArguments("--proxy-bypass-list=*"); // Need this
            //chromeOptions.AddArguments("--start-maximized");
           

            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))

            {
                Console.WriteLine("Driver path here: " + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                Debug.WriteLine("Semd to debug trace. ");

                driver.Navigate().GoToUrl("http://www.google.com/");
                IWebElement query = driver.FindElement(By.Name("q"));
                query.SendKeys("Cheese");
                query.Submit();

                //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //wait.Until(d => d.Title.StartsWith, ("cheese", StringComparison.OrdinalIgnoreCase));

                Assert.AreEqual(driver.Title, "Cheese - Google Search");

            }
        }
    }
}
