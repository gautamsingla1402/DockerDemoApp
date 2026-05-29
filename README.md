# DockerDemoApp – Advanced Docker Assignment

# Project Overview

DockerDemoApp is a containerized ASP.NET Core Web API application integrated with PostgreSQL using Docker and Docker Compose.

This project demonstrates advanced Docker concepts including:

- Dockerfile optimization
- Multi-stage builds
- Custom Docker networking
- Persistent storage using Docker volumes
- Bind mounts
- Backup and restore of Docker volumes
- Secret management
- Vulnerability scanning
- Docker security hardening
- Docker Bench Security auditing
- CI/CD pipeline integration

---

# Technologies Used

- ASP.NET Core 8
- PostgreSQL 15
- Docker
- Docker Compose
- Entity Framework Core
- GitHub Actions
- Trivy
- Docker Bench Security

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
- Multi-stage builds
- Smaller runtime image
- Docker layer caching
- Non-root user

## Networking
- Custom Docker network
- Container-to-container communication
- Network inspection

## Storage
- Named Docker volumes
- Bind mounts
- Persistent PostgreSQL storage

## Security
- Least privilege containers
- Docker secrets
- Vulnerability scanning using Trivy
- Docker Bench Security audit

## Reliability
- Restart policies
- Health checks
- Resource limits

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
├── .github/workflows/
├── Dockerfile
├── docker-compose.yml
├── README.md
└── Program.cs
```

---

# Setup Instructions

## Prerequisites

- Docker 20.10+
- Docker Compose
- Git
- WSL (optional for Linux commands)

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

# Configure Secrets

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
- Build automation
- Docker image creation
- Docker Hub push

Location:

```text
.github/workflows/docker-cicd.yml
```

---

# Assignment Requirement Mapping

| Requirement | Status |
|---|---|
| Optimize Dockerfile | Completed |
| Multi-stage builds | Completed |
| Custom Docker network | Completed |
| Inspect/manage network | Completed |
| Docker volumes | Completed |
| Named volumes | Completed |
| Bind mounts | Completed |
| Backup/restore volumes | Completed |
| Secret management | Completed |
| Vulnerability scanning | Completed |
| Least privilege | Completed |
| Docker Bench Security | Completed |

---

# Learning Outcomes

This project helped in understanding:

- Docker containerization
- Enterprise Docker practices
- Multi-container architecture
- Networking and persistence
- Docker security
- DevSecOps concepts
- Production-ready container deployment

---

# Author

Gautam Singla