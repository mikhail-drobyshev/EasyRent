FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY *.sln .
COPY Directory.Build.props .

# Base
COPY BLL.Base/*.csproj ./BLL.Base/
COPY Applications.BLL.Base/*.csproj ./Applications.BLL.Base/
COPY Applications.DAL.Base/*.csproj ./Applications.DAL.Base/
COPY Applications.Domain.Base/*.csproj ./Applications.Domain.Base/
COPY DAL.Base/*.csproj ./DAL.Base/
COPY DAL.Base.EF/*.csproj ./DAL.Base.EF/
COPY Domain.Base/*.csproj ./Domain.Base/
COPY Extensions.Base/*.csproj ./Extensions.Base/
COPY Resources.Base/*.csproj ./Resources.Base/

# App
COPY BLL.App/*.csproj ./BLL.App/
COPY BLL.App.DTO/*.csproj ./BLL.App.DTO/
COPY Applications.BLL.App/*.csproj ./Applications.BLL.App/
COPY Applications.DAL.App/*.csproj ./Applications.DAL.App/
COPY DAL.App.DTO/*.csproj ./DAL.App.DTO/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY Domain.App/*.csproj ./Domain.App/
COPY PublicApi.DTO.v1/*.csproj ./PublicApi.DTO.v1/
COPY Resources/*.csproj ./Resources/
COPY Applications.DAL.App/*.csproj ./Applications.DAL.App/
COPY WebApp/*.csproj ./WebApp/



RUN dotnet restore

# copy over
# Base
COPY BLL.Base/. ./BLL.Base/
COPY Applications.BLL.Base/. ./Applications.BLL.Base/
COPY Applications.DAL.Base/. ./Applications.DAL.Base/
COPY Applications.Domain.Base/. ./Applications.Domain.Base/
COPY DAL.Base/. ./DAL.Base/
COPY DAL.Base.EF/. ./DAL.Base.EF/
COPY Domain.Base/. ./Domain.Base/
COPY Extensions.Base/. ./Extensions.Base/
COPY Resources.Base/. ./Resources.Base/

# App
COPY BLL.App/. ./BLL.App/
COPY BLL.App.DTO/. ./BLL.App.DTO/
COPY Applications.BLL.App/. ./Applications.BLL.App/
COPY Applications.DAL.App/. ./Applications.DAL.App/
COPY DAL.App.DTO/. ./DAL.App.DTO/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY Domain.App/. ./Domain.App/
COPY PublicApi.DTO.v1/. ./PublicApi.DTO.v1/
COPY Resources/. ./Resources/
COPY Applications.DAL.App/. ./Applications.DAL.App/
COPY WebApp/. ./WebApp/

WORKDIR /source/WebApp

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /source/WebApp/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]
