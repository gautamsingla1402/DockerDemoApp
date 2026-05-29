# =========================
# BUILD STAGE
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /src

# Copy csproj first for Docker layer caching
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy remaining source code
COPY . .

# Publish application
RUN dotnet publish -c Release -o /app/publish

# =========================
# RUNTIME STAGE
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set working directory
WORKDIR /app

# Install curl for health checks
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

# Create non-root user
RUN useradd -m appuser

# Copy published output from build stage
COPY --from=build /app/publish .

# Create logs directory
RUN mkdir -p /app/logs

# Change ownership to non-root user
RUN chown -R appuser:appuser /app

# Switch to non-root user
USER appuser

# Configure ASP.NET Core URL
ENV ASPNETCORE_URLS=http://+:8080

# Expose application port
EXPOSE 8080

# Start application
ENTRYPOINT ["dotnet", "DockerDemoApp.dll"]