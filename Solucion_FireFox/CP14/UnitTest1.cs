using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WindowsInput;
using System.Collections.Generic;
using System.Linq;
namespace SeleniumTests
{
    [TestClass]
    public class CP14CreacionImpuestoChrome
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
            options.SetPreference("geo.enabled", false);
            driver = new FirefoxDriver("C:\\Users\\ADMDBQA.user\\Documents\\geckodriver", options);
            driver.Manage().Window.Maximize();
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
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
        public void TheCP14CreacionImpuestoChrome()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP14_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(2000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class = 'btn btn-primary dropdown-toggle']"));
                Thread.Sleep(5000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                Thread.Sleep(1500);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Configuración")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Horarios de apertura'])[1]/following::strong[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Impuestos")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Agregar")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(parametros[3]);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("Description")).Click();
                driver.FindElement(By.Id("Description")).Clear();
                driver.FindElement(By.Id("Description")).SendKeys(parametros[4]);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("addtax")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ListTax_0__Name")).Click();
                driver.FindElement(By.Id("ListTax_0__Name")).Clear();
                driver.FindElement(By.Id("ListTax_0__Name")).SendKeys(parametros[5]);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ListTax_0__Acronim")).Clear();
                driver.FindElement(By.Id("ListTax_0__Acronim")).SendKeys(parametros[6]);
                driver.FindElement(By.Id("ListTax_0__ETaxType")).Click();
                Thread.Sleep(3000);
                new SelectElement(driver.FindElement(By.Id("ListTax_0__ETaxType"))).SelectByIndex(1);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ListTax_0__ETaxType")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("ListTax_0__TaxPercent")).Click();
                driver.FindElement(By.Id("ListTax_0__TaxPercent")).Clear();
                driver.FindElement(By.Id("ListTax_0__TaxPercent")).SendKeys(parametros[7]);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Salir'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='El esquema se registro correctamente ¿Deseas registrar uno nuevo?'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
                Thread.Sleep(3000);
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