# icd0009-20s

dotnet ef migrations --project DAL.App.EF --startup-project WebApp add Initial
dotnet ef database --project DAL.App.EF --startup-project WebApp drop
dotnet ef database --project DAL.App.EF --startup-project WebApp update



dotnet aspnet-codegenerator controller -name ErUsersController -actions -m ErUser -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f


dotnet aspnet-codegenerator controller -name ErUsersController -m ErUser -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
