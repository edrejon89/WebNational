using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP03CrearCuentaGoogleFirefox
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [TestInitialize]
        public void InitializeTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("dom.webnotifications.enabled", false);
            options.SetPreference("dom.disable_open_during_load", false);
            options.SetPreference("dom.disable_beforeunload", true);
            driver = new FirefoxDriver("C:\\Users\\ADMDBQA.user\\Documents\\geckodriver", options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(65);
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
        public void TheCP03CrearCuentaGoogleFirefoxTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP3_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("span[class='icon fa fa-google']")).Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.FindElement(By.CssSelector("input[type='email']")).Clear();
                driver.FindElement(By.XPath("//*[@id='identifierId']")).SendKeys(parametros[0] + Keys.Enter);
                Thread.Sleep(5000);
               // driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='¿Has olvidado tu correo electrónico?'])[1]/following::span[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("input[type='password']")).Clear();
                driver.FindElement(By.CssSelector("input[type='password']")).SendKeys(parametros[1]);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("#passwordNext > content > span")).Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Window(driver.WindowHandles.First());
                driver.FindElement(By.LinkText("Registrarte aquí")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("div[id='customBtn']")).Click();
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