# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/)

## [Unreleased]

- Added `IdentityService` directory containing authentication and user service logic.
- Added `ApiGateway` directory containing API gateway implementation.

## [v0.1.0] - 2025-10-19

- Added `SharedLibrary/` directory containing shared library for the backend services.
- Added `Common/` module containing shared logic, including:
  1. `Enums/` directory for reusable enumerations
  2. `Exceptions/` directory for custom exception classes
  3. `Extensions/` directory for helper and utility functions
  4. `Middleware/` directory for shared middleware components
  5. `Security/` directory for authentication and security logic
  6. `ValueObjects/` directory for domain-driven value objects
- Added `Contracts/` module containing reusable interfaces for:
  1. `Common/` directory with shared interfaces
  2. `User/` directory with user-related contracts

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
