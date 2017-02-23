@ECHO OFF

REM NET 4.0 Folder
set DOTNETFX2=%SystemRoot%\Microsoft.NET\Framework64\v4.0.30319
set PATH=%PATH%;%DOTNETFX2%

InstallUtil /i "%~dp0Service.exe"

net start Service

pause