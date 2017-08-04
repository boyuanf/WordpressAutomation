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

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
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
