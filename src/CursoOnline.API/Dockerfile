#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["CursoOnline.API/CursoOnline.API.csproj", "CursoOnline.API/"]
#RUN dotnet restore "./CursoOnline.API/CursoOnline.API.csproj"
#COPY ["CursoOnline.Domain/CursoOnline.Domain.csproj", "CursoOnline.Domain/"]
#RUN dotnet restore "CursoOnline.Domain/CursoOnline.Domain.csproj"
#COPY ["CursoOnline.Repository/CursoOnline.Repository.csproj", "CursoOnline.Repository/"]
#RUN dotnet restore "CursoOnline.Repository/CursoOnline.Repository.csproj"
#COPY ["CursoOnline.Application/CursoOnline.Application.csproj", "CursoOnline.Application/"]
#RUN dotnet restore "CursoOnline.Application/CursoOnline.Application.csproj"
#COPY . .
#WORKDIR "/src/CursoOnline"
#RUN dotnet build "CursoOnline.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./CursoOnline.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CursoOnline.API.dll"]

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
ARG TARGETARCH

COPY . /source

WORKDIR /source/src

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS development
COPY . /source
WORKDIR /source/src
CMD dotnet run --no-launch-profile

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS final
WORKDIR /app

# Copy everything needed to run the app from the "build" stage.
COPY --from=build /app .

# Create a non-privileged user that the app will run under.
# See https://docs.docker.com/develop/develop-images/dockerfile_best-practices/#user
ARG UID=10001
RUN adduser \
   --disabled-password \
   --gecos "" \
   --home "/nonexistent" \
   --shell "/sbin/nologin" \
   --no-create-home \
   --uid "${UID}" \
   appuser
USER appuser

ENTRYPOINT ["dotnet", "CursoOnline.dll"]
