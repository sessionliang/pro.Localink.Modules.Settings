namespace Localink.Platform.Web.MultiTenancy
{
    public interface ITenancyNameFinder
    {
        string GetCurrentTenancyNameOrNull();
    }
}