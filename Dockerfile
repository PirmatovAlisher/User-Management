############################################
# Stage 1: Build your .NET 8 MVC solution #
############################################
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1) Copy the solution file into /app
#    (uses a wildcard if your .sln has a different name—make sure there's only one .sln at root)
COPY *.sln ./

# 2) Copy each project’s .csproj so that 'dotnet restore' can cache correctly
COPY UserManagement.Core/*.csproj ./UserManagement.Core/
COPY UserManagement.Infrastructure.MsSql/*.csproj ./UserManagement.Infrastructure.MsSql/
COPY UserManagement.Services/*.csproj ./UserManagement.Services/
COPY UserManagement/*.csproj ./UserManagement/

# 3) Restore NuGet packages for the entire solution
RUN dotnet restore

# 4) Copy the rest of your code (all folders and files) into the container
COPY . ./

# 5) Publish the MVC project to a folder called /app/publish
WORKDIR /app/UserManagement
RUN dotnet publish -c Release -o /app/publish



#######################################
# Stage 2: Create the runtime image    #
#######################################
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 6) Copy the published output from the build stage
COPY --from=build /app/publish ./

# 7) Expose port 8080 so Render can route HTTP traffic
EXPOSE 8080

# 8) Tell Kestrel to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# 9) Launch your MVC app
ENTRYPOINT ["dotnet", "UserManagement.dll"]
