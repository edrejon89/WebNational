using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTests
{
    [TestClass]
    public class CP22HistorialPedidosChrome
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        //[ClassInitialize]
        //public static void InitializeClass(TestContext testContext)
        //{
        //    
        //}

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
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("deny-permission-prompts");
            options.AddArgument("--no-sandbox");
            driver = new ChromeDriver("C:\\Users\\ADMDBQA.user\\Documents\\chromedriver", options);
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            // Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP22HistorialPedidosChromeTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP22_configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[class='btn green uppercase'")).Click();
                Thread.Sleep(1000);

                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class='btn btn-primary dropdown-toggle']"));
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Configuración")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Pedidos")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Historial de pedidos")).Click();
                Thread.Sleep(2000);
                IReadOnlyCollection<IWebElement> btnExcel = driver.FindElements(By.CssSelector("button[class='btn-sm btn btn-success btn-labeled fa fa-file-excel-o btn-lg pull-right']"));
                btnExcel.ElementAt(Int32.Parse(parametros[3])).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
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
