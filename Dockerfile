FROM microsoft/aspnetcore-build:2

WORKDIR /app

COPY . .

WORKDIR /app/Bowling.Api

RUN dotnet publish -o /publish

WORKDIR /publish

ENTRYPOINT [ "dotnet", "/publish/Bowling.Api.dll" ]



