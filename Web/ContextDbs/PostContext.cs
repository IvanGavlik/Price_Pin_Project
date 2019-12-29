using System;
using System.Data.Common;
using System.Data.Entity;
using Web.Models;
//using MySql.Data.Entity;


namespace Web.ContextDbs
{
	public class PostContext : DbContext 
	{
		public PostContext()  : base("connStr")
		{
		}

		public PostContext(DbConnection existingConnection, bool contextOwnsConnection)
			: base(existingConnection, contextOwnsConnection)
		{

		}

		public DbSet <Post> Posts { get; set;}
	}
}

