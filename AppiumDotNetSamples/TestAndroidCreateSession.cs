using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System;
using AppiumDotNetSamples.Helper;

namespace AppiumDotNetSamples
{
    [TestFixture()]
    public class AndroidCreateSessionTest
    {

        private AndroidDriver<AndroidElement> driver;

        [TestFixtureSetUp()]
        public void BeforeAll()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.BrowserName, "");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "7.1.1");
            capabilities.SetCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Nexus");
            capabilities.SetCapability(MobileCapabilityType.App, App.AndroidApp());

            Uri serverUri = Env.IsSauce() ? Env.sauceURI : Env.localUrl;

            driver = new AndroidDriver<AndroidElement>(serverUri, capabilities, Env.INIT_TIMEOUT_SEC);
            driver.Manage().Timeouts().ImplicitWait = Env.IMPLICIT_TIMEOUT_SEC;
        }

        [Test()]
        public void TestShouldCreateAndDestroyAndroidSessions()
        {
            String currentActivity = driver.CurrentActivity;

            Assert.AreEqual(".ApiDemos", currentActivity);

            driver.Quit();

            Assert.Throws<WebDriverException>(
                () => { currentActivity = driver.CurrentActivity; });
        }
    }
}
