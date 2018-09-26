using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WindowsInput;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CreacionDeProductos
    {
        private static IWebDriver driver;
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
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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

       
        [TestMethod]
        public void TheCreacionDeProductosTest()
        {
            try {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP16_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Repite tu contraseña'])[1]/following::button[1]")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class='btn btn-primary dropdown-toggle']"));
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(1000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Productos")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Menú de productos")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnAdd")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("GroupParentId")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("GroupParentId"))).SelectByIndex(1);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("GroupParentId")).Click();
                driver.FindElement(By.Id("GroupId")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("GroupId"))).SelectByIndex(1);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("GroupId")).Click();
                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(parametros[3]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Description")).Click();
                driver.FindElement(By.Id("Description")).Clear();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Description")).SendKeys(parametros[4]);
                driver.FindElement(By.Id("MeasureUnitId")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("MeasureUnitId"))).SelectByText("Pieza");
                Thread.Sleep(1000);
                driver.FindElement(By.Id("MeasureUnitId")).Click();
                driver.FindElement(By.Id("TaxSchemeId")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("TaxSchemeId"))).SelectByIndex(1);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("TaxSchemeId")).Click();
                driver.FindElement(By.Id("PriceWhithTax")).Clear();
                driver.FindElement(By.Id("PriceWhithTax")).SendKeys(parametros[5]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Price")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("a[href = '#tab-product-composed']")).SendKeys(Keys.PageUp);
                driver.FindElement(By.CssSelector("a[href = '#tab-product-composed']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnModifierGroupCatalog")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[class = 'btn btn-xs btn-primary pull-right']")).Click();
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> cerrar = driver.FindElements(By.CssSelector("button[data-dismiss = 'modal']"));
                cerrar.ElementAt(1).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnProductModifierCatalog")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("td[class = 'pull-right'] > button[class = 'btn btn-xs btn-primary pull-right']")).Click();
                Thread.Sleep(1000);
                cerrar.ElementAt(2).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ModifiersProduct_0__ModifierGroupId")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("ModifiersProduct_0__ModifierGroupId"))).SelectByIndex(1);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ModifiersProduct_0__ModifierGroupId")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Producto compuesto'])[1]/following::span[2]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Agregar un comentario")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ElaborationComments_0__Comment")).Click();
                driver.FindElement(By.Id("ElaborationComments_0__Comment")).Clear();
                driver.FindElement(By.Id("ElaborationComments_0__Comment")).SendKeys(parametros[6]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Salir'])[1]/following::span[1]")).Click();
                Thread.Sleep(2000);
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
