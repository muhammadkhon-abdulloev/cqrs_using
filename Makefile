migrate:
	dotnet ef migrations add $(name) --project Infrastructure/Infrastructure.csproj --startup-project WebAPI/WebAPI.csproj --context $(application_context)