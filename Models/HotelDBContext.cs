using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
    public partial class HotelDBContext : DbContext
    {
        public HotelDBContext()
            : base("name=CustomerInfoConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<CustomerInfos> CustomerInfo { get; set; }

        public DbSet<TestModel> TestTable { get; set; }
    }
}