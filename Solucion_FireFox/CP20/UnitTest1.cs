using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Runtime.InteropServices;
using System.Reflection;
using WindowsInput;
namespace SeleniumTests
{
    [TestClass]
    public class CreacionPromocionesCampanas
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
            driver = new FirefoxDriver("C:\\Users\\ADMDBQA.user\\Documents\\geckodriver", options);
            driver.Manage().Window.Maximize();
            baseURL = "https://app.softrestaurant.com.mx";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            //verificationErrors = new StringBuilder();
        }
        [TestMethod]
        public void CreacionPromocionesCampanasTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP19_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[tabindex='3']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("a[href = '/Promotion']")).Click();
                driver.FindElement(By.CssSelector("a[href = '/Promotion']")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Agregar promoción")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Name")).Click();
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys(parametros[2]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Description")).Clear();
                driver.FindElement(By.Id("Description")).SendKeys(parametros[3]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Budget")).Clear();
                driver.FindElement(By.Id("Budget")).SendKeys(parametros[4]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("StartDate")).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("EndDate")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("EndDate")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("EndDate")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("EndDate")).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Buscar'])[1]/following::span[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Name")).Click();
                driver.FindElement(By.Id("Coupon_Name")).Clear();
                driver.FindElement(By.Id("Coupon_Name")).SendKeys(parametros[5]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Description")).Clear();
                driver.FindElement(By.Id("Coupon_Description")).SendKeys(parametros[6]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Code")).Clear();
                driver.FindElement(By.Id("Coupon_Code")).SendKeys(parametros[7]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Budget")).Click();
                driver.FindElement(By.Id("Coupon_Budget")).Clear();
                driver.FindElement(By.Id("Coupon_Budget")).SendKeys(parametros[8]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Amount")).Click();
                driver.FindElement(By.Id("Coupon_Amount")).Clear();
                driver.FindElement(By.Id("Coupon_Amount")).SendKeys(parametros[9]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_Quantity")).Click();
                driver.FindElement(By.Id("Coupon_Quantity")).Clear();
                driver.FindElement(By.Id("Coupon_Quantity")).SendKeys(parametros[10]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_MaximumCouponRedemption")).Clear();
                driver.FindElement(By.Id("Coupon_MaximumCouponRedemption")).SendKeys(parametros[11]);
                driver.FindElement(By.Id("Coupon_MaximumCouponRedemption")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_MinimumPurchase")).Click();
                driver.FindElement(By.Id("Coupon_MinimumPurchase")).Clear();
                driver.FindElement(By.Id("Coupon_MinimumPurchase")).SendKeys(parametros[12]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Coupon_MaximumDiscount")).Click();
                driver.FindElement(By.Id("Coupon_MaximumDiscount")).Clear();
                driver.FindElement(By.Id("Coupon_MaximumDiscount")).SendKeys(parametros[13]);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Recomendado: 400px(ancho) x 250px(alto)'])[1]/following::span[1]")).Click();
                Thread.Sleep(3000);
                InputSimulator inputSimulator = new InputSimulator();
                //inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                //Thread.Sleep(500);
                //inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                //Thread.Sleep(500);
                //inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.UP);
                //Thread.Sleep(500);
                //inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SHIFT);
                //inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                //inputSimulator.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SHIFT);
                inputSimulator.Keyboard.TextEntry("C:\\Users\\ADMDBQA.user\\Documents\\imagen");
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.TAB);
                Thread.Sleep(500);
                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Regresar'])[1]/following::button[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("Coupon_StartDate")).SendKeys(Keys.PageUp);
                driver.FindElement(By.Id("Coupon_StartDate")).Click();
                driver.FindElement(By.Id("Coupon_StartDate")).SendKeys(Keys.Enter);
                driver.FindElement(By.Id("Coupon_EndDate")).Click();
                driver.FindElement(By.Id("Coupon_EndDate")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("Coupon_EndDate")).SendKeys(Keys.Enter);
                Thread.Sleep(1000);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Agrega la imagen correspondiente a la promoción'])[1]/following::label[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Día siguiente'])[1]/following::label[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MARTES'])[1]/following::label[2]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MARTES'])[1]/following::label[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Regresar'])[1]/following::button[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='DOMINGO'])[1]/following::label[2]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Regresar'])[1]/following::button[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnFinalize")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.CssSelector("button[data-bb-handler = 'ok']")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.CssSelector("a[href = '/RestaurantWizard']")).Click(); //debe quitarse
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