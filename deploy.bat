@echo on

rem %1 = D:\#Projects\KSP_dev\KerbalAlarmClock_From_the_beginning\KerbalAlarmClock\bin\Debug\
rem %2 = KerbalAlarmClock.dll
rem %3 = KerbalAlarmClock

rem KSPDIR is the destination game folder (considered to be preconfigured)
rem MODNAME is the name of the current mod
rem GAMEDIR is the name of the mod folder (usually the mod name)
rem GAMEDATA is the name of the local GameData
rem VERSIONFILE is the name of the version file, usually the same as GAMEDATA

set MODNAME=%3
set GAMEDIR=TriggerTech\%MODNAME%
set GAMEDATA=GameData
set VERSIONFILE=%MODNAME%.version

if not exist "%GAMEDATA%\%GAMEDIR%\Plugins" (mkdir "%GAMEDATA%\%GAMEDIR%\Plugins")
copy /y "%1%2" "%GAMEDATA%\%GAMEDIR%\Plugins"
copy /y %VERSIONFILE% %GAMEDATA%\%GAMEDIR%

if not exist "%KSPDIR%\GameData\%GAMEDIR%" (mkdir "%KSPDIR%\GameData\%GAMEDIR%")
rem xcopy /y /s /I %GAMEDATA%\%GAMEDIR% "%KSPDIR%\GameData\%GAMEDIR%"
robocopy %GAMEDATA%\%GAMEDIR% "%KSPDIR%\GameData\%GAMEDIR%" /mir /xf settings.cfg

pause
