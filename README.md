# Girteka-Task

to run this project you should run in base directory : 
if you run project using visual studio place brakepoint on program cs before SeedData.SeedAsync method and run update database script 
 - dotnet ef database update -c EntityFrameworkDbContext -p ../Infrastructure/Infrastructure.csproj -s API.csproj from src/Api directory.
if you using docker compose to run the project first time it may be fail, becouse there is no migrations applied on database.
after mssql container started you can apply migrations command above.
docker compose build
docker compose up
also in web api directory at appsettings.json connectionstring for ApplicationDbContext adress is my personal computers ip and it may be different for you.