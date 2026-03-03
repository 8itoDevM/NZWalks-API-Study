using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data {
    public class NZWalksAuthDbContext : IdentityDbContext {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            var readerRoleId = "f80bf938-9bdf-462a-b035-134aae6d0531";
            var writerRoleId = "85481d8f-b043-4233-a577-45d5a542cf81";

            var roles = new List<IdentityRole> {
                new IdentityRole {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
