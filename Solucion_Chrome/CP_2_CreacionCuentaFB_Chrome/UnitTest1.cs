using System;
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
    public class CP2CreacionCuentaFBChrome
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private static string outlookURL;
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
            driver = new ChromeDriver("C:\\Users\\ADMQA.user\\Documents\\chromedriver", options);
            baseURL = "https://app.softrestaurant.com.mx";
            outlookURL = "https://outlook.live.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void CleanupTest()
        {
           // Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TheCP2CreacionCuentaFBChromeTest()
        {
            try
            {

                //Alta de usuario en el Web Administrator--------------------------
                string[] parametros = LeerCSV("C:\\Users\\ADMDBQA.user\\Documents\\CP2_configuracion.txt");
                driver.Navigate().GoToUrl(baseURL);
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("#form > div.create-account > p > a")).Click();
                driver.FindElement(By.Id("customBtnFB")).Click();
                // ERROR: Caught exception [ERROR: Unsupported command [selectWindow | win_ser_3 | ]]
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.FindElement(By.Id("email")).Click();
                // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=email | ]]
                driver.FindElement(By.Id("email")).SendKeys(parametros[0]);
                driver.FindElement(By.Id("buttons")).Click();
                driver.FindElement(By.Id("pass")).Click();
                driver.FindElement(By.Id("pass")).Clear();
                driver.FindElement(By.Id("pass")).SendKeys(parametros[1]);
                driver.FindElement(By.CssSelector("input[value='Log In']")).Click();
                //ERROR: Caught exception[ERROR: Unsupported command[selectWindow | win_ser_local | ]]

                Thread.Sleep(5000);

                driver.SwitchTo().Window(driver.WindowHandles.FirstOrDefault());
                driver.FindElement(By.Id("FirstName")).Click();
                //ERROR: Caught exception[ERROR: Unsupported command[dragAndDropToObject | id = FirstName | id = LastName]]
                driver.FindElement(By.Id("LastName")).Click();
                driver.FindElement(By.Id("LastName")).Clear();
                driver.FindElement(By.Id("LastName")).SendKeys(parametros[2]);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys(parametros[0]);
                         Thread.Sleep(1000);
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(parametros[3] + Keys.Tab);
                Thread.Sleep(1000);
                driver.FindElement(By.Id("ConfirmPassword")).Click();
                driver.FindElement(By.Id("ConfirmPassword")).Clear();
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys(parametros[3]);
                //// ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=0 | ]]
                //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='reCAPTCHA'])[1]/preceding::div[4]")).Click();
                //// ERROR: Caught exception [ERROR: Unsupported command [selectFrame | relative=parent | ]]
                Thread.Sleep(2000);
                driver.FindElement(By.Id("registerbtn")).Click();
                
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
