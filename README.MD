navigated to  webapp folder, used terminal command: 
dotnet new webapp --auth Individual
changed things according to identity tutorial https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=netcore-cli
commands:
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
dotnet add package Microsoft.EntityFrameworkCore.SqlServer //<- we want sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.EntityFrameworkCore.Sqlite


See Options
        --useSqLite|-sqlite   : Flag to specify if DbContext should use SQLite instead of SQL Server.
Command:
dotnet aspnet-codegenerator identity -dc webapp.Data.ApplicationDbContext --files "Account.Register;Account.Login" --useSqLite
    https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=netcore-cli

SendGrid Account created.
Create Services folder in webapp with the two cs files

//pulled //"applicationUrl": "https://localhost:7183;http://localhost:5030", out of launchSettings.json line 15, added line 16

Created Sendgrid sender

Created key
Command: 
dotnet user-secrets set SendGridKey <Key>

dotnet add package SendGrid

Implement IEmailSender in EmailSender.cs

config app to support email
added to Program.cs
[
using Microsoft.AspNetCore.Identity.UI.Services;
using webapp.Services;


builder.Services.AddTransient<IEmailSender, EmailSender>();      //line 19
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
]

https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=netcore-cli