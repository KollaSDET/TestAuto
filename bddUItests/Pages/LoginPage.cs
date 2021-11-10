using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;


namespace bddUItests.Pages
{
    class LoginPage
    {

        //[Given(@"I have logged into new Application as a Account team member")]
        //public void GivenIHaveLoggedIntoNewApplicationAsAAccountTeamMember()
        //{
        private IWebDriver _webdriver;
        string loginUrl = Hooks.Hooks.config.url;

        //public IWebElement UserName => _webdriver.FindElement(By.XPath("//div[@id='divUsername']//input[@id='txtUsername']"));
        //public IWebElement Password => _webdriver.FindElement(By.XPath("//div[@id='divPassword']//input[@id='txtPassword']"));

        //public IWebElement LoginBtn => _webdriver.FindElement(By.XPath("//div[@id='divLoginButton']//input[@id='btnLogin']"));
        //public IWebElement LoggedInUserNameLabel => _webdriver.FindElement(By.XPath("//div[@id='branding']//a[@id='welcome']"));
        public By UserName_locator => By.XPath("//div[@id='divUsername']//input[@id='txtUsername']");
        public By Password_locator => By.XPath("//div[@id='divPassword']//input[@id='txtPassword']");
        public By LoginButton_locator => By.Id("btnLogin");


        IWebElement UserName => _webdriver.Find(UserName_locator);
        IWebElement Password => _webdriver.Find(Password_locator);       
        public IWebElement LoginBtn => _webdriver.Find(LoginButton_locator);
        public IWebElement LoggedInUserNameLabel => _webdriver.Find(By.Id("welcome"));
        public IWebElement InvalidCredentialsLabel => _webdriver.Find(By.Id("spanMessage"));
        public LoginPage(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }
         public void GoToLoginPage()
        {
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            _webdriver.Navigate().GoToUrl(loginUrl);
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public void EnterUsername()
        {
            UserName.Clear();
            UserName.SendKeys(Hooks.Hooks.config.email);
        }
        public void EnterUsername(string uname)
        {
            UserName.Clear();
            UserName.SendKeys(uname);
        }
        public void EnterPassword()
        {
            Password.Clear();
            Password.SendKeys(Hooks.Hooks.config.password);
        }
        public void EnterPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            LoginBtn.Click();
        }

       
        //ConfigSetting login = DataSourceParser.populateLogin();

        //instead of "DataJson Js = new DataJson()

        //DataJson Js = new DataJson();
    }
}
