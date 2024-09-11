#!/bin/sh

PROJECT_PATH=/Users/dusan/Projects/tasty-trails

dotnet ef database update \
  --project $PROJECT_PATH/src/Infrastructure/Infrastructure.csproj \
  --startup-project $PROJECT_PATH/src/Orders.API/Orders.API.csproj  