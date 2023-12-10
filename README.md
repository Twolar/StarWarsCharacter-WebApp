# StarWarsCharacter-WebApp

<!-- GETTING STARTED -->
## Getting Started

To get a local copy with dev running locally

### Prerequisites

NPM installed and setup
Node installed and setup
ASP.NET7 Runtime and SDK

### Get Started Instructions

For the ASP.NET7 WebApi: 
1. In your terminal, navigate to the directory "/StarWarsCharacter-Api"
1. Trust the HTTPS development certificate by running the following command "dotnet dev-certs https --trust"
2. To run the api "dotnet run --launch-profile https" _(API swagger documentation is now served on https://localhost:7500/swagger or http://localhost:7499/swagger, and terminate it via 'control + c')_

For the React Client: 
1. In your terminal, navigate to the directory "/StarWarsCharacter-Client"
2. Install packages with "npm install"
3. To run the client "npm run dev" _(Client is now served on http://localhost:7501/, and terminate it via 'control + c')_