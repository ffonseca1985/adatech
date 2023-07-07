#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apresentations/AdaTech.Card.WebApi/AdaTech.Card.WebApi.csproj", "src/Apresentations/AdaTech.Card.WebApi/"]
RUN dotnet restore "src/Apresentations/AdaTech.Card.WebApi/AdaTech.Card.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Apresentations/AdaTech.Card.WebApi"
RUN dotnet build "AdaTech.Card.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdaTech.Card.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdaTech.Card.WebApi.dll"]