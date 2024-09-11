#!/bin/sh

NAME=$1
PROJECT_PATH=/Users/dusan/Projects/tasty-trails

dotnet ef migrations add "$NAME" \
  --project $PROJECT_PATH/src/Infrastructure/Infrastructure.csproj \
  --startup-project $PROJECT_PATH/src/Orders.API/Orders.API.csproj \
  --output-dir Data/Migrations/