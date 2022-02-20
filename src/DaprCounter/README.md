# Introduction 
Baby steps with Dapr
# Getting Started

This example is from here.
https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/getting-started

Do the following

1. dotnet restore
2. dotnet build

You need to run this app with dapr and not directly.

Do the following.

First start docker

Then initialize dapr with the following command

dapr init

Ensure state store is running as a docker container.

Once it is initialized, there are several ways to run the app.

Run the following command.
This will ask dapr to run this app.
dapr run --app-id DaprCounter dotnet run

You can run the poweshell script **run-app.ps1** as well. It will run the same command.



Once the app is running, to view the state of the app, get into the container.

https://docs.dapr.io/getting-started/get-started-api/#step-4-see-how-the-state-is-stored-in-redis

docker exec -it dapr_redis redis-cli

Here redis-cli is the command name that you need to execute inside of the container.

Once you are the redis cli, type 'keys *' to see the keys.

hgetall "DaprCounter || counter"