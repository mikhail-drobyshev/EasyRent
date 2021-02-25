# icd0009-20s

## link to db model
https://lucid.app/lucidchart/2088f41f-202e-4933-920e-7ea94b5b3d62/view?page=0_0#


## commands to work with database
dotnet ef migrations --project DAL.App.EF --startup-project WebApp add Initial
dotnet ef database --project DAL.App.EF --startup-project WebApp drop
dotnet ef database --project DAL.App.EF --startup-project WebApp update


## MVC controller
dotnet aspnet-codegenerator controller -name ErUsersController -actions -m ErUser -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

## Api controller
dotnet aspnet-codegenerator controller -name ErUsersController -m ErUser -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
