## Overview
The project is a rental service. The based way to describe it is airbnb for long-term rent

## link to db model
https://lucid.app/lucidchart/2088f41f-202e-4933-920e-7ea94b5b3d62/view?page=0_0#

## Migrations
dotnet ef migrations --project DAL.App.EF --startup-project WebApp add  OneToOne
dotnet ef database --project DAL.App.EF --startup-project WebApp update
dotnet ef database --project DAL.App.EF --startup-project WebApp drop