# Challenge-WebAPI

This API is a programming competition game. 

It allows Players to enter therir name, choose from 5 different coding challenges and submit their code solution.
Additionally the code solution is sent to the jdoodle API for compilation and the result including the player name and solution are stored in a DB

The DB was made using .Net Core with Entity First approach. VS IIS Express was used for the server.

Since the task was to only Post Player results to the DB, the API can only create DB entry expect for when the challenges list are needed.

The option to CRUD challenges are not implemented. 

The WebAPI.mkv is a video file that showcases the functioning of the API
