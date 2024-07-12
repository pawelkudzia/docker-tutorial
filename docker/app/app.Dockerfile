FROM mcr.microsoft.com/dotnet/sdk:8.0.303-alpine3.20-amd64 AS build
WORKDIR /project
RUN mkdir -p src/Project.Api

# copy csproj and restore as distinct layers
COPY ./app/Project/src/*.sln .
COPY ./app/Project/src/Project.Api/*.csproj ./src/Project.Api
RUN dotnet restore ./src/Project.Api/*.csproj

# copy everything else and build app
COPY ./src/Project.Api ./src/Project.Api
RUN dotnet publish --nologo --no-restore --configuration Release --output ./bin ./src/Project.Api/Project.Api.csproj

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0.7-alpine3.20-amd64
WORKDIR /app
COPY --from=build /project/bin .
ENTRYPOINT ["dotnet", "Project.Api.dll"]
