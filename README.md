# icd0009-20s

dotnet ef migrations --project DAL.App.EF --startup-project WebApp add Initial
dotnet ef database --project DAL.App.EF --startup-project WebApp drop
dotnet ef database --project DAL.App.EF --startup-project WebApp update



dotnet aspnet-codegenerator controller -name ErUsersController -actions -m ErUser -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserTypesController -actions -m ErUserType -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name GendersController -actions -m Gender -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserReviewsController -actions -m ErUserReview -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErUserPicturesController -actions -m ErUserPicture -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PropertiesController -actions -m Property -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PropertyTypesController -actions -m PropertyType -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PropertyLocationsController -actions -m PropertyLocation -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PropertyPicturesController -actions -m PropertyPicture -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name PropertyReviewsController -actions -m PropertyReview -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErApplicationsController -actions -m ErApplication -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name ErApplicationStatusesController -actions -m ErApplicationStatus -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name DisputesController -actions -m Dispute -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name DisputeStatusesController -actions -m DisputeStatus -dc AppDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f







dotnet aspnet-codegenerator controller -name ErUsersController -m ErUser -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name ErUserTypesController -m ErUserType -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name GendersController -m ErUser -actions -dc Gender -outDir ApiControllers -api --useAsyncActions -f

dotnet aspnet-codegenerator controller -name ErUserReviewsController -m ErUser -actions -dc ErUserReview -outDir ApiControllers -api --useAsyncActions -f

