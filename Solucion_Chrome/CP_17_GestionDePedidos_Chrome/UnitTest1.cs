using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WindowsInput;
namespace SeleniumTests
{
    [TestClass]
    public class CP17GestionPedidosChromeTest
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
        public void gestionDePedidos()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP17_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(3000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class = 'btn btn-primary dropdown-toggle']"));
                Thread.Sleep(3000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("#group-delivery > a > span")).Click();
                Thread.Sleep(6000);
                driver.FindElement(By.CssSelector("#group-delivery > ul > li:nth-child(1)")).Click();
                Thread.Sleep(6000);
                driver.FindElement(By.CssSelector("#tabOptions > li:nth-child(2) > a > span.hidden-xs.text-bold")).Click();
                Thread.Sleep(6000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Efectivo'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancelar'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Pendientes'])[1]/following::span[3]")).Click();
                Thread.Sleep(6000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Efectivo'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancelar'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("[href = '#tab-food-TOGO']")).Click();
                Thread.Sleep(6000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Efectivo'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancelar'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Listo para recoger'])[1]/following::span[3]")).Click();
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