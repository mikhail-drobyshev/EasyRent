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
dotnet aspnet-codegenerator controller -name DisputesController -m Dispute -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name DisputeStatusesController -m DisputeStatus -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ErApplicationsController -m ErApplication -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ErApplicationStatusesController -m ErApplicationStatus -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name ErUserReviewsController -m ErUserReview -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name GendersController -m Gender -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PropertiesController -m Property -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PropertyPicturesController -m PropertyPicture -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PropertyReviewsController -m PropertyReview -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PropertyTypesController -m PropertyType -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f
dotnet aspnet-codegenerator controller -name PropertyLocationsController -m PropertyLocation -actions -dc AppDbContext -outDir ApiControllers -api --useAsyncActions -f

##Technical documentation and user workflow is in documentation.pdf file

## Scaffold the identity pages
dotnet aspnet-codegenerator identity -dc DAL.App.EF.AppDbContext -f