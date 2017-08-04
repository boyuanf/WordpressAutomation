using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class DashboardPage
    {
        //static By h1Header = By.TagName("h1");  // can't wait the dashboardpage to be load before failure to find the element
        static By h1Header = By.XPath("html/body/div[1]/div[2]/div[2]/div[1]/div[4]/h1");

        public static bool IsAt
        {
            get
            {
                var h1Tag = Driver.Instance.FindElements(h1Header);
                if (h1Tag.Count > 0)
                {
                    return h1Tag[0].Text == "Dashboard";
                }
                return false;
            }
        }
    }
}
