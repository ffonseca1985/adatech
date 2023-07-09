FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT="development"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apresentations/AdaTech.Card.WebApi/AdaTech.Card.WebApi.csproj", "src/Apresentations/AdaTech.Card.WebApi/"]
COPY ["src/AdaTech.Application/AdaTech.Application.csproj", "src/AdaTech.Application/"]
COPY ["src/AdaTech.Domain/AdaTech.Domain.csproj", "src/AdaTech.Domain/"]
COPY ["src/Infra/AdaTech.Infra.Data/AdaTech.Infra.Data.csproj", "src/Infra/AdaTech.Infra.Data/"]
COPY ["src/Infra/AdaTech.Infra.Ioc/AdaTech.Infra.Ioc.csproj", "src/Infra/AdaTech.Infra.Ioc/"]
COPY ["src/Infra/AdaTech.Infra.Security/AdaTech.Infra.Security.csproj", "src/Infra/AdaTech.Infra.Security/"]


RUN dotnet restore "src/Apresentations/AdaTech.Card.WebApi/AdaTech.Card.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Apresentations/AdaTech.Card.WebApi"
RUN dotnet build "AdaTech.Card.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdaTech.Card.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
EXPOSE 5000
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdaTech.Card.WebApi.dll"]