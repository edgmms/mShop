#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Basket/Presentation/mShop.Basket.Api/mShop.Basket.Api.csproj", "src/Services/Basket/Presentation/mShop.Basket.Api/"]
COPY ["src/Services/Basket/Libraries/mShop.Basket.Services/mShop.Basket.Services.csproj", "src/Services/Basket/Libraries/mShop.Basket.Services/"]
COPY ["src/Services/Basket/Libraries/mShop.Basket.Data/mShop.Basket.Data.csproj", "src/Services/Basket/Libraries/mShop.Basket.Data/"]
COPY ["src/Services/Basket/Libraries/mShop.Basket.Core/mShop.Basket.Core.csproj", "src/Services/Basket/Libraries/mShop.Basket.Core/"]
COPY ["src/Common/mShop.Core/mShop.Core.csproj", "src/Common/mShop.Core/"]
COPY ["src/Common/mShop.EventBus/mShop.EventBus.csproj", "src/Common/mShop.EventBus/"]
RUN dotnet restore "src/Services/Basket/Presentation/mShop.Basket.Api/mShop.Basket.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Basket/Presentation/mShop.Basket.Api"
RUN dotnet build "mShop.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mShop.Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mShop.Basket.Api.dll"]
