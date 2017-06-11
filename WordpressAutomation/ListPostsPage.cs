using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class ListPostsPage
    {
        static By pagesButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[5]/a/div[3]");
        static By allPagesButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[5]/ul/li[2]/a");

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    Driver.Action.MoveToElement(Driver.Instance.FindElement(pagesButton)).Build().Perform();
                    WebDriverWait waitAllPages = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                    var allPages = waitAllPages.Until(x => x.FindElement(allPagesButton));
                    Actions hoverAction = Driver.Action.MoveToElement(allPages).Click();
                    hoverAction.Build().Perform();
                    break;
            }
        }

        public static void SelectPost(string postTitle)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText(postTitle));
            postLink.Click();
        }
    }

    public enum PostType
    {
        Page
    }
}
