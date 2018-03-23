Console commands for migrations:

Add migration for context: 

dotnet ef migrations add Initial(name) -c:BaseContext(your context)

Update: 

dotnet ef database update -c:BaseContext

Remove migration: 

dotnet ef migrations remove -c:BaseContext