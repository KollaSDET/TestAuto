using System;
using System.Collections.Generic;
using System.Text;
using bddUItests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace bddUItests.Steps
{
    [Binding]
    class LoginSteps
    {
        private LoginPage _loginpage;
        public LoginSteps(LoginPage loginpage)
        {
            _loginpage = loginpage;
        }

        [Given(@"I have navigated to Login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            _loginpage.GoToLoginPage();
        }

        [Given(@"I have entered username on Login Page")]
        public void GivenIHaveEnteredUsernameOnLoginPage()
        {
            _loginpage.EnterUsername();
        }

        [Given(@"I have entered password on Login Page")]
        public void GivenIHaveEnteredPasswordOnLoginPage()
        {
            _loginpage.EnterPassword();
        }

        [Given(@"I have clicked on LOGIN button")]
        [When(@"I have clicked on LOGIN button")]
        public void WhenIHaveClickedOnLOGINButton()
        {
            _loginpage.ClickLoginButton();
        }              

        [Then(@"I should see my dashboard")]
      
        [Then(@"I should see Welcome message with username")]
        public void ThenIShouldSeeWelcomeMessageWithUsername(Table table)
        {
            string loggedInUser = table.Rows[0][0];
            loggedInUser.Should().Be(_loginpage.LoggedInUserNameLabel.Text);

        }

        [Given(@"I have entered below Login details")]
        public void GivenIHaveEnteredBelowLoginDetails(Table table)
        {
            if (!string.IsNullOrEmpty(table.Rows[0][0].ToString()))
            {
                _loginpage.EnterUsername(table.Rows[0][0]);
            }
            _loginpage.EnterPassword(table.Rows[0][1]);

        }

        [Then(@"I should see ""(.*)"" on the LoginPanel")]
        public void ThenIShouldSeeOnTheLoginPanel(string p0)
        {
            _loginpage.InvalidCredentialsLabel.Text.Should().Be(p0);
                
        }


    }
}
