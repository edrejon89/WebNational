using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;





namespace SeleniumTests
{
    [TestClass]
    public class CP1CrearCuentaFirefox
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

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


        [TestInitialize]
        public void InitializeTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("dom.webnotifications.enabled", false);
            options.SetPreference("dom.disable_open_during_load", false);
            options.SetPreference("dom.disable_beforeunload", true);
            options.SetPreference("geo.enabled", false);
            driver = new FirefoxDriver("C:\\Users\\ADMDBQA.user\\Documents\\geckodriver", options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            baseURL = "https://app.softrestaurant.com.mx";
        }




        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP1CrearCuentaFirefoxTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP1_configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.CssSelector("#form > div.create-account > p > a")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.Id("FirstName")).Click();
                driver.FindElement(By.Id("FirstName")).Click();
                driver.FindElement(By.Id("FirstName")).Clear();
                driver.FindElement(By.Id("FirstName")).SendKeys(parametros[0]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("LastName")).Clear();
                driver.FindElement(By.Id("LastName")).SendKeys(parametros[1]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys(parametros[2]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[3]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ConfirmPassword")).Clear();
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys(parametros[3]);
                //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='reCAPTCHA'])[1]/preceding::div[4]")).Click();
                //driver.FindElement(By.Id("ConfirmPassword")).SendKeys(Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Tab + Keys.Space);
                Thread.Sleep(2000);
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
