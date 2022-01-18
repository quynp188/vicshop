#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VicShop.Api/VicShop.Api.csproj", "VicShop.Api/"]
RUN dotnet restore "VicShop.Api/VicShop.Api.csproj"
COPY . .
WORKDIR "/src/VicShop.Api"
RUN dotnet build "VicShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VicShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VicShop.Api.dll"]