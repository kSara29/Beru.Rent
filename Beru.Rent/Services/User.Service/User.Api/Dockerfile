FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["Services/User.Service/User.Api/User.Api.csproj", "Services/User.Service/User.Api/"]
COPY ["Services/User.Service/User.Application/User.Application.csproj", "Services/User.Service/User.Application/"]
COPY ["Services/User.Service/User.Domain/User.Domain.csproj", "Services/User.Service/User.Domain/"]
COPY ["Services/User.Service/User.Infrastructure/User.Infrastructure.csproj", "Services/User.Service/User.Infrastructure/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["BuildingBlocks/User.Dto/User.Dto.csproj", "BuildingBlocks/User.Dto/"]
RUN dotnet restore "Services/User.Service/User.Api/User.Api.csproj"
COPY . .
WORKDIR "/src/Services/User.Service/User.Api"
RUN dotnet build "User.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Api.dll"]
