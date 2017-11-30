using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ReadLine();
			Console.WriteLine("Skapar context");
			LeksaksContext context = new LeksaksContext();
			Console.WriteLine("Kör query");
			var query = from x in context.Leksaker
						select x.Name;
			Console.WriteLine("Vad finns i databasen?");
			foreach (var namn in query)
				Console.WriteLine($"Leksak: {namn}");
			Console.WriteLine("Alla leksaker utskrivna.");

			var query2 = (from x in context.Leksaker
						  select x.Tillverkare.Namn).First();
			Console.WriteLine("Första leksaken är tillverkad av: " + query2);

			AddStuff(context);


			Console.ReadLine();
		}
		private static void AddStuff(LeksaksContext context)
		{
			Tillverkare t = new Tillverkare();
			t.Namn = "Mulle Meck";
			t.Leksaker = new List<Leksak>();

			Leksak le = new Leksak();
			le.Name = "flygplan";
			le.MinstaÅlder = 5;
			le.Pris = 50000;
			le.Tillverkare = t;

			t.Leksaker.Add(le);
			context.Tillverkare.Add(t);
			context.SaveChanges();
		}
	}

	public class LeksaksContext : DbContext
	{
		private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EntityFrameworkDemo20171128;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		public LeksaksContext() : base(connectionString) { }
		public DbSet<Leksak> Leksaker { get; set; }
		public DbSet<Tillverkare> Tillverkare { get; set; }
	}

	public class Leksak
	{
		public int Id { get; set; }

		[Column("Namn", TypeName = "nvarchar")]
		[StringLength(50)]
		public string Name { get; set; }

		public float MinstaÅlder { get; set; }

		public decimal Pris { get; set; }

		// en tillverkare
		public int TillverkareIdFK { get; set; }

		[ForeignKey("TillverkareIdFK")]
		public virtual Tillverkare Tillverkare { get; set; }

		[NotMapped]
		public bool Igelkott { get; set; }
	}
	[Table("TillverkareUtanS")]
	public class Tillverkare
	{
		[Key]
		public int TillverkareId { get; set; }

		[Required]
		public string Namn { get; set; }

		// alla leksaker som man tillverkar
		[Required]
		public virtual IList<Leksak> Leksaker { get; set; }
	}

}
