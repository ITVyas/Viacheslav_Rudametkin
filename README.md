# Viacheslav_Rudametkin

# Viacheslav_Rudametkin

This is project of Selenium Homework.
It does:
1. logins on site https://opensource-demo.orangehrmlive.com/
2. creates new Student job
3. Dletes created Student job

Structure of project
- ChromeDriver/chromedriver.exe is help file for running tests in Chrome
- Drivers/BrowserDriver.cs - class that represents the shell for driver, which we use to do all actions with browser
- Features/Task.feature - testing scenario
- Hooks/HookInitialisation.cs - initialisation of program. Defines what we do before and after scenario, and sets ScenarioContext 
- bin/Debug/net6.0/Selenium.dll - executable file

Running the program:
- simple run in CLI with dotnet test:

![image](https://user-images.githubusercontent.com/73746353/207141287-b2e9e786-ac87-407a-be9c-e9dd7ecc415c.png)

- For reporting we use https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html

Running with following command:
![image](https://user-images.githubusercontent.com/73746353/207140284-80fc5550-d5eb-4487-92ec-1438f06afd36.png)

As we can see, it gives path for result.
Open it:

![image](https://user-images.githubusercontent.com/73746353/207140474-f5ef75f7-1f73-47ec-9a7c-fafecd788825.png)

