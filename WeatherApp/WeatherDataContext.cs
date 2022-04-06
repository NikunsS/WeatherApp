using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WeatherApp
{
    public class WeatherDataContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WeatherApp.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public WeatherDataContext()
            : base("name=WeatherDataContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<WeatherInfo> WeatherInfos { get; set; }



        public class WeatherDbInitializer : DropCreateDatabaseAlways<WeatherDataContext>
        {
            protected override void Seed(WeatherDataContext context)
            {
                var WeatherInfos = new List<WeatherInfo>
                {
                    new WeatherInfo()
                    {
                        ID = 1,
                        Name = "Wroc³aw",
                        temp = 12.3,
                        Date = DateTime.Now
                    }
                };
                WeatherInfos.ForEach(s => context.WeatherInfos.Add(s));
                context.SaveChanges();
            }
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}