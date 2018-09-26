using System;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    [TestClass]
    public class UntitledTestCase
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        //[ClassInitialize]
        //public static void InitializeClass(TestContext testContext)
        //{
        //    FirefoxOptions options = new FirefoxOptions();
        //    options.AddArgument("--start-maximized");
        //    options.AddArgument("--no-sandbox");
        //    driver = new FirefoxDriver(options);
        //    baseURL = "https://app.softrestaurant.com.mx";
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
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--no-sandbox");
            driver = new FirefoxDriver("C:\\Users\\ADMQA.user\\Documents\\geckodriver", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            baseURL = "https://app.softrestaurant.com.mx";
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheUntitledTestCaseTest()
        {
            try
            {
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\configuracion.csv.txt");
                driver.Navigate().GoToUrl(baseURL);
                driver.FindElement(By.Id("email")).Clear();
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("button[type='submit'")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.LinkText("Configuración")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Monitor de pedidos'])[1]/following::strong[1]")).Click();
                driver.FindElement(By.LinkText("Restaurante")).Click();
                driver.FindElement(By.LinkText("Métodos de pago")).Click();
                driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Tarjetas bancarias'])[1]/following::label[1]")).Click();
                driver.FindElement(By.Id("Restaurant_DealerChange")).Click();
                driver.FindElement(By.Id("Restaurant_DealerChange")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("Restaurant_DealerChange")).Click();
                driver.FindElement(By.Id("Restaurant_DealerChange")).SendKeys(Keys.Down);
                driver.FindElement(By.Id("Restaurant_DealerChange")).Click();
                driver.FindElement(By.Id("Restaurant_DealerChange")).Clear();
                driver.FindElement(By.Id("Restaurant_DealerChange")).SendKeys("200.00");
                driver.FindElement(By.CssSelector("#dropdown-user > a > span > img")).Click();
                driver.FindElement(By.LinkText("Cerrar sesión")).Click();
            }catch(FileNotFoundException fe)
            {
                Assert.Fail("No se encontó el archivo de configuración");
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
