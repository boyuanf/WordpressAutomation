using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

                    // Demo how to log if error in the test framework
                    //if (IsAt)
                    //    Error.Log("Did not navigate to all posts!");

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
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));
                if (links.Count > 0)
                {
                    Actions moveAction = new Actions(Driver.Instance);
                    moveAction.MoveToElement(links[0]).Build().Perform();
                    Driver.Instance.FindElement(By.ClassName("submitdelete")).Click();
                    return;
                }
            }

        }

        public static void SearchForPost(string searchString)
        {
            if (!IsAt)
                GoTo(PostType.Posts);

            var searchBox = Driver.Instance.FindElement(By.Id("post-search-input"));
            searchBox.SendKeys(searchString);

            var searchButton = Driver.Instance.FindElement(By.Id("search-submit"));
            searchButton.Click();

        }

        static By h1Header = By.XPath("html/body/div[1]/div[2]/div[2]/div[1]/div[4]/h1");

        public static bool IsAt
        {
            get
            {
                var h1Tag = Driver.Instance.FindElements(h1Header);
                if (h1Tag.Count > 0)
                {
                    return h1Tag[0].Text == "Posts";
                }
                return false;
            }
            
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
