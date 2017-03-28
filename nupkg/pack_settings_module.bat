"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.Settings.Core\Localink.Modules.Settings.Core.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.Settings.EntityFramework\Localink.Modules.Settings.EntityFramework.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.Settings.Application\Localink.Modules.Settings.Application.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.Settings.Web\Localink.Modules.Settings.Web.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
pause