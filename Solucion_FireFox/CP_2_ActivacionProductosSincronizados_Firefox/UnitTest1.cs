using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Sync_CP_2_ActivacionProductosSincronizados_Firefox
{
    [TestClass]
    public class CP2ActivacionProductosSincronizadosFirefox
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
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP2ActivacionProductosSincronizadosFirefoxTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\SyncCP2_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Click();
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[class = 'btn green uppercase']")).Click();
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class = 'btn btn-primary dropdown-toggle']"));
                Thread.Sleep(8000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.LinkText("Configuración")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Zonas de reparto'])[1]/following::strong[1]")).Click();
                driver.FindElement(By.LinkText("Menú de productos")).Click();
                //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ACTIVIDAD'])[1]/following::span[1]")).Click();
                //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='ACTIVIDAD'])[2]/following::span[1]")).Click();
                Thread.Sleep(8000);
                IReadOnlyCollection<IWebElement> switches = driver.FindElements(By.CssSelector("span[class='switchery switchery-small'"));
                Thread.Sleep(15000);
                switches.ElementAt(Int32.Parse(parametros[3])).Click();
                Thread.Sleep(2000);
                switches.ElementAt(Int32.Parse(parametros[4])).Click();
                Thread.Sleep(8000);
                driver.FindElement(By.LinkText("Pruebas Walook")).Click();
                driver.FindElement(By.LinkText("Cerrar sesión")).Click();
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