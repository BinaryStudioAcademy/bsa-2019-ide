## Stats
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/d3fc6cda260c47acac06b39631bbce0e)](https://app.codacy.com/app/Potapy4/bsa-2019-ide?utm_source=github.com&utm_medium=referral&utm_content=BinaryStudioAcademy/bsa-2019-ide&utm_campaign=Badge_Grade_Dashboard)
[![Build Status](https://dev.azure.com/npotapenko/bsa-ide/_apis/build/status/BinaryStudioAcademy.bsa-2019-ide?branchName=master)](https://dev.azure.com/npotapenko/bsa-ide/_build/latest?definitionId=7&branchName=master)

# BSA IDE
The main goal of the project is to provide an easy possibility to create and edit the user's project and then build and run it online in a browser. Users can collaborate with other people to update the project.

## Tech stack:
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [MongoDB](https://www.mongodb.com)
- [.NET Core](https://dotnet.microsoft.com/download)
- [SignalR](https://dotnet.microsoft.com/apps/aspnet/signalr)
- [RabbitMQ](https://www.rabbitmq.com)
- [ELK Stack](https://www.elastic.co/what-is/elk-stack)
- [Angular](https://angular.io)
- [PrimeNG](https://www.primefaces.org/primeng/#/)
- [Sass](https://sass-lang.com)
- [Monaco Editor](https://microsoft.github.io/monaco-editor)

## Setting up environment
1. Tools you need before you get started:
- [Docker](https://www.docker.com/get-started)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Azure Storage Emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator)
- [Visual Studio](https://visualstudio.microsoft.com)
- [VS Code](https://code.visualstudio.com)
- [Node.js](https://nodejs.org/en)
- [Angular CLI](https://cli.angular.io)

2. List of environment variables:

| Variable name | Value |
| --- | --- |
| SecretJWTKey | Some MD5 hash e.g. `4a7e62760b0806c3e4d0de416ed53305` |
| BsaIdeImgurClientId | ClientID from [Imgur API](https://apidocs.imgur.com) |
| emailApiKey | [Sendgrid API KEY](https://sendgrid.com/docs/ui/account-and-settings/api-keys/#managing-api-keys) |

## Build and run
1. Clone or download this repo.
2. Open **backend/IDE.sln** and **backend/BuildServer/BuildServer.sln** via Visual Studio.
3. Review the `appsettings.json` file and update the connection strings, if necessary.
4. Rebuild the **IDE.sln** & **BuildServer.sln** and run the **IDE.API** & **BuildServer** projects.
5. Open the **frontend/** folder via command line and execute `npm i`, and then `ng serve` - the frontend app will be built and run in `http://localhost:4200`.
