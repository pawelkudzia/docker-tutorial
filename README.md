# Docker Tutorial

This is demo which shows how to use basic [Docker](https://www.docker.com/) commands and [docker-compose](https://docs.docker.com/compose/) which allows running multi-container Docker applications.

Repository contains two containers:
1. `Software` is very simple web service created by using [.NET](https://dotnet.microsoft.com/download) technology,
2. `nginx` represents frontend of the whole software which in this case is reverse proxy server. [nginx](https://nginx.org/en/) is popular HTTP and reverse proxy server.

## Commands

There are useful commands.

### Prepare application

For building the `Software` application for production environment following command should be used.

`dotnet publish --nologo --configuration Release --output ./app ./src/WebService/WebService.csproj`

### Running containers with run command

Multiple containers can communicate with each other only when they are in the same network.

`docker network create docker_tutorial_network`

Build application image based on Dockerfile and then run container.

`docker build -t docker-tutorial-webservice .`

`docker run -dp 5000:80 --network docker_tutorial_network --network-alias app docker-tutorial-webservice`

Build nginx image based on Dockerfile and then run container.

`docker build -t docker-tutorial-nginx .`

`docker run -dp 80:8081 --network docker_tutorial_network --network-alias server docker-tutorial-nginx`

### Running containers with docker-compose

Container definitions should be stored in `docker-compose.yml` file.

Start, stop or show running containers.

`docker-compose up -d`

`docker-compose down`

`docker-compose ps -a`

### Additional commands

To run command in running container following command should be used.

`docker exec -it <container-id> /bin/sh`

`docker exec <service> /bin/sh`

Run [go-wrk](https://github.com/tsliwowicz/go-wrk) with the same network which `Software` and `nginx` use.

`docker run -it --network docker_tutorial_network --network-alias go-wrk williamwalter/go-wrk -c 256 -d 60 http://app/api/test`

The same as above but network name in `docker-compose` case is different.

`docker run -it --network docker-tutorial_default --network-alias go-wrk williamwalter/go-wrk -c 256 -d 60 http://app/api/test`
