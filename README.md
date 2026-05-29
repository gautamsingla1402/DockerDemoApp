# DockerDemoApp – Advanced Docker Assignment

## Project Overview

DockerDemoApp is a containerized ASP.NET Core Web API application integrated with PostgreSQL using Docker and Docker Compose.

This project demonstrates advanced Docker concepts including:

* Dockerfile optimization
* Multi-stage builds
* Custom Docker networking
* Persistent storage using Docker volumes
* Bind mounts
* Backup and restore of Docker volumes
* Secret management
* Vulnerability scanning
* Docker security hardening
* Docker Bench Security auditing
* CI/CD pipeline integration
* PostgreSQL database integration

---

# Quick Start

```bash
git clone https://github.com/gautamsingla1402/DockerDemoApp.git

cd DockerDemoApp

docker network create app-network

docker compose up -d --build
```

Open:

```text
http://localhost:5000/swagger
```

---

# Technologies Used

* ASP.NET Core 8
* PostgreSQL 15
* Docker
* Docker Compose
* Entity Framework Core
* GitHub Actions
* Trivy
* Docker Bench Security

---

# Project Architecture

```text
                    app-network
┌────────────────────────────────────────┐
│                                        │
│   web-app (.NET API Container)         │
│      - Multi-stage Docker build        │
│      - Non-root user                   │
│      - Health checks                   │
│      - Bind mount logs                 │
│      - Resource limits                 │
│                                        │
│               ↕                        │
│                                        │
│   postgres-db (PostgreSQL Container)   │
│      - Named volume persistence        │
│      - Docker secrets                  │
│                                        │
└────────────────────────────────────────┘
```

---

# Features Implemented

## Dockerfile Optimization

* Multi-stage builds
* Smaller runtime image
* Docker layer caching
* Non-root user execution

## Networking

* Custom Docker network
* Container-to-container communication
* Network inspection

## Storage

* Named Docker volumes
* Bind mounts
* Persistent PostgreSQL storage

## Security

* Non-root containers
* Docker secrets
* Vulnerability scanning using Trivy
* Docker Bench Security audit
* Least privilege principle

## Reliability

* Restart policies
* Health checks
* Resource limits

---

# Security Features

Implemented the following security best practices:

* Non-root container execution
* Docker secrets
* Least privilege principle
* Docker Bench Security auditing
* Trivy vulnerability scanning
* Container health checks
* Resource limits
* Restart policies
* No-new-privileges security option

---

# Folder Structure

```text
DockerDemoApp/
│
├── Controllers/
├── Data/
├── Models/
├── backups/
├── logs/
├── screenshots/
├── secrets/
├── .github/
│   └── workflows/
│       └── docker-cicd.yml
│
├── Dockerfile
├── docker-compose.yml
├── README.md
├── .env.example
├── .gitignore
├── Program.cs
└── DockerDemoApp.csproj
```

---

# Setup Instructions

## Prerequisites

* Docker 20.10+
* Docker Compose
* Git
* WSL (optional)

---

# Clone Repository

```bash
git clone https://github.com/gautamsingla1402/DockerDemoApp.git

cd DockerDemoApp
```

---

# Create Docker Network

```bash
docker network create app-network
```

---

# Configure Docker Secrets

Create:

```text
secrets/db_password.txt
```

Add:

```text
StrongPassword123
```

---

# Configure Environment Variables

Create:

```text
.env
```

Add:

```env
POSTGRES_USER=admin
POSTGRES_DB=demo
```

---

# Run Application

```bash
docker compose up -d --build
```

---

# Verify Running Containers

```bash
docker ps
```

---

# Access Swagger

```text
http://localhost:5000/swagger
```

---

# Docker Commands Used

## View Containers

```bash
docker ps
```

## View Logs

```bash
docker logs web-app
```

## Inspect Network

```bash
docker network inspect app-network
```

## View Volumes

```bash
docker volume ls
```

---

# Backup Docker Volume

