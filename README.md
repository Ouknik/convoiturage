# Covoiturage Platform

Professional carpooling platform built with:

- `ASP.NET Core 8` REST API (`Serveur`)
- `SQL Server` + `Entity Framework Core`
- `Windows Forms` desktop client (`Client`)
- `JWT` authentication
- Clean architecture style (Controllers / DTOs / Services / Repositories / Middleware)

---

## Features

- User registration/login with JWT
- Roles: `Driver` / `Passenger`
- Trips management (create/list/delete)
- Reservations management (create/list/delete)
- Author profile system (`User` 1:1 `Author`)
- Modernized WinForms UX:
  - Login/Register tabs
  - Sidebar navigation
  - Dashboard / Trips / Reservations / Profile
  - Loading indicators, toasts, validation, empty states

---

## Project Structure

- `Serveur/Serveur/` → ASP.NET Core API
- `Client/Client/` → WinForms Desktop App (.NET Framework 4.7.2)

---

## Prerequisites

Install:

1. `Visual Studio Community 2026` (or compatible)
2. `.NET 8 SDK`
3. `SQL Server` (local or remote)
4. `dotnet-ef` tool

Install EF tool (once):

```powershell
dotnet tool install --global dotnet-ef
```

---

## Database Configuration

The API reads SQL Server settings from environment variables:

- `ACCESSPOS_DB_CONNECTION=sqlsrv`
- `ACCESSPOS_DB_HOST=127.0.0.1`
- `ACCESSPOS_DB_PORT=1433`
- `ACCESSPOS_DB_DATABASE=convoiturage`
- `ACCESSPOS_DB_USERNAME=access_user2`
- `ACCESSPOS_DB_PASSWORD=1234567890`

### PowerShell (current terminal session)

```powershell
$env:ACCESSPOS_DB_CONNECTION='sqlsrv'
$env:ACCESSPOS_DB_HOST='127.0.0.1'
$env:ACCESSPOS_DB_PORT='1433'
$env:ACCESSPOS_DB_DATABASE='convoiturage'
$env:ACCESSPOS_DB_USERNAME='access_user2'
$env:ACCESSPOS_DB_PASSWORD='1234567890'
```

---

## Run Migrations

From repository root:

```powershell
dotnet ef database update --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
```

If you need to create a new migration:

```powershell
dotnet ef migrations add <MigrationName> --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
```

---

## Run the API (`Serveur`)

```powershell
dotnet run --project "Serveur/Serveur/Serveur.csproj" --launch-profile "Serveur"
```

Default URLs:

- `https://localhost:58842`
- `http://localhost:58843` (redirects to HTTPS)

Swagger (development):

- `https://localhost:58842/swagger`

---

## Build/Run WinForms Client (`Client`)

### Build

```powershell
msbuild "Client/Client/Client.csproj" /t:Build /p:Configuration=Debug
```

### Run

```powershell
Start-Process "Client/Client/bin/Debug/Client.exe"
```

In login screen, use API URL:

- `https://localhost:58842`

---

## Quick API Endpoints

### Auth

- `POST /api/auth/register`
- `POST /api/auth/login`

### Trips

- `GET /api/trips`
- `GET /api/trips/{id}`
- `POST /api/trips` (Driver)
- `DELETE /api/trips/{id}`

### Reservations

- `GET /api/reservations`
- `POST /api/reservations`
- `DELETE /api/reservations/{id}`

### Authors (Profile)

- `GET /api/authors/{userId}`
- `POST /api/authors`
- `PUT /api/authors/{id}`

---

## Recommended GitHub Sharing Notes

When publishing to GitHub:

1. Do **not** commit real secrets/passwords.
2. Prefer environment variables or secret managers.
3. Optionally add `.env.example` with placeholders.

---

## Troubleshooting

- If build says executable is locked (`.exe in use`), close running app then rebuild.
- If HTTPS call fails, ensure API is running and certificate trust is configured.
- If solution-level `.slnx` has path issues, use direct `*.csproj` commands above.

---

## Author

Created for learning and collaboration. Feel free to fork and improve.
