using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Specs.Drivers;
using OpenQA.Selenium;

namespace Selenium.PageModel
{
    class LoginPage
    {
        private IWebElement? _loginFiled;
        private IWebElement? _passwordFiled;
        private IWebElement? _loginButton;

        private By _loginInputXPath = By.XPath("//input[@name='username']");
        private By _passwordInputXPath = By.XPath("//input[@name='password']");
        private By _loginButtonXPath = By.XPath("//button[text()=' Login ']");

        public LoginPage()
        {
            Thread.Sleep(5000);
            _loginFiled = BrowserDriver.GetInstance().Driver.FindElement(_loginInputXPath);
            _passwordFiled = BrowserDriver.GetInstance().Driver.FindElement(_passwordInputXPath);
            _loginButton = BrowserDriver.GetInstance().Driver.FindElement(_loginButtonXPath);
        }

        public void EnterLogin(string login)
        {
            _loginFiled.SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            _passwordFiled.SendKeys(password);
        }

        public void ClickLogin()
        {
            _loginButton.Click();
        }
    }

    class DashboardPage
    {
        private IWebElement? _adminButton;
        private By _adminButtonXPath = By.XPath("//a[@href='/web/index.php/admin/viewAdminModule']");
        public DashboardPage()
        {
            Thread.Sleep(5000);
            _adminButton = BrowserDriver.GetInstance().Driver.FindElement(_adminButtonXPath);
        }

        public void clickAdmin()
        {
            _adminButton.Click();
        }

    }

    class AdminPage
    {
        private IWebElement? _jobButton;
        private IWebElement? _jobTitlesButton;
        
        private By _jobButtonXPath = By.XPath("//span[text()='Job ']");
        private By _jobTitlesButtonXPath = By.XPath("//a[text()='Job Titles']");
        
        public AdminPage()
        {
            Thread.Sleep(5000);
            _jobButton = BrowserDriver.GetInstance().Driver.FindElement(_jobButtonXPath);
        }

        public void ClickJobButton()
        {
            _jobButton.Click();
            _jobTitlesButton = BrowserDriver.GetInstance().Driver.FindElement(_jobTitlesButtonXPath);
        }

        public void ClickJobTitlesButton()
        {
            _jobTitlesButton.Click();
        }

    }

    class JobTitlesPage
    {
        private IWebElement? _addButton;
        private IWebElement? _pickedJobTrashButton;
        private IWebElement? _yesDeleteButton;

        private By _addButtonXPath = By.XPath("//button[text()=' Add ']");
        private By _yesDeleteButtonXPath = By.XPath("//button[text()=' Yes, Delete ']");
        private By _pickedJobTrashButtonXPath;


        public JobTitlesPage()
        {
            Thread.Sleep(6000);
            _addButton = BrowserDriver.GetInstance().Driver.FindElement(_addButtonXPath);
        }
        public void ClickAddButton()
        {
            _addButton.Click();
        }

        public void PickJobToDelete(string job)
        {
            _pickedJobTrashButtonXPath = By.XPath($"//div[@role='row']/div[@role='cell']/div[text()='{job}']/../../div/div/button/i[@class='oxd-icon bi-trash']");
            _pickedJobTrashButton = BrowserDriver.GetInstance().Driver.FindElement(_pickedJobTrashButtonXPath);
        }

        public void ClickDeleteButtonForPickedJob()
        {
            _pickedJobTrashButton.Click();
            _yesDeleteButton = BrowserDriver.GetInstance().Driver.FindElement(_yesDeleteButtonXPath);
        }

        public void ClickYesDeleteButton()
        {
            _yesDeleteButton.Click();
        }
    }

    class FormPage
    {
        private IWebElement? _jobTitleField;
        private IWebElement? _jobDescriptionField;
        private IWebElement? _noteField;
        private IWebElement? _saveButton;

        private By _jobTitleFieldXPath = By.XPath("//form[@class='oxd-form']/div/div/div/input[@class='oxd-input oxd-input--active']");
        private By _jobDescriptionFieldXPath = By.XPath("//textarea[@placeholder='Type description here']");
        private By _noteFieldXPath = By.XPath("//textarea[@placeholder='Add note']");
        private By _saveButtonXPath = By.XPath("//button[text()=' Save ']");

        public FormPage()
        {
            Thread.Sleep(5000);
            _jobTitleField = BrowserDriver.GetInstance().Driver.FindElement(_jobTitleFieldXPath);
            _jobDescriptionField = BrowserDriver.GetInstance().Driver.FindElement(_jobDescriptionFieldXPath);
            _noteField = BrowserDriver.GetInstance().Driver.FindElement(_noteFieldXPath);
            _saveButton = BrowserDriver.GetInstance().Driver.FindElement(_saveButtonXPath);
        }

        public void EnterJobTitle(string text)
        {
            _jobTitleField.SendKeys(text);
        }

        public void EnterJobDescription(string text)
        {
            _jobDescriptionField.SendKeys(text);
        }

        public void EnterNotes(string text)
        {
            _noteField.SendKeys(text);
        }

        public void ClickSave()
        {
            _saveButton.Click();
        }
    }

}
