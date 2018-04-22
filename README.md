## Bowling

### docker-compose:

* docker-compose up  (access localhost:8080)

### Docker image:

https://hub.docker.com/r/petertretorn/bowling/

usage: docker --rm -p 8080:80 petertretorn/bowling (access localhost:8080)

### Run locally

Requires Node and .NET Core 2

To run outside Visual Studio from root of solution type following commands:

* dotnet restore

* cd Bowling.Api

* npm install

* dotnet run
