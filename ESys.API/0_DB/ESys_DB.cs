using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESys.DB
{
    public partial class ESys_DBContext : DbContext
    {
        public ESys_DBContext()
            : base("name=ESys_DB")
        {
        }

        public virtual DbSet<FB_Account> FB_Account { get; set; }
        public virtual DbSet<Local_Account> Local_Account { get; set; }
        public virtual DbSet<MemberType> MemberType { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
