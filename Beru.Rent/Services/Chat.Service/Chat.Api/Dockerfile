FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Services/Chat.Service/Chat.Api/Chat.Api.csproj", "Services/Chat.Service/Chat.Api/"]
COPY ["Services/Chat.Service/Chat.Application/Chat.Application.csproj", "Services/Chat.Service/Chat.Application/"]
COPY ["Services/Chat.Service/Chat.Domain/Chat.Domain.csproj", "Services/Chat.Service/Chat.Domain/"]
COPY ["Services/Chat.Service/Chat.Infrastructure/Chat.Infrastructure.csproj", "Services/Chat.Service/Chat.Infrastructure/"]
COPY ["BuildingBlocks/Common/Common.csproj", "BuildingBlocks/Common/"]
COPY ["BuildingBlocks/Chat.Dto/Chat.Dto.csproj", "BuildingBlocks/Chat.Dto/"]
RUN dotnet restore "Services/Chat.Service/Chat.Api/Chat.Api.csproj"
COPY . .
WORKDIR "/src/Services/Chat.Service/Chat.Api"
RUN dotnet build "Chat.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.Api.dll"]
