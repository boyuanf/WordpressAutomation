using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpressAutomation
{
    class LeftNavigation
    {
        //static By postButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[3]/a/div[3]");
        //static By addNewButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[3]/ul/li[3]/a");
        //static By pagesButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[5]/a/div[3]");
        //static By allPagesButton = By.XPath("html/body/div[1]/div[1]/div[2]/ul/li[5]/ul/li[2]/a");

        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "Add New");
                }
            }

            public class AllPosts
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-posts", "All Posts");
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-pages", "All Pages");

                    //Driver.Action.MoveToElement(Driver.Instance.FindElement(By.Id("menu-pages"))).Build().Perform();
                    //WebDriverWait waitAllPages = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(5));
                    //var allPages = waitAllPages.Until(x => x.FindElement(By.LinkText("All Pages")));
                    //Actions hoverAction = Driver.Action.MoveToElement(allPages).Click();
                    //hoverAction.Build().Perform();
                }
            }
        }

        public class Dashboard
        {
            public class Home
            {
                public static void Select()
                {
                    MenuSelector.Select("menu-dashboard", "Home");
                }
            }
        }
    }
}


