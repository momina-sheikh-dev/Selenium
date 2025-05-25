using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;


namespace Workshop_selenium
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance;  }
        }

        [TestMethod]
        [Description("This is demo test")]
        [Owner("Momina")]
        [Priority(1), TestCategory("POSITIVE")]
        [TestCategory("LOGIN")]
        //[DataSource("Provider","File_Path","Table_Name/Parent_Tag",DataAccessMethod.2values)]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
@"C:\Users\momin\OneDrive\ドキュメント\VS Studio Projects\Workshop_selenium\Workshop_selenium\bin\Debug\Data.xml",
"TestCase_001_Data_Driven", DataAccessMethod.Sequential)]

        public void TestCase_001_Data_Driven()
        {
            string user = TestContext.DataRow["username"].ToString();
            string password = TestContext.DataRow["password"].ToString();

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys(user);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.ClassName("login_button")).Click();
            Thread.Sleep(3000);
            driver.Close();
        }

        [TestMethod]
        [TestCategory("LOGIN")]
        [DataRow("MominaTester","MominaTester")]
        [DataRow("MominaTester", "Momina")]
        [DataRow("$684$^*", "Momina")]
        public void TestCase_002(string user, string password)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys(user);
            driver.FindElement(By.Name("password")).SendKeys(password);
            driver.FindElement(By.ClassName("login_button")).Click();
            //string msg = driver.FindElement(By.ClassName("welcome_menu")).Text;
            //Assert.AreEqual("Welcome to Adactin Group of Hotels", msg);
            Thread.Sleep(3000);
            driver.Close();
        }

        [TestMethod]
        [TestCategory("LOGIN")]
        public void TestCase_003()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("MominaTester");
            driver.FindElement(By.Name("password")).SendKeys("MominaTester");
            driver.FindElement(By.ClassName("login_button")).Click();
            string msg = driver.FindElement(By.ClassName("welcome_menu")).Text;
            Assert.AreEqual("Welcome to Adactin Group of Hotels", msg);
            Thread.Sleep(3000);
            driver.Close();
        }


        [TestMethod]
        [TestCategory("LOGIN")]
        public void TestCase_Login_Negative()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("q1w234");
            driver.FindElement(By.Name("password")).SendKeys("ZkiannzG");
            driver.FindElement(By.ClassName("login_button")).Click();
            //string error_msg = driver.FindElement(By.ClassName("auth_error")).Text;
            //Assert.AreEqual("Invalid Login details or Your Password might have expired. Click here to reset " +
            //    "your password", error_msg);
            Thread.Sleep(3000);
            driver.Close();
        }


        [TestMethod]
        //[TestCategory("LOGIN")]
        public void TestCase_Login_Negative_Invalid_Password_Valid_Username()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://adactinhotelapp.com/";
            driver.FindElement(By.Id("username")).SendKeys("Momina234");
            driver.FindElement(By.Name("password")).SendKeys("ZkiannzG");
            driver.FindElement(By.ClassName("login_button")).Click();
            driver.Close();
        }
    }
}
