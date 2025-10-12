ARG DOTNET_VERSION=8.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY apps/IdentityService/IdentityService.sln ./
COPY apps/IdentityService/IdentityService.Presentation/IdentityService.Presentation.csproj ./src/IdentityService.Presentation/
COPY apps/IdentityService/IdentityService.Application/IdentityService.Application.csproj ./src/IdentityService.Application/
COPY apps/IdentityService/IdentityService.Domain/IdentityService.Domain.csproj ./src/IdentityService.Domain/
COPY apps/IdentityService/IdentityService.Infrastructure/IdentityService.Infrastructure.csproj ./src/IdentityService.Infrastructure/

RUN dotnet restore IdentityService.sln

COPY apps/IdentityService/ ./

WORKDIR /src/IdentityService.Presentation

EXPOSE 5001

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5001"]
