FROM mcr.microsoft.com/dotnet/sdk:6.0.302-alpine3.16-amd64 AS build
WORKDIR /source
RUN mkdir -p src/WebService

# copy csproj and restore as distinct layers
COPY *.sln ./source
COPY ./src/WebService/*.csproj ./src/WebService
RUN dotnet restore ./src/WebService/*.csproj

# copy everything else and build app
COPY ./src/WebService ./src/WebService
RUN dotnet publish --nologo --no-restore --configuration Release --output /app ./src/WebService/WebService.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.7-alpine3.16-amd64
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WebService.dll"]
