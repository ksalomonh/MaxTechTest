# MaxTechTest

Application Set Up
1. Clone the repository.
2. Database Setup
3. Go to TechnicalTestKSDatabase folder, find [Schema-Data]MaxiTechTest-Database.sql script.
4. Execute [Schema-Data]MaxiTechTest-Database.sql on SQL Server instance. This action will create the database with initial data into.
5. Backend application Setup
6. Go to TechnicalTestKSApp_BE folder, find TechnicalTestKSApp_BE.sln.
7. Open TechnicalTestKSApp_BE.sln file using visual studio. Be sure .Net 6 is properly installed in you computer.
8. In Solution Explorer identify the TechnicalTestKSApp_BE project. Ensure this projects is the Startup project, otherwise rigth click on project name and select Set as Startup Project option of contextual menu.
9. Inside of TechnicalTestKSApp_BE project identify appsettings.json file and open it.
10. Find the "MaxiTechTestEmployeeBeneficiary" key, set the connection string to be able to connect to database.
11. Before to run the app, ensure the IIS Express is selected (see image below)
12. ![image](https://github.com/ksalomonh/MaxTechTest/assets/13419171/0d7e1d52-fd81-4078-9eb4-48d6ad995220)
13. Once IIS Express is configured go to run the application.
14. See Swagger is available to test.
15. Fronted application Setup.
16. Ensure Nodejs version 18 is installed in your computer. Follow https://nodejs.org/en/download/package-manager to install it.
17. Ensure Angular CLI is installed in your computer. Follow https://v17.angular.io/cli to install it.
18. Open the terminal (command prompt or visual studio code terminal), navigate to TechnicalTestKSApp folder.
19. Inside of TechnicalTestKSApp folder run npm install command to download the node_modules. Ensure the node_module folder appears.
20. Open new terminal and navigate to src/environments. Find the environment.development.ts and/or environment.ts, open them.
21. For each file find the apiUrl key, set the API url that you can find in Swagger page for Backend application. Example: apiUrl: 'https://localhost:44312/'.
22. Finally, inside of the TechnicalTestKSApp folder in terminal, run the ng serve command to run the application. Please review the logs of the terminar to find the host url, normally it is http://localhost:4200/.


Application running.
1. For root path you will find Employees list.
2. Add new employee: Click on +Employee button on the top-right screen.
3. Edit employee: Find employee from the list and click on Go to details button in table. Edit the fields and click on Edit button.
4. Delete employee: Find employee from the list and click on Go to details button in table. click on Delete button.
5. See beneficiaries:
       Find Beneficiaries column of Employee list and click on beneficiary number.
       Add beneficiary: Click on Go to benefiiaries details button on the top-right screen. Fill the fields and click on Add button.
       Edit beneficiary: Click on Go to benefiiaries details button on the top-right screen. Find beneficiary to edit and click on edit button, notice the field on rigth side are automaticlly filled. Edit the fields and click on Edit button on the buttom of the form.
       Delete beneficiary: Click on Go to benefiiaries details button on the top-right screen. Find beneficiary to delete and click on delete button.
   ***IMPORTANT***
       Every add, edit or delete beneficiary action will be applied once click on Apply changes button at the middle of the screen.
   ***IMPORTANT*** 
