############################################
# Stage 1: Build your .NET 8 MVC project  #
############################################
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1) Copy everything (all folders and files) into /app so that
#    project references between UserManagement and the class libs are intact.
COPY . .

# 2) Switch into the MVC project folder
WORKDIR /app/UserManagement

# 3) Restore NuGet packages for UserManagement.csproj (it will pull in the class libs via ProjectReference)
RUN dotnet restore

# 4) Publish the MVC app into /app/publish
RUN dotnet publish -c Release -o /app/publish



####################################
# Stage 2: Create the runtime image #
####################################
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 5) Copy the published output from the build stage
COPY --from=build /app/publish ./

# 6) Expose port 8080 (Render expects the container to listen here)
EXPOSE 8080

# 7) Tell Kestrel to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# 8) Launch your MVC app
ENTRYPOINT ["dotnet", "UserManagement.dll"]
