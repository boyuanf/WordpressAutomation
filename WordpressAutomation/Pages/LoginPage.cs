using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WordpressAutomation
{
    public class LoginPage
    {
        public static void GoTo()
        {
            //Driver.Instance.Navigate().GoToUrl("http://localhost:17758/wp-login.php");
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");

        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        private string userName;
        private string password;

        By userNameInput = By.Id("user_login");
        private By passwordInput = By.Id("user_pass");
        By loginButton = By.Id("wp-submit");


        public LoginCommand(string userName)
        {
            this.userName = userName;
        }


        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            Driver.Instance.FindElement(userNameInput).SendKeys(userName);
            Driver.Instance.FindElement(passwordInput).SendKeys(password);
            Driver.Instance.FindElement(loginButton).Click();

        }
    }
}
