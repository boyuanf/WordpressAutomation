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
            Driver.Action.MoveToElement(Driver.Instance.FindElement(By.Id(topLevelMenuId))).Build().Perform();
            WebDriverWait waitAddNew = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            var addNew = waitAddNew.Until(x => x.FindElement(By.LinkText(subMenuLinkText)));
            Actions hoverAction = Driver.Action.MoveToElement(addNew).Click();
            hoverAction.Build().Perform();
        }
    }
}