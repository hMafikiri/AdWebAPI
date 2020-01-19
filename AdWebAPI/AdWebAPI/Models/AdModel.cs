namespace AdWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AdModel : DbContext
    {
        public AdModel()
            : base("name=AdModel")
        {
        }

        public virtual DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
