#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Discount/Presentation/mShop.Discount.Api/mShop.Discount.Api.csproj", "src/Services/Discount/Presentation/mShop.Discount.Api/"]
COPY ["src/Services/Discount/Libraries/mShop.Discount.Services/mShop.Discount.Services.csproj", "src/Services/Discount/Libraries/mShop.Discount.Services/"]
COPY ["src/Services/Discount/Libraries/mShop.Discount.Data/mShop.Discount.Data.csproj", "src/Services/Discount/Libraries/mShop.Discount.Data/"]
COPY ["src/Services/Discount/Libraries/mShop.Discount.Core/mShop.Discount.Core.csproj", "src/Services/Discount/Libraries/mShop.Discount.Core/"]
COPY ["src/Common/mShop.Core/mShop.Core.csproj", "src/Common/mShop.Core/"]
RUN dotnet restore "src/Services/Discount/Presentation/mShop.Discount.Api/mShop.Discount.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Discount/Presentation/mShop.Discount.Api"
RUN dotnet build "mShop.Discount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mShop.Discount.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mShop.Discount.Api.dll"]
