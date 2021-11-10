using System;
using System.Collections.Generic;
using System.Text;
using bddUItests.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace bddUItests.Steps
{
    [Binding]
    class DashboardSteps
    {
        private DashboardPage _dashboardPage;
        public DashboardSteps(DashboardPage dashBoardPage)
        {
            _dashboardPage = dashBoardPage;
        }
        [Then(@"I should see ""(.*)"" title on DashboardPage")]
        public void ThenIShouldSeeTitleOnDashboardPage(string p0)
        {
            _dashboardPage.PageMainTitle.Text.Should().Be(p0);
        }

        [Then(@"I should see below Dashboard columns on DashboardPage")]
        public void ThenIShouldSeeBelowDashboardColumnsOnDashboardPage(Table table)
        {
        
            _dashboardPage.FieldOneHeader.Text.Trim().Should().Be(table.Rows[0][0].Trim());
            _dashboardPage.FieldTwoHeader.Text.Should().Be(table.Rows[0][1]);
            _dashboardPage.FieldThreeHeader.Text.Should().Be(table.Rows[0][2]);
        }
        [Then(@"I should see below Legend categories on DashboardPage")]
        public void ThenIShouldSeeBelowLegendCategoriesOnDashboardPage(Table table)
        {
            _dashboardPage.ValidateLegendCategories(table);
        }

        [When(@"I have clicked on MyTimeSheet link")]
        public void WhenIHaveClickedOnMyTimeSheetLink()
        {
            _dashboardPage.ClickOnMyTimeSheet();
        }
        [Then(@"I should see section as ""(.*)"" on mytimesheet")]
        public void ThenIShouldSeeSectionAsOnMytimesheet(string p0)
        {
            var ff = _dashboardPage.ActionsPerformedLabel.Text.Trim();
            _dashboardPage.ActionsPerformedLabel.Text.Trim().Should().Be(p0);
        }

        [When(@"I should see below actions performed on the timesheet")]
        public void WhenIShouldSeeBelowActionsPerformedOnTheTimesheet(Table table)
        {
            _dashboardPage.VerifyActionsOnTimeSheet(table);
           // ScenarioContext.Current.Pending();
        }

        [Then(@"I should see ""(.*)"" in the Time tabPage")]
        public void ThenIShouldSeeInTheTimeTabPage(string p0)
        {
            _dashboardPage.MyTimeSheetStatus.Text.Trim().Should().Be(p0);
        }




    }
}
