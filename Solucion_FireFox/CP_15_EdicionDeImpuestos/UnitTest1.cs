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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;

namespace SeleniumTests
{
    [TestClass]
    public class EdicionDeImpuestos
    {
        private static IWebDriver driver;
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
            //driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            baseURL = "https://app.softrestaurant.com.mx";
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


        [TestMethod]
        public void TheEdicionDeImpuestosTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP15_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(2000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class='btn btn-primary dropdown-toggle']"));
                Thread.Sleep(3000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(8000);
                driver.FindElement(By.LinkText("Productos")).Click();
                Thread.Sleep(8000);
                driver.FindElement(By.LinkText("Impuestos")).Click();
                Thread.Sleep(5000);
                IReadOnlyCollection<IWebElement> btnsEditarImpuesto = driver.FindElements(By.CssSelector("a[class = 'btn btn-sm btn-primary buttondisable buttonhide']"));
                System.Console.Write(btnsEditarImpuesto.Count);
                btnsEditarImpuesto.ElementAt(Int32.Parse(parametros[3])).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(parametros[4]);
                Thread.Sleep(3000);
               driver.FindElement(By.Id("addtax")).SendKeys(Keys.PageDown);
                driver.FindElement(By.Id("addtax")).Click();
                Thread.Sleep(3000);
                IReadOnlyCollection<IWebElement> nombresImpuesto = driver.FindElements(By.Name("ListTax[0].Name"));
                nombresImpuesto.ElementAt(nombresImpuesto.Count - 1).Clear();
                nombresImpuesto.ElementAt(nombresImpuesto.Count - 1).SendKeys(parametros[5]);
                Thread.Sleep(3000);
                IReadOnlyCollection<IWebElement> abrirImpuesto = driver.FindElements(By.CssSelector("span[class = 'footable-toggle']"));
                Thread.Sleep(2000);
                abrirImpuesto.ElementAt(abrirImpuesto.Count - 1).Click();
                Thread.Sleep(3000);
                IReadOnlyCollection<IWebElement> acronimoImpuesto = driver.FindElements(By.Name("ListTax[0].Acronim"));
                Thread.Sleep(3000);
                acronimoImpuesto.ElementAt(acronimoImpuesto.Count - 1).Clear();
                acronimoImpuesto.ElementAt(acronimoImpuesto.Count - 1).SendKeys(parametros[6]);
                Thread.Sleep(5000);
                IReadOnlyCollection<IWebElement> tipoImpuesto = driver.FindElements(By.Name("ListTax[0].ETaxType"));
                new SelectElement(tipoImpuesto.ElementAt(tipoImpuesto.Count - 1)).SelectByIndex(1);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]")).Click();
                Thread.Sleep(10000);
                //driver.FindElement(By.XPath("//*[@id='formAddSchemeTax']/div/div[2]/button")).Click();
                //Thread.Sleep(10000);
                //driver.FindElement(By.CssSelector("#formAddSchemeTax > div > div.panel-footer.text-right > button")).Click();
                // Thread.Sleep(10000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'cancel']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Cerrar sesión")).Click();
                Thread.Sleep(3000);
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
