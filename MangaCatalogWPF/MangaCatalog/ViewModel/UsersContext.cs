using MangaCatalog.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MangaCatalog.ViewModel
{
    class YourDbContext : DbContext
	{
        public YourDbContext() : base("name=WpfDb.Properties.Settings.userConnectionString")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Bookmarks> Bookmarks { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
