
@echo off
title Foxoft - All Users Process Killer
setlocal

:: Administrator icazəsini yoxla
net session >nul 2>&1
if %errorlevel% neq 0 (
    powershell -NoProfile -Command "Start-Process '%~f0' -Verb RunAs"
    exit /b
)

cls
echo ==========================================
echo       FOXOFT - BUTUN USER-LER
echo ==========================================
echo.
echo Bu emeliyyat butun user sessiyalarinda
echo Foxoft.exe proqramini baglayacaq.
echo.
echo Diqqet: Saxlanilmamis melumatlar itebilir!
echo.

choice /C YN /N /M "Emirsinizmi? (Y/N): "

if errorlevel 2 (
    echo.
    echo Emeliyyat legv edildi.
    pause
    exit /b
)

echo.
echo Foxoft.exe baglanir...
echo.

taskkill /F /T /IM Foxoft.exe

echo.
echo Emeliyyat tamamlandi.
pause
