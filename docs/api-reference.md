# Api reference

This document provides a full list of REST API endpoints available in the **FinVault** platform.

## Authentication, Authorization and User

| Method     | Endpoint                | Notes                               | Who  | Status   |
|------------|-------------------------|-------------------------------------|------|----------|
| **POST**   | `/auth/register`        | Register a new user                 | User | Core     |
| **POST**   | `/auth/login`           | Log in to the platform              | User | Core     |
| **POST**   | `/auth/logout`          | Log out from the platform           | User | Core     |
| **POST**   | `/auth/email/verify`    | Verify user using confirmation code | User | Core     |
| **POST**   | `/auth/password/forgot` | Request a password reset            | User | Core     |
| **POST**   | `/auth/password/reset`  | Reset password with a token         | User | Core     |
| **POST**   | `/auth/2fa/enable`      | Enable 2FA                          | User | Optional |
| **POST**   | `/auth/2fa/verify`      | Verify 2FA Code                     | User | Optional |
| **POST**   | `/auth/2fa/disable`     | Disable 2FA                         | User | Optional |
| **GET**    | `/users/me`             | Get current user info               | User | Core     |
| **PATCH**  | `/users/me`             | Update current user info            | User | Core     |
| **DELETE** | `/users/me`             | Delete current user account         | User | Core     |

## Bank accounts

| Method     | Endpoint                 | Notes                                        | Who  | Status |
|------------|--------------------------|----------------------------------------------|------|--------|
| **GET**    | `/accounts`              | Retrieve all bank accounts owned by the user | User | Core   |
| **POST**   | `/accounts`              | Create a new bank account                    | User | Core   |
| **GET**    | `/accounts/{id}`         | Retrieve details of a specific bank account  | User | Core   |
| **PATCH**  | `/accounts/{id}`         | Update user's bank account details           | User | Core   |
| **DELETE** | `/accounts/{id}`         | Close the account                            | User | Core   |
| **GET**    | `/accounts/{id}/balance` | Get the current account balance              | User | Core   |

## Reports

| Method     | Endpoint                     | Notes                    | Who  | Status   |
|------------|------------------------------|--------------------------|------|----------|
| **GET**    | `/reports/balance-history`   | Export balance history   | User | Core     |
| **GET**    | `/reports/monthly-statement` | Export monthly statement | User | Optional |
| **GET**    | `/reports/spending-summary`  | Export spending summary  | User | Optional |

## Transactions

| Method     | Endpoint                         | Notes                                                    | Who  | Status |
|------------|----------------------------------|----------------------------------------------------------|------|--------|
| **GET**    | `/transactions/`                 | Retrieves the transaction history of all user accounts   | User | Core   |
| **GET**    | `/transactions/{accountId}`      | Retrieves the transaction history for a specific account | User | Core   |
| **GET**    | `/transactions/{accountId}/{id}` | Retrieves the single transaction for a specific account  | User | Core   |

## Transfers

| Method     | Endpoint                    | Notes                       | Who  | Status   |
|------------|-----------------------------|-----------------------------|------|----------|
| **POST**   | `/transfers`                | Execute a transfer          | User | Core     |
| **POST**   | `/transfers/schedule`       | Schedule a future transfer  | User | Optional |
| **GET**    | `/transfers/scheduled`      | List of scheduled transfers | User | Optional |
| **DELETE** | `/transfers/scheduled/{id}` | Cancel a scheduled transfer | User | Optional |
