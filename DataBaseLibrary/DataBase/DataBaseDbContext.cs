using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLibrary.DataBase
{
    public partial class DataBaseDbContext : DbContext
    {
        public DataBaseDbContext()
            : base("name=UserInfo")
        {
        }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
