$ErrorActionPreference = 'Stop'

Write-Host "==============================================="
Write-Host "Starting Covoiturage Application"
Write-Host "This project was created by:"
Write-Host "- Abdellah Ouknik"
Write-Host "- Fatima Zahra BOULAOUDEN"
Write-Host "- Mohamed ABDELMOUMEN"
Write-Host "- Mehdi MARZOUQ"
Write-Host "==============================================="

$root = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $root

Write-Host "[1/2] Starting API server..."
Start-Process powershell -ArgumentList '-NoExit', '-Command', 'dotnet run --project "Serveur/Serveur/Serveur.csproj" --launch-profile "Serveur"'

Start-Sleep -Seconds 4

Write-Host "[2/2] Starting WinForms client..."
$clientExe = Join-Path $root 'Client/Client/bin/Debug/Client.exe'
if (Test-Path $clientExe) {
    Start-Process $clientExe
    Write-Host 'Client started.'
} else {
    Write-Host 'Client executable not found: Client/Client/bin/Debug/Client.exe'
    Write-Host 'Build client first: msbuild "Client/Client/Client.csproj" /t:Build /p:Configuration=Debug'
}
