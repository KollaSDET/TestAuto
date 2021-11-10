using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace bddUItests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IObjectContainer _objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

       public static ConfigSetting config;

        static string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string projectPath = appDirectory.Substring(0,appDirectory.IndexOf("\\bin"));

        static string  configSettingPath = Path.Combine(projectPath,@"Configuration\\configsetting.json");

        //public static string configSettingPath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration\\configsetting.json";
       // public static string configSettingPath = @"C:\Users\S\source\repos\TestAuto\bddUItests\Configuration\configsetting.json";
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            config = new ConfigSetting();
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(configSettingPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

                    }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            //string chromedriverpath = @"C:\Users\S\source\repos\TestAuto\bddUItests\ChromeBrowser\";
            //TODO: implement logic that has to run before executing each scenario
            IWebDriver webdriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));//chromedriverpath
            _objectContainer.RegisterInstanceAs(webdriver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            IWebDriver driver = _objectContainer.Resolve<IWebDriver>();
            driver.Quit();
            if(driver != null) driver=null;
        }
  
    }
}
