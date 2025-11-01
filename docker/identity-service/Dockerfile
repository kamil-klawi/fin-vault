ARG DOTNET_VERSION=8.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

WORKDIR /src

COPY ["apps/IdentityService/IdentityService.sln", "apps/IdentityService/"]
COPY ["apps/IdentityService/IdentityService.Presentation/IdentityService.Presentation.csproj", "apps/IdentityService/IdentityService.Presentation/"]
COPY ["apps/IdentityService/IdentityService.Application/IdentityService.Application.csproj", "apps/IdentityService/IdentityService.Application/"]
COPY ["apps/IdentityService/IdentityService.Domain/IdentityService.Domain.csproj", "apps/IdentityService/IdentityService.Domain/"]
COPY ["apps/IdentityService/IdentityService.Infrastructure/IdentityService.Infrastructure.csproj", "apps/IdentityService/IdentityService.Infrastructure/"]
COPY ["apps/SharedLibrary/SharedLibrary/SharedLibrary.csproj", "apps/SharedLibrary/SharedLibrary/"]

RUN dotnet restore apps/IdentityService/IdentityService.sln

COPY ["apps/IdentityService/", "apps/IdentityService/"]
COPY ["apps/SharedLibrary/", "apps/SharedLibrary/"]

WORKDIR /src/IdentityService.Presentation

EXPOSE 5001

CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5001"]
