FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS restore
WORKDIR /src
COPY ["src/InventoryAPI/InventoryAPI.csproj", "."]
RUN dotnet restore "InventoryAPI.csproj"

FROM restore AS build
COPY . .
RUN dotnet build "src/InventoryAPI/InventoryAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/InventoryAPI/InventoryAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InventoryAPI.dll"]
