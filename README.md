# StarWarsCharacter-WebApp

### Prerequisites

NPM installed and setup
Node installed and setup
ASP.NET7 Runtime and SDK

### Get Started Instructions

To get a local dev copy running.
1. Clone this repo to your local

To run the ASP.NET7 WebApi: 
1. In a terminal window, navigate to the directory "/StarWarsCharacter-Api"
1. Trust the HTTPS development certificate by running the following command "dotnet dev-certs https --trust"
2. To run the api "dotnet run --launch-profile https" _(API swagger documentation is now served on https://localhost:7500/swagger or http://localhost:7499/swagger, and terminate it via 'control + c')_

To run React Client: 
1. In a terminal window, navigate to the directory "/StarWarsCharacter-Client"
2. Install packages with "npm install"
3. To run the client "npm run dev" _(Client is now served on http://localhost:7501/, and terminate it via 'control + c')_