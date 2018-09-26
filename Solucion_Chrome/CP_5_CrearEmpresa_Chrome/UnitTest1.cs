using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTests
{
    [TestClass]
    public class CrearNuevaEmpresa
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
        public void TheCrearNuevaEmpresaTest()
        {
            string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP5_Configuracion.txt");
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Repite tu contraseña'])[1]/following::button[1]")).Click();
            IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.LinkText("Opciones"));
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Hey!'])[1]/following::img[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("txbtaxid")).Clear();
            driver.FindElement(By.Id("txbtaxid")).SendKeys(parametros[2]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Company_Name")).Click();
            driver.FindElement(By.Id("Company_Name")).Clear();
            driver.FindElement(By.Id("Company_Name")).SendKeys(parametros[3]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Company_TradeName")).Clear();
            driver.FindElement(By.Id("Company_TradeName")).SendKeys(parametros[4]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys(parametros[5]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Company_CompanyInformation_Email")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Company_CompanyInformation_Email")).SendKeys(parametros[6]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys(parametros[7]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("phone2")).Clear();
            driver.FindElement(By.Id("phone2")).SendKeys(parametros[8]);
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("* Seleccionar Logo")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("IMAGEN DE GALERIA")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Selecciona una imagen existente'])[1]/following::a[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Cancelar'])[2]/following::button[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("Company_FiscalAddress_Street")).Clear();
            driver.FindElement(By.Id("Company_FiscalAddress_Street")).SendKeys(parametros[9]);
            driver.FindElement(By.Id("Company_FiscalAddress_Number")).Clear();
            driver.FindElement(By.Id("Company_FiscalAddress_Number")).SendKeys(parametros[10]);
            driver.FindElement(By.Id("Company_FiscalAddress_InternalNumber")).Clear();
            driver.FindElement(By.Id("Company_FiscalAddress_InternalNumber")).SendKeys(parametros[11]);
            driver.FindElement(By.Id("zipcode")).Clear();
            driver.FindElement(By.Id("zipcode")).SendKeys(parametros[12]);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("checkfiscaladdress")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(1000);
            IReadOnlyCollection<IWebElement> nuevasEmpresas = driver.FindElements(By.LinkText("Opciones"));
            Assert.AreNotEqual(empresas, nuevasEmpresas);
            driver.FindElement(By.CssSelector("img[alt='Profile Picture']")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.LinkText("Cerrar sesión")).Click();
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
