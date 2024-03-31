# Backend
- Install [.NET RUNTIME And SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) **Version 7.X.X** and [CLI EF TOOLS](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) for .NET
- IDE: preferred [VISUAL STUDIO](https://visualstudio.microsoft.com/pl/vs/community/) OR [RIDER](https://www.jetbrains.com/rider/)
- [Microsoft SQL Server CLient](https://learn.microsoft.com/pl-pl/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) to manage Database
## Database
### To create database follow this steps:
- run docker from provided [catalog](https://github.com/JakubPodlesnyGitHub/UJShop/tree/JP-Added_Db/Backend/Shop/Shop.API/Configuration/Docker)
- connect to server through client -> server name: **[localhost,1433]**, login: **sa**, password: **in sql server docker setup**
- create db named UJShop
- run command **"dotnet ef database update --startup-project ../Shop.API"** from **"UJShop\Backend\Shop\Shop.Infrastructure"** directory
- if in **"Infrastructure"** project in **"Migration"** folder there is nothing, run first command **"dotnet ef migrations add initMigration --startup-project ../Shop.API"** and then run **"dotnet ef database update --startup-project ../Shop.API"** from **"UJShop\Backend\Shop\Shop.Infrastructure"**
- database should created, if you wish to create database relational model and diagram you can do that from Microsoft SQL Server CLient
