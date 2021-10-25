# PhonebookApp

## This readme assumes the following:

1. The user has Git set up and knows how to use it - More information can be found here : https://git-scm.com/docs/git
2. The user has Angular CLI set up to run locally - More information can be found here : https://angular.io/guide/setup-local
3. The user has .Net 5 CLI set up to run locally - More information can be found here : https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0

## Getting started

Step 1 - Clone the repo using the instructions here: https://git-scm.com/docs/git-clone

## Frontend

Step 2 - Using terminal, from the PhonebookApp directory, navigate to the phonebook angular directory and use the command : 
`npm install` (this will install the dependencies) 
Step 3 - Use the command: `ng s` (to start the application).

## Backend

Step 4 - Navigate to the PhonebookApi folder and open the solution in Rider. In Startup.cs, update the connction string to your local postgres server. 
Step 5 - From within the solution folder, run the command: `dotnet restore`  (This will update the NuGet packages)
Step 6 - From within the project folder, with your postgres server running, run the command: `dotnet ef database update` (this will creaete the database and run the migrations)
Step 7 - Hit the play button in the top right-hand toolbar. 

The application should be runnig at http://localhost:4200
