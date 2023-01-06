using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Specs.Drivers;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Selenium.PageModel;

namespace Selenium.StepDefinitions
{
    [Binding]
    public class TaskStepDefinitions
    {

        [Given(@"I logging in")]
        public void LoggingIn(Table data)
        {
            BrowserDriver.GetInstance().NavigateToUrl("https://opensource-demo.orangehrmlive.com/");
            BrowserDriver.GetInstance().Driver.Manage().Window.Maximize();

            var dictionary = new Dictionary<string, string>();
            foreach (var row in data.Rows)
                dictionary.Add(row[0], row[1]);

            LoginPage loginPage = new LoginPage();
            loginPage.EnterLogin(dictionary["Login"]);
            loginPage.EnterPassword(dictionary["Password"]);
            loginPage.ClickLogin();
        }

        [When(@"I go to Admin page")]
        public void GoToAdminPage()
        { 
            DashboardPage dashboardPage = new DashboardPage();
            dashboardPage.clickAdmin();
        }

        [When(@"I navigate to Job Titles section")]
        public void NavigateToJobTitles()
        { 
            AdminPage adminPage = new AdminPage();
            adminPage.ClickJobButton();
            adminPage.ClickJobTitlesButton();
        }

        [When(@"I click on Add button")]
        public void IClickOnAddButton()
        {
            JobTitlesPage jobTitlePage = new JobTitlesPage();
            jobTitlePage.ClickAddButton();
        }

        [When(@"I fill form for my job")]
        public void WhenIFillForm(Table data)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in data.Rows)
                dictionary.Add(row[0], row[1]);

            FormPage formPage = new FormPage();
            formPage.EnterJobTitle(dictionary["Title"]);
            formPage.EnterJobDescription(dictionary["Description"]);
            formPage.EnterNotes(dictionary["Note"]);
            formPage.ClickSave();
        }


        [When(@"I delete Student job")]
        public void WhenIClickOnTrashButtonInRowWithJob()
        {
            JobTitlesPage jobTitlesPage = new JobTitlesPage();
            jobTitlesPage.PickJobToDelete("Student");
            jobTitlesPage.ClickDeleteButtonForPickedJob();
            jobTitlesPage.ClickYesDeleteButton();
        }

    }
}
