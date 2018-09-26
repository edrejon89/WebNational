using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using WindowsInput;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class ConfiguracionCuentas
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
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("deny-permission-prompts");
            options.AddArgument("--no-sandbox");
            driver = new ChromeDriver("C:\\Users\\ADMDBQA.user\\Documents\\chromedriver", options);
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            
        }

        [TestMethod]
        public void TheConfiguracionCuentasTest()
        {
            try { 
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP6_Configuracion.txt");
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
                driver.FindElement(By.LinkText("Configuración")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Restaurant_Description")).Click();
                driver.FindElement(By.Id("Restaurant_Description")).Clear();
                driver.FindElement(By.Id("Restaurant_Description")).SendKeys(parametros[3]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnlocationtab")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnLocation")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnprofiletab")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Profile_Category_chosen")).Click();
                Thread.Sleep(1000);
                InputSimulator inputSimulator = new InputSimulator();
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Profile_Feature_chosen")).Click();
                Thread.Sleep(1000);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Profile_GoodFor_chosen")).Click();
                Thread.Sleep(1000);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("label[for = 'demo-form-radio']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnconfigurationtab")).Click();
                Thread.Sleep(3000);
                IReadOnlyCollection<IWebElement> switches = driver.FindElements(By.CssSelector("span[class = 'switchery switchery-small']"));
                switches.ElementAt(0).Click();
                Thread.Sleep(1000);
                switches.ElementAt(1).Click();
                Thread.Sleep(1000);
                switches.ElementAt(2).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("number1")).Click();
                driver.FindElement(By.Id("number1")).Clear();
                driver.FindElement(By.Id("number1")).SendKeys(parametros[4]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("number2")).Click();
                driver.FindElement(By.Id("number2")).Clear();
                driver.FindElement(By.Id("number2")).SendKeys(parametros[5]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnpaymentmethodtab")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("label[for = 'paymentMethod_2']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Restaurant_DealerChange")).Click();
                driver.FindElement(By.Id("Restaurant_DealerChange")).Clear();
                driver.FindElement(By.Id("Restaurant_DealerChange")).SendKeys(parametros[6]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnAddCreditCard")).Click();
                Thread.Sleep(2000);
                driver.SwitchTo().Frame(driver.FindElement(By.Id("frameWebPay")));
                Thread.Sleep(1000);
                driver.FindElement(By.Id("cardnum")).Click();
                driver.FindElement(By.Id("cardnum")).Clear();
                driver.FindElement(By.Id("cardnum")).SendKeys(parametros[7]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("cardexp")).Click();
                driver.FindElement(By.Id("cardexp")).Clear();
                driver.FindElement(By.Id("cardexp")).SendKeys(parametros[8]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ccCVC")).Click();
                driver.FindElement(By.Id("ccCVC")).Clear();
                driver.FindElement(By.Id("ccCVC")).SendKeys(parametros[9]);
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("input[type = 'email']")).Click();
                driver.FindElement(By.CssSelector("input[type = 'email']")).Clear();
                driver.FindElement(By.CssSelector("input[type = 'email']")).SendKeys(parametros[10]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnPagoSin")).Click();
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
