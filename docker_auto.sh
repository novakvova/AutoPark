#!/bin/bash

set -e

server_up() {
    echo "Server up..."
    docker pull novakvova/auto-asp-api:latest
    docker stop auto-asp_container || true
    docker rm auto-asp_container || true
    docker run -d --restart=always -v /volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api
}

start_containers() {
    echo "Containers start..."
    docker run -d --restart=always -v /volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api
}

stop_containers() {
    echo "Containers stop..."
    docker stop auto-asp_container || true
    docker rm auto-asp_container || true
}

restart_containers() {
    echo "Containers restart..."
    docker stop auto-asp_container || true
    docker rm auto-asp_container || true
    docker run -d --restart=always -v /volumes/auto-asp/images:/app/uploading --name auto-asp_container -p 4391:8080 novakvova/auto-asp-api
}

echo "Choose action:"
echo "1. Server up"
echo "2. Containers start"
echo "3. Containers stop"
echo "4. Containers restart"
read -p "Enter action number: " action

case $action in
    1)
        server_up
        ;;
    2)
        start_containers
        ;;
    3)
        stop_containers
        ;;
    4)
        restart_containers
        ;;
    *)
        echo "Invalid action number!"
        exit 1
        ;;
esac
