#!/bin/sh

PROJECT_PATH=/Users/dusan/Projects/tasty-trails

dotnet ef database update \
  --project $PROJECT_PATH/src/DeliveryChannel.Infrastructure/DeliveryChannel.Infrastructure.csproj \
  --startup-project $PROJECT_PATH/src/DeliveryChannel.API/DeliveryChannel.API.csproj