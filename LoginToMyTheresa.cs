using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace QA_Challenge
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class LoginToMyTheresa<TWebDriver> where TWebDriver : IWebDriver, new()
    {
            public IWebDriver _driver;

            [Test]
            public void Can_Visit_MyTheresaPage()
            {
                _driver = new TWebDriver();

            // Navigate to the MyTheresa url
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://www.mytheresa.com/ende/men.html");
            //----for registering a user if needed-----
            //_driver.FindElement(By.XPath("//div[@id='meta_nav_wrapper_desktop']//a[@id='myaccount']")).Click();
            //_driver.FindElement(By.XPath("//div//input[@id='firstname']")).SendKeys("Devyani");
            //_driver.FindElement(By.XPath("//div//input[@id='lastname']")).SendKeys("D");
            //_driver.FindElement(By.XPath("//div//input[@name='email']")).SendKeys("dd@maildrop.cc");
            //_driver.FindElement(By.XPath("//div//input[@name='password']")).SendKeys("Happy.123");
            //_driver.FindElement(By.XPath("//div//input[@name='confirmation']")).SendKeys("Happy.123");
            //_driver.FindElement(By.XPath("//div//button[@title='Register']"));

            //------for logging in-------
            IWebElement element = _driver.FindElement(By.XPath("//div[@id='meta_nav_wrapper_desktop']//a[@id='myaccount']"));
            Actions ac = new Actions(_driver);
            ac.MoveToElement(element).Perform();
            _driver.FindElement(By.XPath("//div//input[@id='email']")).SendKeys("devayani@maildrop.cc");
            _driver.FindElement(By.XPath("//div//input[@id='pass']")).SendKeys("Happy.123");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//div//button[@name='send']")).Click();
            }

            [TearDown]
            public void FixtureTearDown()
            {
                if (_driver != null)
                    _driver.Close();
            }
    }
}