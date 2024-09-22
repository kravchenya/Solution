# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file and restore the dependencies (via `dotnet restore`)
COPY *.csproj ./
RUN dotnet restore

# Copy the entire project files
COPY . ./

# Build the application
RUN dotnet build --configuration Release --output /out

# Use the official runtime image to run the application
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

# Copy the build output to the runtime container
COPY --from=build /out .

# Set the entry point for the Docker container to run the app
ENTRYPOINT ["dotnet", "Solution.dll"]