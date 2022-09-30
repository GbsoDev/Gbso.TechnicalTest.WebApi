#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gbso.TechnicalTest.WebApi/Gbso.TechnicalTest.WebApi.csproj", "Gbso.TechnicalTest.WebApi/"]
RUN dotnet restore "Gbso.TechnicalTest.WebApi/Gbso.TechnicalTest.WebApi.csproj"
COPY . .
WORKDIR "/src/Gbso.TechnicalTest.WebApi"
RUN dotnet build "Gbso.TechnicalTest.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gbso.TechnicalTest.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gbso.TechnicalTest.WebApi.dll"]