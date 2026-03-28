@echo off
setlocal

echo ===============================================
echo Starting Covoiturage Application
echo This project was created by:
echo - Abdellah Ouknik
echo - Fatima Zahra BOULAOUDEN
echo - Mohamed ABDELMOUMEN
echo - Mehdi MARZOUQ
echo ===============================================

set "ROOT=%~dp0"
cd /d "%ROOT%"

echo [1/2] Starting API server...
start "Serveur API" cmd /k dotnet run --project "Serveur\Serveur\Serveur.csproj" --launch-profile "Serveur"

timeout /t 4 /nobreak >nul

echo [2/2] Starting WinForms client...
if exist "Client\Client\bin\Debug\Client.exe" (
  start "Client App" "Client\Client\bin\Debug\Client.exe"
  echo Client started.
) else (
  echo Client executable not found: Client\Client\bin\Debug\Client.exe
  echo Build client first: msbuild "Client\Client\Client.csproj" /t:Build /p:Configuration=Debug
)

echo Done.
endlocal
