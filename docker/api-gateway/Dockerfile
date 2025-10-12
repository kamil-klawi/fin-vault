ARG DOTNET_VERSION=8.0

# Build
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY apps/ApiGateway/ApiGateway.sln ./
COPY apps/ApiGateway/ApiGateway.Presentation/ApiGateway.Presentation.csproj ./src/ApiGateway.Presentation/

RUN dotnet restore ApiGateway.sln

COPY apps/ApiGateway/ ./

WORKDIR /src/ApiGateway.Presentation

EXPOSE 5000

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]
