using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace org.ian.zh.fang.project.MoneyCalculation.Models
{
    [DbConfigurationTypeAttribute(typeof(MCDBContextConfiguration))]
    internal class MCDBContext : DbContext
    {
        public MCDBContext() : base("MCDBContext") { }

        public DbSet<MaterialSize> MaterialSizes { get; set; }
    }

    [DbConfigurationTypeAttribute(typeof(MCDBContextConfiguration))]
    internal class MCDBContext<T> : DbContext
        where T : class, new()
    {
        public MCDBContext() : base("MCDBContext") { }

        public DbSet<T> Result { get; set; }
    }

    internal class MCDBContextConfiguration:DbConfiguration
    {
        public MCDBContextConfiguration()
        {
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }
}
