using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OpenQA.Selenium.Firefox;
using WindowsInput;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class EliminacionGruposSubgrupos
    {
        private static IWebDriver driver;
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
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(65);
            baseURL = "https://app.softrestaurant.com.mx";
        }

        [TestMethod]
        public void TheEliminacionGruposSubgruposTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP12_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class='btn btn-primary dropdown-toggle']"));
                Thread.Sleep(5000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Productos")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Grupos y SubGrupos")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> btnsEliminarSubgrupos = driver.FindElements(By.CssSelector("button[class = 'btn btn-default btn-sm buttondisable']"));
                btnsEliminarSubgrupos.ElementAt(btnsEliminarSubgrupos.Count - 1).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'confirm']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'ok']")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> btnsEliminarGrupos = driver.FindElements(By.CssSelector("button[class = 'btn btn-mint btn-sm buttondisable'] + button[class = 'btn btn-primary btn-sm buttondisable'] + button[class = 'btn btn-default btn-sm buttondisable']"));
                btnsEliminarGrupos.ElementAt(btnsEliminarGrupos.Count - 1).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'confirm']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'ok']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
                Thread.Sleep(500);
                driver.FindElement(By.LinkText("Cerrar sesión")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("email")).Clear();
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
