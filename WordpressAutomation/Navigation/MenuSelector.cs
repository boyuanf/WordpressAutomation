using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class MenuSelector
    {
        public static void Select(string topLevelMenuId, string subMenuLinkText)
        {
            var element = Driver.Instance.FindElement(By.Id(topLevelMenuId));
            Actions action = new Actions(Driver.Instance);
            action.MoveToElement(element).Build().Perform();
            WebDriverWait waitAddNew = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            var addNew = waitAddNew.Until(x => x.FindElement(By.LinkText(subMenuLinkText)));
            action.MoveToElement(addNew).Click();
            action.Build().Perform();
        }
    }
}