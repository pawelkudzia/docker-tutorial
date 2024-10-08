# Docker Tutorial

This demo shows how to use basic [Docker](https://www.docker.com/) commands and [docker-compose](https://docs.docker.com/compose/) which allows running multi-container Docker applications.

Repository contains two containers:

1. `WebService` is web service created by using [.NET](https://dotnet.microsoft.com/download),
2. `nginx` represents frontend of the software which in this case is reverse proxy server. [nginx](https://nginx.org/en/) is popular HTTP and reverse proxy server.

## Create application

```text
dotnet new webapi --name WebService.Api
```

```text
dotnet new xunit --name WebService.Tests.EndToEnd
```

```text
dotnet new sln --name WebService
```

```text
dotnet sln WebService.sln add ./src/WebService.Api/WebService.Api.csproj
```

```text
dotnet sln WebService.sln add ./tests/WebService.Tests.EndToEnd/WebService.Tests.EndToEnd.csproj
```

```text
dotnet add ./tests/WebService.Tests.EndToEnd/WebService.Tests.EndToEnd.csproj reference ./src/WebService.Api/WebService.Api.csproj
```

## NuGet

Project `WebService.Tests.EndToEnd` uses following NuGet packages.

```text
dotnet add package Microsoft.AspNetCore.Mvc.Testing --version 7.0.2
```

## Deploy

```text
dotnet-outdated -u
```

```text
dotnet build
```

```text
dotnet test
```

```text
dotnet publish --nologo --configuration Release --output ./app ./src/WebService.Api/WebService.Api.csproj
```

## Tools

- [Autofac](https://github.com/autofac/Autofac.Extensions.DependencyInjection/issues/97),
- [dotnet-outdated](https://github.com/dotnet-outdated/dotnet-outdated).

## Running containers with run command

Multiple containers can communicate with each other only when they are in the same network.

```text
docker network create docker_tutorial_network
```

Build application image based on Dockerfile and then run container.

```text
docker build -t docker-tutorial-webservice .
```

```text
docker run -dp 5000:80 --network docker_tutorial_network --network-alias app docker-tutorial-webservice
```

Build nginx image based on Dockerfile and then run container.

```text
docker build -t docker-tutorial-nginx .
```

```text
docker run -dp 80:8080 --network docker_tutorial_network --network-alias server docker-tutorial-nginx
```

## Running containers with docker-compose

Container definitions should be stored in `compose.yaml` file.

```text
docker-compose build
```

```text
docker-compose up -d
```

```text
docker-compose down
```

```text
docker-compose ps -a
```

```text
docker-compose logs -f
```

## Additional commands

To run command in running container following command should be used.

```text
docker exec -it <container-id> /bin/sh
```

```text
docker exec <service> /bin/sh
```

Run [go-wrk](https://github.com/tsliwowicz/go-wrk) with network which `WebService` and `nginx` use.

```text
docker run -it --network docker_tutorial_network --network-alias go-wrk williamwalter/go-wrk -c 256 -d 60 http://app/api/test
```

The same as above but network name in `docker-compose` case is different.

```text
docker run -it --network docker-tutorial_default --network-alias go-wrk williamwalter/go-wrk -c 256 -d 60 http://app/api/test
```

## License

This repository is licensed under the [MIT](https://github.com/pawelkudzia/docker-tutorial/blob/main/LICENSE) license.
