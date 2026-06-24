@echo off
setlocal

echo ================================
echo  Design Patterns  -  Start
echo ================================

REM --- Check .NET SDK ---
where dotnet >nul 2>&1
if errorlevel 1 (
    echo [ERROR] dotnet not found. Install .NET 10 SDK from https://dotnet.microsoft.com/download
    pause & exit /b 1
)

for /f "tokens=*" %%v in ('dotnet --version 2^>nul') do set DOTNET_VER=%%v
echo .NET SDK: %DOTNET_VER%

REM --- Restore ---
echo.
echo [1/3] Restoring dependencies...
dotnet restore DesignPatterns\DesignPatterns.csproj --verbosity quiet
if errorlevel 1 ( echo [ERROR] Restore failed & pause & exit /b 1 )

REM --- Build ---
echo [2/3] Building...
dotnet build DesignPatterns\DesignPatterns.csproj --no-restore --verbosity quiet
if errorlevel 1 ( echo [ERROR] Build failed & pause & exit /b 1 )

REM --- Run ---
echo [3/3] Starting...
echo.
dotnet run --project DesignPatterns\DesignPatterns.csproj --no-build

endlocal
