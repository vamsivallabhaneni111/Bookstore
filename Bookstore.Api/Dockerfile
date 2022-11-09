# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app
    
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY Bookstore.Api/*.csproj ./Bookstore.Api/
COPY Bookstore.Domain/*.csproj ./Bookstore.Domain/
COPY Bookstore.Repository/*.csproj ./Bookstore.Repository/
COPY Bookstore.Repository.Mongo/*.csproj ./Bookstore.Repository.Mongo/
COPY Bookstore.Services/*.csproj ./Bookstore.Services/

RUN dotnet restore "Bookstore.Api"

# Copy everything else and build
COPY . .

WORKDIR /app/Bookstore.Api
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
   
COPY --from=build-env /app/Bookstore.Api/out .
ENTRYPOINT ["dotnet", "Bookstore.Api.dll"]