#!/bin/bash
set -e

echo "Stopping and removing Docker Compose services..."

CONTAINERS=$(docker compose ps -q)

if [ -z "${CONTAINERS}" ]; then
    echo "No container exists"
else
    docker compose down --rmi all --volumes
fi

echo "Docker compose cleanup done"
