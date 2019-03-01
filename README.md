# Todo Application using Angular 7, .NET Core Web API, and SQLite

This is a simple todo application that lists todo, add todo, update todo, and delete todo.

Needed applications:

- .NET Core 2.1^
- Node.JS 8.5^
- Angular CLI 7.0^
- DB Browser for SQLite 3.11.1^
- Visual Studio Code
- Insomnia/Postman *Optional*

## How to run app

### Angular `TODO-SPA`

1. Go to `/TODO-SPA`.
1. Install necessary packages by using the command `npm install`.
1. Run the app by using the command `ng serve`.
1. Open the browser and go to `http://localhost:4200`.

### .NET Core Web API `TODO`

1. Go to `/TODO`.
2. Run to build the application by using the command `dotnet build`.
3. Run the app by using the command `dotnet run`.
4. Test the application by using the `Angular` app or using the `REST` tools such as **Insomnia** or **Postman**.

## Run the application using VS Code debugger.

1. Open VS Code and open terminal.
2. Go to `/TODO-SPA`.
3. Run the `Angular` app using the command `ng serve`.
4. Go to Debug by using the quick command `Ctrl+Shift+D`.
5. In dropdown, run `.NET Core Launch (web)` and `Launch chrome against Localhost`.