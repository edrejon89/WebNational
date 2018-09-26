using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Firefox;
using WindowsInput;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestClass]
    public class CP07HorarioAperturaChrome
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(65);
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



        [TestCleanup]
        public void CleanupTest()
        {
            //Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP07HorarioAperturaChromeTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP7_Configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Repite tu contraseña'])[1]/following::button[1]")).Click();
                Thread.Sleep(5000);
                IReadOnlyCollection<IWebElement> empresas = driver.FindElements(By.CssSelector("button[class = 'btn btn-primary dropdown-toggle']"));
                Thread.Sleep(3000);
                empresas.ElementAt(Int32.Parse(parametros[2])).Click();
                Thread.Sleep(3000);
                InputSimulator input = new InputSimulator();
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.DOWN);
                input.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                Thread.Sleep(3000); Thread.Sleep(3000);
                driver.FindElement(By.Id("group-configuracion")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Horarios de apertura")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("schedule_StartHour")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MARTES'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MIERCOLES'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='JUEVES'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='VIERNES'])[1]/following::input[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='SABADO'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::td[4]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::td[4]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='DOMINGO'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Horarios y días de servicio a domicilio'])[1]/following::div[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='LUNES'])[1]/following::a[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("schedule_EndHour")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='contentScheduleSettingDay']/tr[7]/td[4]/div")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[10]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MARTES'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::td[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MIERCOLES'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='JUEVES'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='contentScheduleSettingDay']/tr[7]/td[4]/div")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='VIERNES'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id='contentScheduleSettingDay']/tr[7]/td[4]/div")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='SABADO'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)=':'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Configuración del módulo de pedidos'])[1]/following::div[9]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='DOMINGO'])[1]/following::input[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Espere un momento...'])[1]/following::i[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='DOMINGO'])[1]/following::input[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='LUNES'])[1]/following::a[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Hasta el día siguiente'])[1]/following::label[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='LUNES'])[1]/following::td[6]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='LUNES'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MARTES'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='MIERCOLES'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='JUEVES'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='VIERNES'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='SABADO'])[1]/following::label[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(2000);
                // driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Proceso finalizado'])[1]/following::button[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Proceso finalizado'])[1]/following::button[1]")).Click();
                Thread.Sleep(2000);
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
