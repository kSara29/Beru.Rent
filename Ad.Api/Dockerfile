FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Ad.Api/Ad.Api.csproj", "Ad.Api/"]
RUN dotnet restore "Ad.Api/Ad.Api.csproj"
COPY . .
WORKDIR "/src/Ad.Api"
RUN dotnet build "Ad.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ad.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ad.Api.dll"]
