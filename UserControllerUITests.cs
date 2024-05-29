using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CRUD_application_2.Tests
{
    [TestClass]
    public class UserControllerUITests
    {
        private static IWebDriver driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Set up the Chrome driver
            driver = new ChromeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Clean up the Chrome driver
            driver.Quit();
            driver.Dispose();
        }

        [TestMethod]
        public void TestIndexPage()
        {
            // Navigate to the User Index page
            driver.Navigate().GoToUrl("http://localhost:8080/User/Index");

            // Assert that the page title is correct
            Assert.AreEqual("User List", driver.Title);

            // Assert that the table is displayed
            var table = driver.FindElement(By.TagName("table"));
            Assert.IsTrue(table.Displayed);

            // Assert that there are 10 rows in the table
            var rows = table.FindElements(By.TagName("tr"));
            Assert.AreEqual(10, rows.Count);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            // Navigate to the User Create page
            driver.Navigate().GoToUrl("http://localhost:8080/User/Create");

            // Fill in the form fields
            var nameInput = driver.FindElement(By.Id("Name"));
            nameInput.SendKeys("Test User");

            var emailInput = driver.FindElement(By.Id("Email"));
            emailInput.SendKeys("testuser@example.com");

            // Submit the form
            var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            submitButton.Click();

            // Assert that the user is redirected to the Index page
            Assert.AreEqual("User List", driver.Title);

            // Assert that the new user is added to the table
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            Assert.AreEqual(11, rows.Count);
        }

        [TestMethod]
        public void TestEditUser()
        {
            // Navigate to the User Edit page for the first user
            driver.Navigate().GoToUrl("http://localhost:8080/User/Edit/1");

            // Update the user's name
            var nameInput = driver.FindElement(By.Id("Name"));
            nameInput.Clear();
            nameInput.SendKeys("Updated User");

            // Submit the form
            var submitButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            submitButton.Click();

            // Assert that the user is redirected to the Index page
            Assert.AreEqual("User List", driver.Title);

            // Assert that the user's name is updated in the table
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            var firstRow = rows[1];
            var nameCell = firstRow.FindElement(By.CssSelector("td:nth-child(2)"));
            Assert.AreEqual("Updated User", nameCell.Text);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            // Navigate to the User Delete page for the first user
            driver.Navigate().GoToUrl("http://localhost:8080/User/Delete/1");

            // Confirm the deletion
            var confirmButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            confirmButton.Click();

            // Assert that the user is redirected to the Index page
            Assert.AreEqual("User List", driver.Title);

            // Assert that the user is removed from the table
            var table = driver.FindElement(By.TagName("table"));
            var rows = table.FindElements(By.TagName("tr"));
            Assert.AreEqual(10, rows.Count);
        }
    }
}
