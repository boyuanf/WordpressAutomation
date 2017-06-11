﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static Actions Action { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
            Action = new Actions(Instance);
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Clean()
        {
            //Instance.Close();
        }
    }
}