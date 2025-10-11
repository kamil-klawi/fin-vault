#!/bin/bash
set -e

echo "Starting deployment..."

if [ -f ".env" ]; then
    echo "Loading environment from .env"
else
    echo "Missing .env file"
    exit 1
fi

docker compose --env-file .env up -d

echo "Deployment complete"
