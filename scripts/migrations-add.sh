#!/bin/sh

NAME=$1
PROJECT_PATH=/Users/dusan/Projects/tasty-trails

dotnet ef migrations add "$NAME" \
  --project $PROJECT_PATH/src/DeliveryChannel.Infrastructure/DeliveryChannel.Infrastructure.csproj \
  --startup-project $PROJECT_PATH/src/DeliveryChannel.API/DeliveryChannel.API.csproj