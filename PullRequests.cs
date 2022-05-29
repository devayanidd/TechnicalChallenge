using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace QA_Challenge
{
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class PullRequests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IWebDriver driver;

        [Test]
        public void Can_Count_PullRequests()
        {
            driver = new TWebDriver();

            // Navigate to the MyTheresa url
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://github.com/appwrite/appwrite/pulls");

            String no_of_pull_requests = driver.FindElement(By.Id("pull-requests-repo-tab-count")).Text;
            Console.WriteLine(no_of_pull_requests);
            Thread.Sleep(5000);
            String fileName = @"ListOfPR.csv";
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream file = File.Create(fileName))
            {
                //adding complete list of PR's
                String data = driver.FindElement(By.XPath("//div[@class='js-navigation-container js-active-navigation-container']")).Text;
                
                // Adding list of PRs to file with NameOfPR,Time created & Author name
                String name_of_pr = driver.FindElement(By.XPath("//div[@class='js-navigation-container js-active-navigation-container']//a")).Text;
                String time = driver.FindElement(By.XPath("//div[@class='js-navigation-container js-active-navigation-container']//span[@class='opened-by']//relative-time")).GetAttribute("title");
                String author = driver.FindElement(By.XPath("//div[@class='js-navigation-container js-active-navigation-container']//span[@class='opened-by']//a")).Text;
                Byte[] title = new UTF8Encoding(true).GetBytes(data);
                file.Write(title, 0, title.Length);
                Byte[] title1 = new UTF8Encoding(true).GetBytes(time);
                file.Write(title1, 0, title1.Length);
                Byte[] title2 = new UTF8Encoding(true).GetBytes(author);
                file.Write(title2, 0, title2.Length);
            }
        }

        [TearDown]
        public void FixtureTearDown()
        {
            if (driver != null)
                driver.Close();
        }
    }
}
