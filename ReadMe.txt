Please see below for notes about each area of the solution. Due to time constraints a fully enterprise level
solution could not be developed however the foundation of the solution has been established with a working
CI/CD process that deploys the solution to Azure PaaS infrastructure.

URLS
Source Control: https://github.com/rocketman2687/CBA.Store
CI/CD: https://rocketmanproductions.visualstudio.com/CBA.Store
Product API: http://cba-store-api-as-dev.azurewebsites.net/api/product
Website: http://cba-store-web-as-dev.azurewebsites.net

DATA
- EF code first was used so to get the APIs up and running update the connection string in the web.config
and solution will create the DB and tables if the DB does not exist. There is a script in the database 
project with test data if required.
- Generally repository pattern would be built out to support CRUD operations but this was not required 
at present.

SECURITY
- HTTPS should be used for the front end and APIs but would require network infrastructure
- APIs should be secured with AD authentication or certificates depending on security requirements

EXCEPTION HANDLING
- Only pretty basic exception handling has been implemented due to time constraints. Foreseeable exceptions
could require special treatment and a logging framework would be used.

UI
- Default ASP MVC front end was used due to time constraints and my understanding was this was not the focus
of the exercise.

UNIT TESTING
- Dependency injection was used across most classes to enable unit testing however due to time constraints
code coverate is relatively low. Overall approach to unit testing has been established.
- Repository unit testing approach requires more time to establish.
- OpenCover was used to generate a unit testing report in the build pipeline, report is available as part
of the build artefacts.

BUILD PROCESS
- As per requirements build process was scripted, I used NodeJS, NPM and Gulp. Gulp was used simply because I've
used it recently but many other options are available. Gulp does provide good support for packaging web UIs.
- VSTS was used for hosting the automated build.
- I haven't enabled builds on check in because I have limited free build processing minutes.

DEPLOYMENT
- VSTS was used for automate deployments.
- DACPAC was used to deploy database objects and seed data, once again there's many options for this depending on requirements.

