# MarsRoverCodingExercise
Mars Rover Coding Exercise for Motorola Solutions

by Cody Hicks

> ### VERSIONS
> #### The `master` branch is currently running ASP.NET Core 3.0.

## Start the API

1) pull the  `master` branch
2) Open `{ProjectLocation}/src/MarsRoverCodingExercise.sln` in Visual Studio
3) With `MarsRoverCodingExercise.Web` set as the startup project, use Debug > Start Debugging to launch the web application and view the application Swagger
4) Unfold the "MarsPhoto" Controller accordion link
5) Click the GET method > Try it out
6) type in any of the 3 rover names: Curiosity, Opportunity, Spirit
7) Click Execute.. the process may take a few minutes to complete, depending on which rover was chosen

## Start the SPA, display the images
1) Leave the API up and running through Visual Studio
2) If you do not already have NodeJs installed, you'll want to install the "LTS" version from https://nodejs.org/en/ - be sure to set the installer to allow you to use Command Prompt for commands
3) Once node is installed, you'll want to go ahead and install Angular CLI by opening either Powershell or CMD and entering `npm install -g @angular/cli`
4) In either Powershell or CMD, cd to `{ProjectLocation}/src/MarsRoverCodingExercise.SPA`
5) With the current directory set to the Angular project, restore the project dependencies by typing command `npm i` and pressing enter
6) Once the npm indicates that all packages are installed, run the SPA by entering command `npm ng serve`
7) Once the terminal indicates that all resources are built, open your favorite web browser and navigate to `localhost:4200`
8) follow the on-screen instruction

### TODO
- Go to add some tests later on in a separate csproj.