@echo off

echo Docker login...
docker login

cd "WebAutoPark"

echo Building Docker image api...
docker build -t auto-asp-api .

echo Tagging Docker image api...
docker tag auto-asp-api:latest novakvova/auto-asp-api:latest

echo Pushing Docker image api to repository...
docker push novakvova/auto-asp-api:latest

echo Done ---api---!
pause

