#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# USER app
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./CursoOnline.API/CursoOnline.API.csproj", "CursoOnline.API/"]
RUN dotnet restore "./CursoOnline.API/CursoOnline.API.csproj"
COPY ["./CursoOnline.Application/CursoOnline.Application.csproj", "CursoOnline.Application/"]
RUN dotnet restore "./CursoOnline.Application/CursoOnline.Application.csproj"
COPY ["./CursoOnline.Domain/CursoOnline.Domain.csproj", "CursoOnline.Domain/"]
RUN dotnet restore "./CursoOnline.Domain/CursoOnline.Domain.csproj"
COPY ["./CursoOnline.Repository/CursoOnline.Repository.csproj", "CursoOnline.Repository/"]
RUN dotnet restore "./CursoOnline.Repository/CursoOnline.Repository.csproj"
COPY . .
WORKDIR "/src/CursoOnline.API"
RUN dotnet build "./CursoOnline.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CursoOnline.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CursoOnline.API.dll"]