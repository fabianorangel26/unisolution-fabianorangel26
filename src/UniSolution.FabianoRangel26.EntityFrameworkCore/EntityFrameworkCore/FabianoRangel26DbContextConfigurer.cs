using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace UniSolution.FabianoRangel26.EntityFrameworkCore
{
    public static class FabianoRangel26DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FabianoRangel26DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FabianoRangel26DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
