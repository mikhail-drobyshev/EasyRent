# icd0009-20s

dotnet ef migrations --project DAL.App.EF --startup-project WebApp add Initial
dotnet ef database --project DAL.App.EF --startup-project WebApp drop
dotnet ef database --project DAL.App.EF --startup-project WebApp update



dotnet aspnet-codegenerator controller -name ErUsersController -actions -m ErUser -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserTypesController -actions -m ErUserType -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name GendersController -actions -m Gender -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserReviewsController -actions -m ErUserReview -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserPicturesController -actions -m ErUserPicture -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f



dotnet aspnet-codegenerator controller -name ErUsersController -m ErUser -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name ErUserTypesController -m ErUserType -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name GendersController -m ErUser -actions -dc Gender -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name ErUserReviewsController -m ErUser -actions -dc ErUserReview -outDir ApiControllers -api --useAsyncActions -f

