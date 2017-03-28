"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.CMS.Core\Localink.Modules.CMS.Core.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.CMS.EntityFramework\Localink.Modules.CMS.EntityFramework.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.CMS.Application\Localink.Modules.CMS.Application.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
"..\src\.nuget\NuGet.exe" "pack" "..\src\Localink.Modules.CMS.Web\Localink.Modules.CMS.Web.csproj" -Properties Configuration=Release -IncludeReferencedProjects -Symbols
pause