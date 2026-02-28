# AGENTS.md — Dog Dating App (v1)

This repository contains:

- Backend: ASP.NET Core Web API (.NET)
- Frontend: Angular
- Goal: maximize AI-driven implementation while preventing architectural drift and instability.

If you are an AI coding agent working in this repository, treat this file as the primary operational contract.

---

# 1. Non-Negotiables

## Do NOT change without proposing first

The following require an explicit proposal in the PR description before modification:

- Project structure (folder layout, solution structure)
- API base route conventions
- Authentication approach
- Database provider and migration strategy
- Angular workspace configuration

If proposing a change, include:

- Why the change is necessary
- Alternatives considered
- Migration steps
- Risks and impact

## Small PR rule

- Target under 400 changed lines unless scaffolding.
- Each PR must include tests or an explicit justification why tests are not applicable.

## Determinism rule

Avoid undocumented generation steps or hidden tooling.

If setup steps are required, they must be documented in:
- README.md
- docs/engineering/environments.md

---

# 2. Definition of Done (DoD)

A task is complete only if:

1. Backend builds successfully.
2. Frontend builds successfully.
3. Tests pass.
4. Acceptance criteria are fully satisfied.
5. No secrets are committed.
6. PR description includes:
   - What changed
   - How to test locally
   - Screenshots for UI changes (if applicable)

---

# 3. Standard Commands

Always use repository-defined scripts if available.

## Backend (.NET)

Default commands:

dotnet restore  
dotnet build  
dotnet test  
dotnet run --project ./backend/<BackendProjectName>

Do not assume global tools beyond .NET SDK.

## Frontend (Angular)

cd frontend  
npm ci  
npm run build  
npm test  
npm start  

If Angular CLI is used, prefer npm scripts over global ng commands.

---

# 4. Architecture Constraints

## Backend Layering Rules

- Controllers must remain thin.
- Business logic belongs in domain/service layer.
- Data access must be isolated (repository or data abstraction).
- Do NOT expose EF Core entities directly in API responses.
- Use DTOs for API contracts.

## API Style Rules

- JSON REST API.
- Consistent error response format.
- Input validation at boundary.
- Pagination required for list endpoints.
- No silent failures.

## Frontend Rules (Important: AI-heavy area)

- Prefer standalone components unless project structure dictates otherwise.
- Keep components small and focused.
- API calls belong in services.
- Always define TypeScript interfaces for API responses.
- Avoid scattered side effects.
- Keep UI state predictable and localized.

---

# 5. Feature Implementation Workflow

For every feature:

1. Restate requirements clearly.
2. List assumptions.
3. Identify missing information (ask only if blocking).
4. Provide an implementation plan:
   - Files to create or modify
   - Endpoints involved
   - Data model changes
   - Tests required
5. Implement backend first (API contract + tests).
6. Implement frontend second (services + UI).
7. Run tests.
8. Provide structured PR summary.

Do not skip planning.

---

# 6. Contract-First Development

When adding or modifying endpoints:

1. Define route.
2. Define request DTO.
3. Define response DTO.
4. Define validation rules.
5. Define error cases.
6. Add backend tests.
7. Align frontend models with DTOs.

If Swagger/OpenAPI is used, keep it accurate.

---

# 7. Testing Policy (Minimum Required)

## Backend

- Unit tests for domain/services.
- Integration tests for controllers:
  - Happy path
  - At least one failure case.

## Frontend

Minimum:
- Component renders.
- Service mocked for critical flows.

If frontend test harness does not exist:
- Document manual test steps in PR.

If skipping tests:
- Explicitly explain why.
- State what would be added later.

---

# 8. Secrets and Safety

- Never commit credentials.
- Never commit connection strings with passwords.
- Use environment variables or user-secrets for development.
- appsettings.Development.json must not contain real secrets.

---

# 9. Performance and Security Defaults

- Validate all inputs.
- Avoid N+1 queries.
- Prefer projection to DTOs instead of loading full entities.
- Rate-limit abuse-prone endpoints (login, search, messaging).
- Do not log sensitive data.
- Use structured logging.

---

# 10. Domain Notes — PawMatch (Working Name)

Initial conceptual entities (do not implement without spec approval):

- Dog (profile, photos, breed, age, size, temperament)
- Owner (account)
- Like / Pass
- Match (mutual like)
- Chat (post-MVP)

## MVP Scope

- Create dog profile
- Browse dogs
- Like or pass
- View matches

Anything beyond this requires explicit specification.

---

# 11. Debugging Protocol

If something fails:

Provide:

1. Exact error message.
2. Command used.
3. OS and versions:
   - dotnet --version
   - node --version
   - ng version (if applicable)
4. Files changed.

Do not guess. Reproduce and report precisely.

---

# 12. Required Documentation (Create Next)

If missing, create:

docs/architecture/overview.md  
docs/product/spec-0001-mvp.md  
docs/engineering/environments.md  
docs/engineering/testing-strategy.md  
docs/architecture/decisions/adr-0001-template.md  

Keep architecture overview under 2 pages.

---

# 13. Core Principle

The human defines requirements, constraints, and acceptance criteria.  
The AI implements within those constraints.  
Tests and structure enforce stability.