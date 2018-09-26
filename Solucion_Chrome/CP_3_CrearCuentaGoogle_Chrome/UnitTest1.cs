using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP03CrearCuentaChromeChome
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void InitializeTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("deny-permission-prompts");
            options.AddArgument("--no-sandbox");
            driver = new ChromeDriver("C:\\Users\\ADMDBQA.user\\Documents\\chromedriver", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseURL = "https://app.softrestaurant.com.mx";
            //verificationErrors = new StringBuilder();
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }



        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP03CrearCuentaChromeChomeTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP3_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                Thread.Sleep(5000);
                driver.FindElement(By.Id("customBtn")).Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.FindElement(By.Id("identifierId")).Clear();
                driver.FindElement(By.Id("identifierId")).SendKeys(parametros[0]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("identifierNext")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Name("password")).Clear();
                driver.FindElement(By.Name("password")).SendKeys(parametros[1]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("passwordNext")).Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(driver.WindowHandles.First());
                Thread.Sleep(4000);
                driver.FindElement(By.LinkText("Registrarte aquí")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("customBtn")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input[id='Password']")).Clear();
                driver.FindElement(By.CssSelector("input[id='Password']")).SendKeys(parametros[1]);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("input[id='ConfirmPassword']")).Clear();
                driver.FindElement(By.CssSelector("input[id='ConfirmPassword']")).SendKeys(parametros[1]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("registerbtn")).Click();

            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
        private string[] LeerCSV(string path)
        {
            string line;
            string[] row;
            using (StreamReader readFile = new StreamReader(path))
            {
                line = readFile.ReadLine();
                row = line.Split(',');
            }
            return row;
        }
    }
}