#!/bin/bash

dotnet run --project src/Job.GraphQL.Users &
dotnet run --project src/Job.GraphQL.Orders &
dotnet run --project src/Job.GraphQL.Graph &

wait