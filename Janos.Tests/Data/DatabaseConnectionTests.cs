using Janos.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Janos.Tests.Data
{
    public class DatabaseConnectionTests
    {
        [Fact]
        public void CanConnectToDatabase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseOracle("User Id=rm99433;Password=090397;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                var canConnect = context.Database.CanConnect();

                Assert.True(canConnect, "Não foi possível conectar ao banco de dados.");
            }
        }
    }
}
