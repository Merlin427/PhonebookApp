# PhonebookApp

Step 1 - Clone the repo using the instructions here https://git-scm.com/docs/git-clone

## Frontend

Step 1 - Using terminal, from the PhonebookApp directory, navigate to the phonebook angular directory and use the command : 
`npm install` (this will install the dependencies) 
Step 2 - Use the command: `ng s` (to start the application).

## Backend

Navigate to the PhonebookApi folder and open the solution in Rider. In Startup.cs, update the connction string to your local postgres server. 
From within the solution folder, run the command: `dotnet restore`  (This will update the NuGet packages)
From within the project folder, with your postgres server running, run the command: `dotnet ef database update` (this will creaete the database and run the migrations)
Hit the play button in the top right-hand toolbar. 

The application should be runnig at http://localhost:4200
