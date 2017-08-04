using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static Actions Action { get; set; }

        public static string BaseAddress
        {
            get { return "http://localhost:17758/"; }
        }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Action = new Actions(Instance);
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        public static void Clean()
        {
            //Instance.Close();
        }

        public static void Sleep(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));

        }
    }
}