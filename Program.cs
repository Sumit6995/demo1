using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class AutoNaukriDotNetBot
{
    static void Main()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        using (IWebDriver driver = new ChromeDriver(options))
        {
          
            driver.Navigate().GoToUrl("https://www.naukri.com/mnjuser/homepage");
            Console.WriteLine("🔐 Please login to Naukri manually within 60 seconds...");
            Thread.Sleep(60000); 

          
            string searchUrl = "https://www.naukri.com/dot-net-developer-jobs?k=dot%20net%20developer&exp=2-4&freshtype=1";
            driver.Navigate().GoToUrl(searchUrl);
            Thread.Sleep(5000);

        
            var jobCards = driver.FindElements(By.ClassName("jobTuple"));
            int appliedCount = 0;

            foreach (var card in jobCards)
            {
                try
                {
                    var applyBtn = card.FindElement(By.XPath(".//button[contains(text(),'Apply')]"));
                    applyBtn.Click();
                    appliedCount++;
                    Console.WriteLine($"✅ Applied to job {appliedCount}");
                    Thread.Sleep(3000);
                }
                catch
                {
                    Console.WriteLine("❌ Already applied or no apply button found");
                }

                if (appliedCount >= 10)
                {
                    Console.WriteLine("🚀 Reached daily apply limit (10). Exiting.");
                    break;
                }
            }

            //dfghj

            Console.WriteLine("🎉 Job auto-apply complete!");
        }
    }
}
