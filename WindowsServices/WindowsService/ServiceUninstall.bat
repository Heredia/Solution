@ECHO OFF

REM NET 4.0 Folder
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

InstallUtil /u "%~dp0Service.exe"

taskkill /fi "Services eq Service" /F

pause