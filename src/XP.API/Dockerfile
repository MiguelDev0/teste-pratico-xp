#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/XP.API/XP.API.csproj", "src/XP.API/"]
COPY ["XP.Business/XP.Business.csproj", "XP.Business/"]
COPY ["src/XP.Data/XP.Data.csproj", "src/XP.Data/"]
RUN dotnet restore "src/XP.API/XP.API.csproj"
COPY . .
WORKDIR "/src/src/XP.API"
RUN dotnet build "XP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XP.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XP.API.dll"]