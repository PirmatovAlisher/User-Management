# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all projects
COPY ["UserManagement.Core/*.csproj", "UserManagement.Core/"]
COPY ["UserManagement.Infrastructure.MsSql/*.csproj", "UserManagement.Infrastructure.MsSql/"]
COPY ["UserManagement.Services/*.csproj", "UserManagement.Services/"]
COPY ["UserManagement/*.csproj", "UserManagement/"]

# Restore dependencies
RUN dotnet restore "UserManagement/UserManagement.csproj"

# Copy all source code
COPY . .

# Build application
WORKDIR "/src/UserManagement"
RUN dotnet build "UserManagement.csproj" -c Release -o /app/build

# Publish application
FROM build AS publish
RUN dotnet publish "UserManagement.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserManagement.dll"]
