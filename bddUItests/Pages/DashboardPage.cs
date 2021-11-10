using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace bddUItests.Pages
{
    class DashboardPage
    {
        private IWebDriver _webDriver;

        public DashboardPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public IWebElement PageMainTitle => _webDriver.Find(By.ClassName("head"));

        public IWebElement FieldOneHeader => _webDriver.Find(By.XPath("//fieldset[@id='panel_resizable_1_0']//legend"));
        public IWebElement FieldTwoHeader => _webDriver.Find(By.XPath("//fieldset[@id='panel_resizable_1_1']//legend"));
        public IWebElement FieldThreeHeader => _webDriver.Find(By.XPath("//fieldset[@id='panel_resizable_1_2']//legend"));
        public IWebElement LegendTable => _webDriver.Find(By.XPath("//div[@id='div_legend_pim_employee_distribution_legend']//table"));
        public IWebElement MyTimeSheetLink => _webDriver.Find(By.XPath("//div[@class ='quickLaunge']//a[contains(@href,'viewMyTimesheet')]"));
        //public IWebElement ActionsPerformedLabel => _webDriver.Find(By.XPath("//span[@class ='quickLinkText' and contains(text(),'My Timesheet')]"));
        public IWebElement ActionsPerformedLabel => _webDriver.Find(By.Id("actionLogHeading"));
       
        public IWebElement MyTimeSheetPerformedTable => _webDriver.Find(By.XPath("//div[@class='box miniList']//table"));
        public IWebElement MyTimeSheetStatus => _webDriver.Find(By.Id("timesheet_status"));


        public void ValidateLegendCategories(Table table)
        {
            IList<IWebElement> trElements =  LegendTable.FindElements(By.XPath("//tbody//tr//td[@class='legendLabel']"));
            for (int i =0;i< table.RowCount;i++)
            {
                var actualLegendItem = trElements[i].Text.Trim();
                var expectedLegendItem = table.Rows[i][0];
                actualLegendItem.Should().Be(expectedLegendItem);
            }
        }

        public void ClickOnMyTimeSheet()
        {
            MyTimeSheetLink.Click();
        }

        public void VerifyActionsOnTimeSheet(Table table)
        {
             IList<IWebElement> actionsHeaderList = MyTimeSheetPerformedTable.FindElements(By.XPath("//thead//tr//th[contains(@id,'action')]"));

            IList<IWebElement> actionsRecordList = MyTimeSheetPerformedTable.FindElements(By.XPath("//tbody//tr//td[contains(@id,'action')]"));
            //dynamic credentials = table.CreateDynamicInstance();
            for (int i = 0; i < table.Header.Count; i++)
            {
                
                var actualHeaderItem = actionsHeaderList[i].Text.Trim();
                var expectedHeader = table.Header;
                var expectedHeaderItem = expectedHeader.ElementAt(i);
                var actualRecordItem = actionsRecordList[i].Text.Trim();
                var expectedRecordItem = table.Rows[0][i].Trim();
                actualHeaderItem.Should().Be(expectedHeaderItem);
                actualRecordItem.Should().Be(expectedRecordItem);

            }
        }
    }
}
