# DockerDemoApp 🚀

A simple ASP.NET Core Web API application containerized using Docker and Docker Compose with PostgreSQL database integration.

---

# 📌 Project Overview

This project demonstrates:

- ASP.NET Core Web API development
- Docker containerization
- Docker Compose multi-container setup
- PostgreSQL database integration using Entity Framework Core
- Swagger API documentation
- Docker image build and execution
- Docker Hub integration

---

# 🛠 Technologies Used

| Technology | Purpose |
|------------|---------|
| ASP.NET Core 8 | Web API Framework |
| Docker | Containerization |
| Docker Compose | Multi-container orchestration |
| PostgreSQL | Database |
| Entity Framework Core | ORM |
| Swagger | API documentation/testing |

---

# 📂 Project Structure

```text
DockerDemoApp/
│
├── Controllers/
│   └── WeatherForecastController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Item.cs
│
├── Dockerfile
├── docker-compose.yml
├── Program.cs
├── appsettings.json
├── DockerDemoApp.csproj
└── README.md
```

---

# ⚙️ Prerequisites

Before running this project, install:

- Docker Desktop (20.10 or later)
- Docker Compose
- .NET 8 SDK
- Visual Studio 2022 / VS Code

---

# ✅ Step 1: Clone Repository

```bash
git clone <your-github-repo-url>
cd DockerDemoApp
```

---

# ✅ Step 2: Build Docker Image

```bash
docker build -t dockerdemoapp .
```

---

# ✅ Step 3: Run Docker Container

```bash
docker run -d -p 5000:80 dockerdemoapp
```

---

# 🌐 Access Swagger UI

Open browser:

http://localhost:5000/swagger

---

# ✅ Docker Commands Used

## List Running Containers

```bash
docker ps
```

## List All Containers

```bash
docker ps -a
```

## Stop Container

```bash
docker stop <container_id>
```

## Start Container

```bash
docker start <container_id>
```

## Remove Container

```bash
docker rm <container_id>
```

## View Logs

```bash
docker logs <container_id>
```

## Inspect Container

```bash
docker inspect <container_id>
```

---

# ✅ Docker Compose Setup

## Run Multi-Container Application

```bash
docker compose up -d
```

## Stop Multi-Container Application

```bash
docker compose down
```

---

# 🐘 PostgreSQL Database Configuration

Database service configured in `docker-compose.yml`:

```yaml
db:
  image: postgres:15
  environment:
    POSTGRES_USER: admin
    POSTGRES_PASSWORD: password
    POSTGRES_DB: demo
```

---

# 🧠 Entity Framework Core Packages

Installed packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

---

# 🔥 Database Connection String

Configured in `Program.cs`:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=db;Port=5432;Database=demo;Username=admin;Password=password"));
```

---

# 🐳 Dockerfile

```dockerfile
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "DockerDemoApp.dll"]
```

---

# 🧩 Docker Compose File

```yaml
services:
  web:
    build: .
    ports:
      - "5000:80"
    depends_on:
      - db

  db:
    image: postgres:15
    environment:
      POSTGRES_USER: admin
      POSTGRES_PASSWORD: password
      POSTGRES_DB: demo
    ports:
      - "5432:5432"
```

---

# 🚀 Docker Hub Commands

## Login

```bash
docker login
```

## Tag Image

```bash
docker tag dockerdemoapp <dockerhub-username>/dockerdemoapp
```

## Push Image

```bash
docker push <dockerhub-username>/dockerdemoapp
```

## Pull Image

```bash
docker pull <dockerhub-username>/dockerdemoapp
```

---

# 📖 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/weatherforecast` | Get weather forecast |
| POST | `/api/weatherforecast/add` | Add item to database |

---

#  Key Learnings

This project helped understand:

- Docker image creation
- Container lifecycle management
- Port mapping
- Multi-container orchestration
- Database container integration
- Entity Framework Core setup
- Swagger API testing

---

#  Assignment Requirements Covered

| Requirement | Status |
|------------|--------|
| Install Docker | ✅ |
| Verify Installation | ✅ |
| Create Web App | ✅ |
| Dockerfile | ✅ |
| Build Docker Image | ✅ |
| Run Container | ✅ |
| Docker Commands | ✅ |
| Inspect & Logs | ✅ |
| Docker Compose | ✅ |
| Multi-Container App | ✅ |
| Docker Registry | ✅ |
| Push/Pull Images | ✅ |
| README Documentation | ✅ |
| Database Integration (Bonus) | ✅ |

---

#  Author

**Gautam Singla**
