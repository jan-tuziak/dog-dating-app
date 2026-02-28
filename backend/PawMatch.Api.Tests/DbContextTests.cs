using Microsoft.EntityFrameworkCore;
using PawMatch.Api.Data;
using Xunit;

namespace PawMatch.Api.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void CanConstructContext_WithInMemoryProvider()
        {
            var options = new DbContextOptionsBuilder<PawMatchContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using var context = new PawMatchContext(options);
            Assert.NotNull(context);
            Assert.True(context.Dogs != null);
            Assert.True(context.Owners != null);
        }
    }
}
