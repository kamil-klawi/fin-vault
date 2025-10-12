#!/bin/bash
set -e

DATABASES=(
    "identity_service_db"
)

for db in "${DATABASES[@]}"; do
    echo "Checking if database ${db} exists"
    DB_EXISTS=$(psql -U "${POSTGRES_USER}" -d "${POSTGRES_DB}" -tAc "SELECT 1 FROM pg_database WHERE datname='${db}'")

    if [ "${DB_EXISTS}" = "1" ]; then
        echo "Database ${db} already exists, skipping..."
    else
        echo "Creating database: ${db}"
        psql -v ON_ERROR_STOP=1 -U "${POSTGRES_USER}" -d "${POSTGRES_DB}" <<-EOSQL
            CREATE DATABASE ${db};
EOSQL
    fi
done
