## Steps to build your own snake game runs on Web Browser using ASP.NET Blazor

- Run below command on the folder you are planning to create the project and it will show you what are the files and folders "blazorwasm" template will create.
`dotnet new blazorwasm -n "Dotnet.Blazor.SnakeGame.UI" --dry-run`

- Run below command on the folder you are planning to create the project and it will create the project.
`dotnet new blazorwasm -n "Dotnet.Blazor.SnakeGame.UI"`

- Run below command on the root folder if you want to add a solution file.
`dotnet new sln -n "Dotnet.Blazor.SnakeGame.UI"`
then run below command to add the project to the solution.
`dotnet sln add "Dotnet.Blazor.SnakeGame.UI/Dotnet.Blazor.SnakeGame.UI.csproj"`

- Add project reference to the project.
`dotnet add Dotnet.Blazor.SnakeGame.Console/Dotnet.Blazor.SnakeGame.Console.csproj reference Dotnet.Blazor.SnakeGame.Core/Dotnet.Blazor.SnakeGame.Core.csproj`

- Run below command on the folder you are planning to create the project and it will create the project.
`dotnet run`

