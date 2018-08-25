using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace AppiumDotNetSamples
{
    [TestFixture()]
    public class AndroidSessionTest
    {
        public class Env 
        {
            static public bool isSauce()
            {
                if (Environment.GetEnvironmentVariable("SAUCE_LABS") == null)
                    return false;

                return true;
            }

            public static TimeSpan INIT_TIMEOUT_SEC = TimeSpan.FromSeconds(180);
            public static TimeSpan IMPLICIT_TIMEOUT_SEC = TimeSpan.FromSeconds(10);
        }

        public class App
        {
            static public String iOSApp()
            {
                return Env.isSauce() ? "http://appium.github.io/appium/assets/TestApp7.1.app.zip" : System.IO.Path.GetFullPath("../../../apps/TestApp.app.zip");
            }
        }

        private AppiumDriver<IOSElement> driver;
        public static Uri sauceURI = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
        public static Uri localUrl = new Uri("http://localhost:4723/wd/hub");


        [TestFixtureSetUp()]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "");
            capabilities.SetCapability("platformName", "iOS");
            capabilities.SetCapability("platformVersion", "10.3");
            capabilities.SetCapability("automationName", "XCUITest");
            capabilities.SetCapability("deviceName", "iPhone 6");
            capabilities.SetCapability("app", App.iOSApp());

            Uri serverUri = Env.isSauce() ? sauceURI : localUrl;

            driver = new IOSDriver<IOSElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [Test()]
        public void TestCase()
        {

            IOSElement element = driver.FindElementByClassName("XCUIElementTypeApplication");
            String application_name = element.GetAttribute("name");
            Assert.AreEqual("TestApp", application_name);

            driver.Quit();

            Assert.Throws<WebDriverException>(
                () => { element.GetAttribute("name"); });
        }
    }
}
