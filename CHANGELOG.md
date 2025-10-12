# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/)

## [Unreleased]

- Added `apps/` directory containing shared library for the backend services.

## [v0.0.2] - 2025-10-12

- Added configurations for `rabbitmq client`, `api-gateway` and `identity-service` in the `docker/` directory.
- Added dockerfiles for the `api-gateway` and `identity-service`.
- Added `init-multi-dbs` and `stop` scripts to the `scripts/` directory.
- Added `start`, `stop` and `cleanup` commands to the `Makefile` file.

## [v0.0.1] - 2025-10-11

### Added

- Added `CHANGELOG.md` file.
- Added `LICENSE` file.
- Added `README.md` with project overview.
- Added configuration files such as `.editorconfig`, `.gitattributes` and `.gitignore`.
- Added `docker/` directory with docker-compose configuration files for the Postgres and pgAdmin4.
- Added `docs/` directory containing documentation on API reference.
- Added `scripts/` directory with `start` and `cleanup` scripts.
