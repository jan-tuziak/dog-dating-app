# Dog Dating App (PawMatch)

This repository contains the backend and frontend for the PawMatch application (Dog Dating App).

## Structure

- `backend/` — ASP.NET Core Web API project (`PawMatch.Api`) 
- `frontend/` — Angular application

## Getting Started

### Backend

```bash
cd backend/PawMatch.Api
dotnet restore
dotnet build
dotnet run
```

### Frontend

```bash
cd frontend
npm ci
npm start
```

### Database & Docker

The backend uses SQL Server with EF Core code-first migrations. For local development you can use LocalDB or the Docker service defined below.

---

### Continuous Integration

A GitHub Actions workflow (`.github/workflows/ci.yml`) runs on every push and pull request against `main`. It builds the backend, runs .NET tests, installs frontend packages and executes any Angular unit tests. The pipeline acts as a quality gate: **PRs targeting `main` must have all jobs succeed before merging**. Configure branch protection rules in the repository settings to enforce this.

### Branching Model

- `main` holds production-ready code.
- `develop` is the integration branch for ongoing work. Create feature branches from `develop` and open PRs back into it. When `develop` is stable, open a PR against `main`.


1. **Run with Docker**

   ```bash
   docker-compose up --build
   ```

   - API will be available at `http://localhost:5000`
   - SQL Server listens on `1433` (SA password is `Your_password123` by default)

2. **Apply migrations**

   ```bash
   # either from host with LocalDB
   dotnet ef database update --project backend/PawMatch.Api

   # or inside the api container:
   docker-compose exec api dotnet ef database update
   ```

3. **Override connection string**

   Set `ConnectionStrings__DefaultConnection` environment variable or edit `appsettings.*.json`.

Refer to `AGENTS.md` for development conventions and guidelines.
