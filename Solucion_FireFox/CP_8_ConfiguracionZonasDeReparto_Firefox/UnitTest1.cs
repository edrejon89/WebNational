using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WindowsInput;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class ConfigurarZonasReparto
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
            //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            baseURL = "https://app.softrestaurant.com.mx";
        }

        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheConfigurarZonasRepartoTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP8_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Click();
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class='btn btn-primary dropdown-toggle']"));
                Thread.Sleep(3000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Promociones")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Monitor de pedidos'])[1]/following::i[1]")).Click();
                Thread.Sleep(8000);
                driver.FindElement(By.LinkText("Zonas de reparto")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnAdd")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnAddZipCode")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("filterCode")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("filterCode")).Clear();
                driver.FindElement(By.Id("filterCode")).SendKeys(parametros[3]);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Guardar'])[1]/following::span[2]")).Click();
                Thread.Sleep(7000);
                driver.FindElement(By.Id("CheckLabel")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnClosePaneEdit")).Click();
                Thread.Sleep(000);
                driver.FindElement(By.Id("Name")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(parametros[4]);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("ShippingCost")).Click();
                driver.FindElement(By.Id("ShippingCost")).Clear();
                driver.FindElement(By.Id("ShippingCost")).SendKeys(parametros[5]);
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'cancel']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("a[href = '/RestaurantWizard']")).Click(); //debe quitarse
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Cerrar sesión")).Click();
                Thread.Sleep(2000);
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

