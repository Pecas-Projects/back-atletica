#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Back-Atletica.csproj", ""]
RUN dotnet restore "./Back-Atletica.csproj"
COPY . .
RUN dotnet restore 
RUN dotnet build "Back-Atletica.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Back-Atletica.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Back-Atletica.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Back-Atletica.dll