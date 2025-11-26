# ProjOpro - Backend API

ASP.NET Core 9.0 Web API backend for ProjOpro.

## Prerequisites

- .NET 9.0 SDK
- PostgreSQL (optional, currently using InMemory database)

## Running the Backend

### Local Development

1. Navigate to the source directory:
```bash
cd src
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Run the API:
```bash
dotnet run --project Api/Api.csproj
```

The API will be available at:
- **HTTP**: `http://localhost:5056`
- **Swagger UI**: `http://localhost:5056/swagger`

### Running with Docker

Build and run the backend container:

```bash
cd src
docker build -t projopro-api .
docker run -p 5056:8080 projopro-api
```

Access:
- API: `http://localhost:5056`
- Swagger: `http://localhost:5056/swagger`

---

## Docker Compose (Full Stack)

Run both backend and frontend together using Docker Compose.

### Prerequisites

- Docker
- Docker Compose
- Both backend and frontend repositories cloned

### Setup

1. Clone both repositories on the same level:
```bash
# Example structure:
/parent-directory/
├── ProjOpro-Back/      # Backend repository
└── ProjOpro-Front/     # Frontend repository
```

2. Move `docker-compose.yml` from the backend repository to the parent directory (same level as both repos):
```bash
# From the parent directory:
mv ProjOpro-Back/docker-compose.yml ./docker-compose.yml
```

Your final structure should look like:
```
/parent-directory/
├── ProjOpro-Back/      # Backend repository
├── ProjOpro-Front/     # Frontend repository
└── docker-compose.yml  # Docker Compose file (moved here)
```

### Running

From the parent directory (where `docker-compose.yml` is located):
```bash
docker-compose up --build
```

### Access Points

- **Frontend**: `http://localhost`
- **Backend API**: `http://localhost:5056`
- **Swagger UI**: `http://localhost:5056/swagger`
