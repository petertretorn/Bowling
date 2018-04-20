FROM microsoft/aspnetcore-build AS build-env

COPY . ./

WORKDIR /Bowling.Api

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.0-runtime 
COPY --from=build-env /Bowling.Api/out ./
ENTRYPOINT ["dotnet", "Bowling.Api.dll"]
