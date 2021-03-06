FROM microsoft/aspnetcore-build:2 as build-env
WORKDIR /app
COPY . .
WORKDIR /app/Bowling.Api
RUN dotnet publish -o /publish

FROM microsoft/aspnetcore:2
WORKDIR /publish
COPY --from=build-env /publish .
ENTRYPOINT [ "dotnet", "/publish/Bowling.Api.dll" ]



