@if "%1"=="" goto blank
@if NOT "%1"=="" goto param

:blank
MSBuild build.proj /t:Migrate /p:SchemaVersion=-1
@goto end

:param
MSBuild build.proj /t:Migrate /p:SchemaVersion=%1

:end