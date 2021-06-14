using Entities.Concrete;
using Infrastructure.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexs
{
    public class ToJpegContext : DbContext
    {
        public ToJpegContext(DbContextOptions<ToJpegContext> options) : base(options)
        {

        }

        public ToJpegContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:jpegdokumans.database.windows.net,1433;Initial Catalog=JpegDokumans;User Id=tojpeg@jpegdokumans;Password=proje.01");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
