using System.Data.Entity.Migrations;
using EntityFramework.DynamicFilters;

namespace Localink.Modules.Settings.EntityFramework.Migrations
{
    public class Configuration : DbMigrationsConfiguration<SettingsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SettingsModule";
        }

        protected override void Seed(SettingsDbContext context)
        {
            context.DisableAllFilters();

            //TODO: add seed data...

            context.SaveChanges();
        }
    }
}
