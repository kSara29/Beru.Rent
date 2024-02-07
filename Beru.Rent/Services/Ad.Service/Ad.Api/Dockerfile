FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Services/Ad.Service/Ad.Api/Ad.Api.csproj", "Services/Ad.Service/Ad.Api/"]
COPY ["Services/Ad.Service/Ad.Application/Ad.Application.csproj", "Services/Ad.Service/Ad.Application/"]
COPY ["Services/Ad.Service/Ad.Domain/Ad.Domain.csproj", "Services/Ad.Service/Ad.Domain/"]
COPY ["Services/Ad.Service/Ad.Infrastructure/Ad.Infrastructure.csproj", "Services/Ad.Service/Ad.Infrastructure/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["BuildingBlocks/Ad.Dto/Ad.Dto.csproj", "BuildingBlocks/Ad.Dto/"]
RUN dotnet restore "Services/Ad.Service/Ad.Api/Ad.Api.csproj"
COPY . .
WORKDIR "/src/Services/Ad.Service/Ad.Api"
RUN dotnet build "Ad.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ad.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ad.Api.dll"]
