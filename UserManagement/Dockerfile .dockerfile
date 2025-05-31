# ---------- Stage 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. Copy solution & csproj(s)
COPY *.sln ./
COPY UserManagement/*.csproj ./UserManagement/
RUN dotnet restore

# 2. Copy everything else, then build & publish
COPY . ./
WORKDIR /app/UserManagement
RUN dotnet publish -c Release -o /app/publish

# ---------- Stage 2: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Expose port 8080 (Render expects this)
EXPOSE 8080

# Tell ASP.NET Core to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "UserManagement.dll"]
