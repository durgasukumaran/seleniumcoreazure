using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;

namespace SeleniumCoreDemo
{
    public class Tests
    {
        //Hooks in NUnit
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            //Add chrome options 
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless", "--window-size=1920,1200", "--no-sandbox");

            //Browser driver
            IWebDriver webDriver = new ChromeDriver(options);


            //Navigate to URL
            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");


            //Identify Login
            IWebElement lnklogin = webDriver.FindElement(By.LinkText("Login")) ;

            //operation (Act)
            lnklogin.Click();

            //UserName

            var txtUserName = webDriver.FindElement(By.Name("UserName"));

            //Assertion
            Assert.That(txtUserName.Displayed, Is.True);

            txtUserName.SendKeys("admin");
            webDriver.FindElement(By.Name("Password")).SendKeys("password");
            webDriver.FindElement(By.XPath("//input[@value='Log in']")).Submit();
            var lnkEmployeeDetails = webDriver.FindElement(By.LinkText("Employee Details"));
            Assert.That(lnkEmployeeDetails.Displayed, Is.True);
            webDriver.Quit();

        }
    }
}