```bash
docker run --rm \
-v postgres-data:/volume \
-v $(pwd):/backup \
ubuntu \
tar czf /backup/postgres-backup.tar.gz -C /volume .
```

---

# Restore Docker Volume

```bash
docker run --rm \
-v postgres-data:/volume \
-v $(pwd):/backup \
ubuntu \
bash -c "cd /volume && tar xzf /backup/postgres-backup.tar.gz"
```

---

# Docker Hub Integration

## Login

```bash
docker login
```

## Build Image

```bash
docker build -t <dockerhub-username>/dockerdemoapp:latest .
```

## Push Image

```bash
docker push <dockerhub-username>/dockerdemoapp:latest
```

## Pull Image

```bash
docker pull <dockerhub-username>/dockerdemoapp:latest
```

## Run Pulled Image

```bash
docker run -d -p 5000:8080 <dockerhub-username>/dockerdemoapp:latest
```

---

# Vulnerability Scanning

## Trivy Scan

```bash
trivy image web-app
```

---

# Docker Bench Security

```bash
docker run --rm --net host --pid host --userns host --cap-add audit_control \
-v /var/lib:/var/lib \
-v /var/run/docker.sock:/var/run/docker.sock \
-v /usr/lib/systemd:/usr/lib/systemd \
-v /etc:/etc \
docker/docker-bench-security
```

---

# CI/CD Pipeline

GitHub Actions workflow included for:

* Build automation
* Application validation
* Docker image creation
* Docker Hub push
* Continuous Integration

Location:

```text
.github/workflows/docker-cicd.yml
```

---

# Screenshots

The screenshots folder contains evidence of:

* Docker containers running
* Swagger UI
* Docker network inspection
* Docker volume management
* Backup creation
* Trivy vulnerability scan
* Docker Bench Security audit
* GitHub Actions CI/CD execution

---

# Bonus Requirement

Implemented PostgreSQL database integration using Entity Framework Core.

Features:

* PostgreSQL container
* AppDbContext configuration
* Database persistence using Docker volumes
* Container-to-container communication
* Database-backed API architecture

---

# Assignment Requirement Mapping

| Requirement                  | Status      |
| ---------------------------- | ----------- |
| Optimize Dockerfile          | ✅ Completed |
| Multi-stage builds           | ✅ Completed |
| Custom Docker network        | ✅ Completed |
| Inspect/manage network       | ✅ Completed |
| Docker volumes               | ✅ Completed |
| Named volumes                | ✅ Completed |
| Bind mounts                  | ✅ Completed |
| Backup/restore volumes       | ✅ Completed |
| Secret management            | ✅ Completed |
| Vulnerability scanning       | ✅ Completed |
| Least privilege              | ✅ Completed |
| Docker Bench Security        | ✅ Completed |
| Docker Hub Registry          | ✅ Completed |
| Push Docker Images           | ✅ Completed |
| Pull Docker Images           | ✅ Completed |
| CI/CD Pipeline               | ✅ Completed |
| Security Hardening           | ✅ Completed |
| Database Integration (Bonus) | ✅ Completed |

---

# Learning Outcomes

This project helped in understanding:

* Docker containerization
* Enterprise Docker practices
* Multi-container architecture
* Docker networking
* Persistent storage
* DevSecOps concepts
* Container security
* Vulnerability management
* CI/CD integration
* Production-ready container deployment

---

# Final Submission Checklist

* [x] Dockerfile optimized
* [x] Multi-stage builds implemented
* [x] Custom Docker network configured
* [x] Docker volumes configured
* [x] Bind mounts configured
* [x] Backup and restore completed
* [x] Secret management implemented
* [x] Vulnerability scanning completed
* [x] Docker Bench Security executed
* [x] CI/CD pipeline created
* [x] Docker Hub integration completed
* [x] PostgreSQL integration completed
* [x] Documentation completed

---

# Author

**Gautam Singla**
Staff Engineer | .NET | Docker | Microservices | DevOps Enthusiast
