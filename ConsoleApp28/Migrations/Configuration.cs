namespace ConsoleApp28.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApp28.LeksaksContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			ContextKey = "ConsoleApp28.LeksaksContext";
		}

		protected override void Seed(ConsoleApp28.LeksaksContext context)
		{
			Leksak barbie = new Leksak()
			{
				Minsta≈lder = 0.5f,
				Name = "Barbie",
				Pris = 1330,
				Tillverkare = new Tillverkare()
				{
					Leksaker = new List<Leksak>() { },
					Namn = "ITHS"
				}
			};
			barbie.Tillverkare.Leksaker.Add(barbie);
			context.Leksaker.Add(barbie);

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
		}
	}
}
