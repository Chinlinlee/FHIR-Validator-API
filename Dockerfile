# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY FHIRValidatorAPI/*.csproj ./FHIRValidatorAPI/
RUN dotnet restore

# copy everything else and build app
COPY FHIRValidatorAPI/. ./FHIRValidatorAPI/
WORKDIR /source/FHIRValidatorAPI
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "FHIRValidatorAPI.dll"]