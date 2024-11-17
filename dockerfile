FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./HelloWorldAPI/*.csproj ./HelloWorldAPI/
COPY ./Tests/*.csproj ./Tests/

RUN dotnet restore ./Tests/Tests.csproj

COPY . .

RUN dotnet build --no-restore -c Release

ENTRYPOINT ["dotnet", "test", "--no-build", "--verbosity", "normal"]

