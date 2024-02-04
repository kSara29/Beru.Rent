FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Services/Deal.Service/Deal.Api/Deal.Api.csproj", "Services/Deal.Service/Deal.Api/"]
COPY ["Services/Deal.Service/Deal.Application/Deal.Application.csproj", "Services/Deal.Service/Deal.Application/"]
COPY ["Services/Deal.Service/Deal.Domain/Deal.Domain.csproj", "Services/Deal.Service/Deal.Domain/"]
COPY ["Services/Deal.Service/Deal.Infrastructure/Deal.Infrastructure.csproj", "Services/Deal.Service/Deal.Infrastructure/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["BuildingBlocks/Deal.Dto/Deal.Dto.csproj", "BuildingBlocks/Deal.Dto/"]
RUN dotnet restore "Services/Deal.Service/Deal.Api/Deal.Api.csproj"
COPY . .
WORKDIR "/src/Services/Deal.Service/Deal.Api"
RUN dotnet build "Deal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deal.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deal.Api.dll"]
