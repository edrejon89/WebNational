using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using WindowsInput;

namespace SeleniumTests
{
    [TestClass]
    public class CP18GestionProductosChromeTest
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



        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP18GestionProductosChromeTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP18_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Repite tu contraseña'])[1]/following::button[1]")).Click();
                Thread.Sleep(2000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class = 'btn btn-primary dropdown-toggle']"));
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(1000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Configuración")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Horarios de apertura'])[1]/following::strong[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.LinkText("Gestión de precio de productos")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("cbxTypeAmountPercent")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("cbxTypeAmountPercent"))).SelectByText(parametros[3]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("cbxTypeAmountPercent")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("cbxTypeWithNoneImp")).Click();
                Thread.Sleep(1000);
                new SelectElement(driver.FindElement(By.Id("cbxTypeWithNoneImp"))).SelectByText(parametros[4]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("cbxTypeWithNoneImp")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("incrementAmount")).Click();
                driver.FindElement(By.Id("incrementAmount")).Clear();
                driver.FindElement(By.Id("incrementAmount")).SendKeys(parametros[5]);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("span[class='switchery switchery-small']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnSaveValueChanges")).SendKeys(Keys.PageDown);
                driver.FindElement(By.Id("btnSaveValueChanges")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler='confirm']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("button[data-bb-handler='ok']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
                Thread.Sleep(1000);
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