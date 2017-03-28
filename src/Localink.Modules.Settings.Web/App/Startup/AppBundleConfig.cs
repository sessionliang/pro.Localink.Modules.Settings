using System.Web.Optimization;

namespace Localink.Modules.Settings.Web.App.Startup
{
    public static class AppBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //APPLICATION

            var cssBundle = bundles.GetBundleFor("~/Embedded/App/css");

            bundles.Add(
                cssBundle != null
                ? cssBundle.Include("~/App/settings.css")
                : new StyleBundle("~/Embedded/App/css")
                    .Include("~/App/settings.css")
                );

            var jsBundle = bundles.GetBundleFor("~/Embedded/App/js");

            bundles.Add(
                jsBundle != null
                ? jsBundle.Include("~/App/settings.js")
                : new ScriptBundle("~/Embedded/App/js")
                    .Include("~/App/settings.js")
                );
        }
    }
}
