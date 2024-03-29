#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Catalog/Presentation/mShop.Catalog.Api/mShop.Catalog.Api.csproj", "src/Services/Catalog/Presentation/mShop.Catalog.Api/"]
COPY ["src/Services/Catalog/Libraries/mShop.Catalog.Services/mShop.Catalog.Services.csproj", "src/Services/Catalog/Libraries/mShop.Catalog.Services/"]
COPY ["src/Services/Catalog/Libraries/mShop.Catalog.Data/mShop.Catalog.Data.csproj", "src/Services/Catalog/Libraries/mShop.Catalog.Data/"]
COPY ["src/Services/Catalog/Libraries/mShop.Catalog.Core/mShop.Catalog.Core.csproj", "src/Services/Catalog/Libraries/mShop.Catalog.Core/"]
COPY ["src/Common/mShop.Core/mShop.Core.csproj", "src/Common/mShop.Core/"]
RUN dotnet restore "src/Services/Catalog/Presentation/mShop.Catalog.Api/mShop.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/Presentation/mShop.Catalog.Api"
RUN dotnet build "mShop.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mShop.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mShop.Catalog.Api.dll"]
