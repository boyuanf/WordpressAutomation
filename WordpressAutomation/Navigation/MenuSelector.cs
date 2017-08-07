using System;
using System.Threading;
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
            Actions moveAction = new Actions(Driver.Instance);
            moveAction.MoveToElement(element).Build().Perform();

            new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10)).Until(
                ExpectedConditions.ElementToBeClickable(By.LinkText(subMenuLinkText)));
            var addNew = Driver.Instance.FindElement(By.LinkText(subMenuLinkText));

            //Or We can do:
            //WebDriverWait waitAddNew = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            //var addNew = waitAddNew.Until(x => x.FindElement(By.LinkText(subMenuLinkText)));

            moveAction.MoveToElement(addNew).Click().Build().Perform();
        }
    }
}