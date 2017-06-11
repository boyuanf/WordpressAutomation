using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class NewPostPage
    {
        static By postButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[3]/a/div[3]");
        static By addNewButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[3]/ul/li[3]/a");

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.Name("post_title"));
                if (title != null)
                {
                    return title.GetAttribute("value");
                }
                return "";
            }
        }

        public static void GoTo()
        {
            Driver.Action.MoveToElement(Driver.Instance.FindElement(postButton)).Build().Perform();
            WebDriverWait waitAddNew = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            var addNew = waitAddNew.Until(x => x.FindElement(addNewButton));
            Actions hoverAction = Driver.Action.MoveToElement(addNew).Click();
            hoverAction.Build().Perform();
        }

        public static CreatePostCommand CreatePostWithTitle(string postTitle)
        {
            return new CreatePostCommand(postTitle);
        }

        public static void GoToNewPost()
        {
            var message = Driver.Instance.FindElement(By.Id("message"));
            var newPostlink = message.FindElements(By.TagName("a"))[0];
            newPostlink.Click();
        }

        public static bool IsInEditMode()
        {
            // need to wait for the page to be fully loaded before check the header
            WebDriverWait waitEditTitle = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            waitEditTitle.Until(x => x.FindElement(By.XPath("html/body/div[1]/div[2]/div[2]/div[1]/div[4]/form/div/div/div[1]/div[2]/div/div[2]/div[2]/div/div[1]/div/div[1]/div")));

            return Driver.Instance.FindElement(By.ClassName("wp-heading-inline")).Text == "Edit Page";
        }
    }

    public class CreatePostCommand
    {
        private string postTitle;
        private string postBody;

        private By titleInput = By.XPath("html/body/div[1]/div[2]/div[2]/div[1]/div[4]/form/div/div/div[1]/div[1]/div[1]/input");
        private By publishButton = By.Id("publish");

        public CreatePostCommand(string postTitle)
        {
            this.postTitle = postTitle;
        }

        public CreatePostCommand WithBody(string postBody)
        {
            this.postBody = postBody;
            return this;
        }

        public void Publish()
        {
            Driver.Instance.FindElement(titleInput).SendKeys(postTitle);

            Driver.Instance.SwitchTo().Frame("content_ifr");
            Driver.Instance.SwitchTo().ActiveElement().SendKeys(postBody);
            Driver.Instance.SwitchTo().DefaultContent();
            Thread.Sleep(1000);

            Driver.Instance.FindElement(publishButton).Click();
        }
    }
}
