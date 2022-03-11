#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Ordering/Presentation/mShop.Ordering.Api/mShop.Ordering.Api.csproj", "src/Services/Ordering/Presentation/mShop.Ordering.Api/"]
COPY ["src/Services/Ordering/Libraries/mShop.Ordering.Application/mShop.Ordering.Application.csproj", "src/Services/Ordering/Libraries/mShop.Ordering.Application/"]
COPY ["src/Services/Ordering/Libraries/mShop.Ordering.Services/mShop.Ordering.Services.csproj", "src/Services/Ordering/Libraries/mShop.Ordering.Services/"]
COPY ["src/Services/Ordering/Libraries/mShop.Ordering.Data/mShop.Ordering.Data.csproj", "src/Services/Ordering/Libraries/mShop.Ordering.Data/"]
COPY ["src/Services/Ordering/Libraries/mShop.Ordering.Core/mShop.Ordering.Core.csproj", "src/Services/Ordering/Libraries/mShop.Ordering.Core/"]
COPY ["src/Common/mShop.Core/mShop.Core.csproj", "src/Common/mShop.Core/"]
RUN dotnet restore "src/Services/Ordering/Presentation/mShop.Ordering.Api/mShop.Ordering.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Ordering/Presentation/mShop.Ordering.Api"
RUN dotnet build "mShop.Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mShop.Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mShop.Ordering.Api.dll"]