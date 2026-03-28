#!/usr/bin/env bash
set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
cd "$SCRIPT_DIR"

echo "==============================================="
echo "Starting Covoiturage Application"
echo "This project was created by:"
echo "- Abdellah Ouknik"
echo "- Fatima Zahra BOULAOUDEN"
echo "- Mohamed ABDELMOUMEN"
echo "- Mehdi MARZOUQ"
echo "==============================================="

SERVER_PROJECT="Serveur/Serveur/Serveur.csproj"
CLIENT_EXE="Client/Client/bin/Debug/Client.exe"

echo "[1/2] Starting API server..."
dotnet run --project "$SERVER_PROJECT" --launch-profile "Serveur" &
SERVER_PID=$!

cleanup() {
  echo "Stopping API server..."
  kill "$SERVER_PID" >/dev/null 2>&1 || true
}
trap cleanup EXIT INT TERM

sleep 4

echo "[2/2] Starting WinForms client..."
if [ -f "$CLIENT_EXE" ]; then
  if command -v powershell.exe >/dev/null 2>&1; then
    powershell.exe -NoProfile -Command "Start-Process -FilePath '$SCRIPT_DIR/$CLIENT_EXE'" >/dev/null 2>&1
    echo "Client started."
  else
    echo "powershell.exe not found. Start client manually: $CLIENT_EXE"
  fi
else
  echo "Client executable not found: $CLIENT_EXE"
  echo "Build client first, then run this script again."
fi

echo "Application is running. Press Ctrl+C to stop API server."
wait "$SERVER_PID"
