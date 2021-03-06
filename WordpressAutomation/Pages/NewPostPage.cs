﻿using System;
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
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePostWithTitle(string postTitle)
        {
            return new CreatePostCommand(postTitle);
        }

        public static void GoToNewPost()
        {
            WebDriverWait waitEditTitle = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
            var message = waitEditTitle.Until(x => x.FindElement(By.Id("message")));
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
        private By publishButton = By.XPath("html/body/div[1]/div[2]/div[2]/div[1]/div[4]/form/div/div/div[2]/div/div[1]/div/div/div[2]/div[2]/input[2]");

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

            Driver.Sleep(TimeSpan.FromSeconds(5));

            Driver.Instance.FindElement(publishButton).Click();
        }
    }
}
