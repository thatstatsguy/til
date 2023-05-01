As per https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli we'll run the following


```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Once done, we'll connect in rider with `Server=(localdb)\MSSQLLocalDB;Database=BootstrapDatabase` with no auth enabled


## Nuking your entire Local DB
https://stackoverflow.com/questions/36950078/cannot-connect-to-localdb-mssqllocaldb-login-failed-for-user-user-pc-user

```
sqllocaldb stop mssqllocaldb
sqllocaldb delete mssqllocaldb
sqllocaldb start "MSSQLLocalDB"
```

you may also need to delete database files under C:/Users/<Username>/any file with the bootstrapdatabse in the name e.g. bootstrapdatabse.mdf