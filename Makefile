

install-deps:
	dotnet restore

run: 
	dotnet run --project src/RocketseatAuction.API/RocketseatAuction.API.csproj