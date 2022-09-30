# Gbso.Finance
# Environment Development Rules
	TAB indentation
	UTF-8 encoding
# Migration Command
	dotnet ef migrations  add  [MigrationName] --startup-project Gbso.Finance.WebApi --project Gbso.Finance.Dal
	dotnet ef migrations  add  [MigrationName] -s Gbso.Finance.WebApi -p Gbso.Finance.Dal