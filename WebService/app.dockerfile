FROM mcr.microsoft.com/dotnet/sdk:7.0.401-alpine3.18-amd64 AS build
WORKDIR /source
RUN mkdir -p src/WebService.Api

# copy csproj and restore as distinct layers
COPY *.sln ./source
COPY ./src/WebService.Api/*.csproj ./src/WebService.Api
RUN dotnet restore ./src/WebService.Api/*.csproj

# copy everything else and build app
COPY ./src/WebService.Api ./src/WebService.Api
RUN dotnet publish --nologo --no-restore --configuration Release --output /app ./src/WebService.Api/WebService.Api.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0.11-alpine3.18-amd64
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WebService.Api.dll"]
