using AppCore.DataAccess.Configs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Contexts
{
    public class VideosContext : DbContext
    {
        public DbSet<Video> Videolar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionConfig.ConnectionString = "server=.\\SQLEXPRESS;database=VideosDb;user id=sa;password=telefon.123;multipleactiveresultsets=true;";


            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            // Yayın Link Tekil olmalıdır. Bu yüzden Unique olarak tanımladım.
            modelBuilder.Entity<Video>(video => {
                video.HasIndex(d => d.yayinLink).IsUnique();
            });

        }



    }
}
