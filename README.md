# StarWarsCharacter-WebApp

### Prerequisites

- Node installed and setup
- NPM installed and setup
- ASP.NET7 Runtime and SDK

### Get Started Instructions

To get a local dev copy running.
1. Clone this repo to your local

To run the ASP.NET7 WebApi: 
1. In a terminal window, navigate to the directory "/StarWarsCharacter-Api"
1. If first time, might have to trust the HTTPS development certificate by running the following command "dotnet dev-certs https --trust"
2. To run the api "dotnet run --launch-profile https" _(API swagger documentation is now served on https://localhost:7500/swagger or http://localhost:7499/swagger, and terminate it via 'control + c' in the terminal window)_

To run React Client: 
1. In a terminal window, navigate to the directory "/StarWarsCharacter-Client"
2. Install packages with "npm install"
3. To run the client "npm run dev" _(Client is now served on http://localhost:7501/, and terminate it via 'control + c' in the terminal window)_

### About this project

Simple project featuring an ASP.NET7 API backend with a React Frontend.

ASP.NET7 API:
- The structure of the API is Controller -> Repository. 
- Controller to handle HTTP Request/Response and the Repository is what provides the data.
- The repository in this case in essentially a "proxy" for the StarWarsApi, but have tried to stay decoupled from it's domain models by using Data Transfer Objects (DTOs). Features a simple mapper to convert from the SwapiPersonDTO to this api's Character domain model.
- Use of interfaces and dependency injection/inversion to help with any future changes and testibility.
- Very basic and simple error handling and logging included.
- Performance is not great for GetCharacters, mainly due to deserialization and pagination for the external API call. Brief was pretty open ended, so would look to open discussion on this (maybe I have approached this wrong and data could've been persisted to a DB?). Not sure, anyhow have left some comments with some potential ideas regarding this.

React Frontend:
- Nothing too special here, just a way of calling and displaying data from the API really.