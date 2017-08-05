using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static int lastCount;

        public static int PreviousPostCount
        {
            get { return lastCount; }
        }

        public static int CurrentPostCount
        {
            get { return GetPostCount(); }
        }

        public static void GoTo(PostType postType)
        {
            switch (postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;

                case PostType.Posts:
                    LeftNavigation.Posts.AllPosts.Select();
                    break;
            }
        }

        public static void SelectPost(string postTitle)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText(postTitle));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.ClassName("displaying-num")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }


        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = row.FindElements(By.LinkText(title));
                if (links.Count > 0)
                {
                    Actions moveAction = new Actions(Driver.Instance);
                    moveAction.MoveToElement(links[0]).Build().Perform();
                    Driver.Instance.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }

        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
