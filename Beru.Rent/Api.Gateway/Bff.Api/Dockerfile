FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api.Gateway/Bff.Api/Bff.Api.csproj", "Api.Gateway/Bff.Api/"]
COPY ["Api.Gateway/Bff.Application/Bff.Application.csproj", "Api.Gateway/Bff.Application/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["BuildingBlocks/User.Dto/User.Dto.csproj", "BuildingBlocks/User.Dto/"]
COPY ["BuildingBlocks/Deal.Dto/Deal.Dto.csproj", "BuildingBlocks/Deal.Dto/"]
COPY ["BuildingBlocks/Ad.Dto/Ad.Dto.csproj", "BuildingBlocks/Ad.Dto/"]
RUN dotnet restore "Api.Gateway/Bff.Api/Bff.Api.csproj"
COPY . .
WORKDIR "/src/Api.Gateway/Bff.Api"
RUN dotnet build "Bff.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Bff.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bff.Api.dll"]
