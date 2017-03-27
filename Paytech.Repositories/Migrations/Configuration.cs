namespace Paytech.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EntityFrameworkImplementation;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.People.AddOrUpdate(a => a.Id, InMemoryImplementation.InMemoryContext.People);
            context.Animals.AddOrUpdate(a => a.Id, InMemoryImplementation.InMemoryContext.Animals);
        }
    }
}
