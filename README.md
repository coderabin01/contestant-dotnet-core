ASP.NET Core 2.2 has been used  on Backend
 
Steps to setup & run .net core app:
1) Clone the project from the repository 
                Github Url:  https://github.com/coderabin01/contestant-dotnet-core.git 
2) Give the User ID & password of SQL Management Studio in ConnectionsStrings object of appsettings.json file in the root directory.
3) Run the following migration command in the terminal to create the database along with all the tables in SQL Management Studio.
                i) dotnet ef database update
3) Run the following commands in the terminal to build and run application
                 i) dotnet restore
                ii) dotnet build
                iii) dotnet run
Now the app will run on the port 5001 of localhost. ie. https://localhost:5001/
3) For API documentation, the URL is https://localhost:5001/swagger/index.html
