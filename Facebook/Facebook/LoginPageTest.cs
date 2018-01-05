using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Facebook
{
    [TestFixture]
    public class LoginPageTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUpTest()
        {
            driver = new ChromeDriver(@"C:\\CSharp\\Facebook\\Facebook\\Files");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        [Test, Order(1)]
        public void OpenFBURLAndVerifyTitle()
        {
            driver.Url = "https://www.facebook.com/";

            String currentTitle = driver.Title.Trim();
            Console.WriteLine("Current Title = " + currentTitle);

            String currentURL = driver.Url.Trim();
            Console.WriteLine("Current URL = " + currentURL);

            Console.WriteLine("This is TestMethod");

            Assert.AreEqual(currentTitle, "Facebook - Log In or Sign Up");
            Assert.AreEqual(currentURL, "https://www.facebook.com/");

        }
        [Test, Order(2)]
        public void verifyUsernamePassword ()
        {
            bool emailTextBoxCheck = driver.FindElement(By.XPath(".//*[@id='email']")).Displayed;
            bool passTextBoxCheck = driver.FindElement(By.XPath(".//*[@id='pass']")).Displayed;

            Assert.IsTrue(emailTextBoxCheck);
            Assert.IsTrue(passTextBoxCheck);
        }

        [Test, Order(3)]
        public void LoginIntoFBAccount()
        {
            driver.FindElement(By.XPath(".//*[@id='email']")).SendKeys("tej19852003@gmail.com");
            driver.FindElement(By.XPath(".//*[@id='pass']")).SendKeys("Avani241938");
            driver.FindElement(By.XPath(".//input[@value='Log In'][@type='submit']")).Click();
            System.Threading.Thread.Sleep(5000);

        }
        [Test, Order(100)]
        public void LogOutFBAccount()
        {
            driver.FindElement(By.XPath(".//*[@id='userNavigationLabel']")).Click();
            System.Threading.Thread.Sleep(2000);
            driver.FindElement(By.XPath(".//*[@id='js_1z']/div/div/ul/li[14]/a")).Click();
            System.Threading.Thread.Sleep(5000);

            bool emailTextBoxCheck = driver.FindElement(By.XPath(".//*[@id='email']")).Displayed;
            bool passTextBoxCheck = driver.FindElement(By.XPath(".//*[@id='pass']")).Displayed;

            Assert.IsTrue(emailTextBoxCheck);
            Assert.IsTrue(passTextBoxCheck);

        }

        [OneTimeTearDown]
        public void OneTimeTearDownMethod ()
        {
            driver.Quit();
        }
    }
}
