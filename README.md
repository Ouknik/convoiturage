# Covoiturage Platform

Plateforme de covoiturage (API + client desktop) avec architecture propre et UX WinForms moderne.

- Backend: `ASP.NET Core 8` (`Serveur`)
- Base de données: `SQL Server` + `Entity Framework Core`
- Client desktop: `WinForms .NET Framework 4.7.2` (`Client`)
- Auth: `JWT` + rôles (`Admin`, `Driver`, `Passenger`)

---

## 1) Fonctionnalités principales

- Authentification / inscription (`JWT`)
- Gestion des trajets (création, recherche, suppression)
- Réservations avec paiement (`Cash` / `Card`) et popup de paiement
- Profil utilisateur + cartes enregistrées (mode démo)
- Admin panel (users / trips / reservations / payments)
- Système de reviews drivers:
  - note 1..5
  - commentaire
  - profil driver avec moyenne et liste des avis
- UX WinForms SaaS:
  - sidebar + pages Dashboard/Trips/Reservations/Profile
  - cards modernes, toasts, loading, empty states

---

## 2) Arborescence

- `Serveur/Serveur/` : API ASP.NET Core
- `Client/Client/` : WinForms client

---

## 3) Prérequis

1. `Visual Studio Community 2026` (ou équivalent)
2. `.NET 8 SDK`
3. `SQL Server`
4. `dotnet-ef`

Installer EF CLI (une seule fois) :

```powershell
dotnet tool install --global dotnet-ef
```

---

## 4) Variables d'environnement DB

Le backend lit la connexion SQL Server depuis :

- `ACCESSPOS_DB_CONNECTION=sqlsrv`
- `ACCESSPOS_DB_HOST=127.0.0.1`
- `ACCESSPOS_DB_PORT=1433`
- `ACCESSPOS_DB_DATABASE=convoiturage`
- `ACCESSPOS_DB_USERNAME=access_user2`
- `ACCESSPOS_DB_PASSWORD=1234567890`

PowerShell (session actuelle) :

```powershell
$env:ACCESSPOS_DB_CONNECTION='sqlsrv'
$env:ACCESSPOS_DB_HOST='127.0.0.1'
$env:ACCESSPOS_DB_PORT='1433'
$env:ACCESSPOS_DB_DATABASE='convoiturage'
$env:ACCESSPOS_DB_USERNAME='access_user2'
$env:ACCESSPOS_DB_PASSWORD='1234567890'
```

---

## 5) Super Admin (optionnel)

Vous pouvez personnaliser le compte admin seedé au démarrage API :

- `SUPERADMIN_EMAIL` (default: `admin@convoiturage.local`)
- `SUPERADMIN_PASSWORD` (default: `Admin@123456`)
- `SUPERADMIN_NAME` (default: `Super Admin`)

Exemple :

```powershell
$env:SUPERADMIN_EMAIL='admin@convoiturage.local'
$env:SUPERADMIN_PASSWORD='Admin@123456'
$env:SUPERADMIN_NAME='Super Admin'
```

---

## 6) Migration / DB reset

### Appliquer toutes les migrations

```powershell
dotnet ef database update --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
```

### Créer une nouvelle migration

```powershell
dotnet ef migrations add <MigrationName> --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
```

### Nettoyer complètement la DB puis réappliquer

```powershell
dotnet ef database drop --force --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
dotnet ef database update --configuration Release --project "Serveur/Serveur/Serveur.csproj" --startup-project "Serveur/Serveur/Serveur.csproj"
```

---

## 7) Seed de données de démo

Le seeding s'exécute automatiquement au démarrage API (`ApplicationDbSeeder`).

Il crée (si absents) :

- 1 admin
- 2 drivers
- 3 passengers
- profils `Author`
- trips (`completed`, `ongoing`, `upcoming`)
- reservations
- payments (`Cash` et `Card`)
- reviews drivers

Comptes démo utiles :

- `driver1@demo.local` / `123456`
- `driver2@demo.local` / `123456`
- `passenger1@demo.local` / `123456`
- `passenger2@demo.local` / `123456`
- `passenger3@demo.local` / `123456`
- `admin@convoiturage.local` / `Admin@123456` (ou variables `SUPERADMIN_*`)

> Le seed est idempotent : pas de duplication à chaque redémarrage.

---

## 8) Lancer l'API

```powershell
dotnet run --project "Serveur/Serveur/Serveur.csproj" --launch-profile "Serveur"
```

URLs par défaut :

- `https://localhost:58842`
- `http://localhost:58843` (redirect HTTPS)

Swagger (dev) :

- `https://localhost:58842/swagger`

---

## 9) Build / run Client WinForms

### Build

```powershell
msbuild "Client/Client/Client.csproj" /t:Build /p:Configuration=Debug
```

### Run

```powershell
Start-Process "Client/Client/bin/Debug/Client.exe"
```

API URL dans l'écran Login :

- `https://localhost:58842`

---

## 10) Endpoints rapides

### Auth

- `POST /api/auth/register`
- `POST /api/auth/login`

### Trips

- `GET /api/trips`
- `GET /api/trips/{id}`
- `POST /api/trips` (`Driver`)
- `DELETE /api/trips/{id}` (`Driver`)
- `GET /api/trips/{id}/reservations` (`Driver`,`Admin`)

### Reservations

- `GET /api/reservations` (`Passenger`)
- `POST /api/reservations` (`Passenger`)
- `DELETE /api/reservations/{id}` (`Passenger`)

### Driver Reviews

- `POST /api/reviews` (`Passenger`)
- `GET /api/reviews/driver/{driverId}`
- `GET /api/drivers/{id}/profile`

### Admin

- `GET /api/admin/users`
- `GET /api/admin/trips`
- `GET /api/admin/reservations`
- `GET /api/admin/payments`
- `DELETE /api/admin/users/{id}`
- `DELETE /api/admin/trips/{id}`
- `DELETE /api/admin/reservations/{id}`
- `DELETE /api/admin/payments/{id}`

### Profile (Author)

- `GET /api/authors/{userId}`
- `POST /api/authors`
- `PUT /api/authors/{id}`

---

## 11) Troubleshooting

- Si `Client.exe` est verrouillé : fermer l'app puis rebuild.
- Si HTTPS échoue : vérifier que l'API tourne et certificat local ok.
- Si `slnx` pose problème : utiliser les commandes `*.csproj` directes.
- Si la DB est incohérente : faire `database drop` puis `database update`.

---

## 12) Notes sécurité (important)

Le projet contient un mode démo (seed + stockage carte pour test). 
Ne jamais utiliser ces pratiques en production sans chiffrement/tokenization/PCI.

Ne committez pas de vrais secrets.
