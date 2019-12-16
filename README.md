# MarsRoverCodingExercise
Mars Rover Coding Exercise for Motorola Solutions

by Cody Hicks

> ### VERSIONS
> #### The `master` branch is currently running ASP.NET Core 3.0.

## Running the application locally

1) pull the  `master` branch
2) Open src/MarsRoverCodingExercise.sln in Visual Studio
3) With `MarsRoverCodingExercise.Web` set as the startup project, use Debug > Start Debugging to launch the web application and view the application Swagger
4) Unfold the "MarsPhoto" Controller accordion link
5) Click the GET method > Try it out
6) type in any of the 3 rover names: Curiosity, Opportunity, Spirit
7) Click Execute.. the process may take a few minutes to complete, depending on which rover was chosen

### Results
A response payload will eventually display, showing the path in which the images were placed.

### TODO
- Go to add some tests later on in a separate csproj.