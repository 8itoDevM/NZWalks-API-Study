using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data {
    public class NZWalksDbContext : DbContext {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            // Easy, Medium, Hard

            var difficulties = new List<Difficulty>() {
                new Difficulty() {
                    Id = Guid.Parse("b709c0ce-14d1-4cfd-a395-939870baa4b7"),
                    Name = "Easy"
                },
                new Difficulty() {
                    Id = Guid.Parse("0657e12b-df8c-4585-bc9b-3e73bd87641c"),
                    Name = "Medium"
                },
                new Difficulty() {
                    Id = Guid.Parse("81c0af7a-71a0-4465-b3b8-f5c594d527e9"),
                    Name = "Hard"
                }
            };

            // Seed difficultie to the db
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>() {
                new Region{
                    Id = Guid.Parse("a826c3b6-73e3-42ec-953b-89d846390445"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("890db9d2-d136-44fc-9d8a-0cbfbdf837f5"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("ed11cec3-239a-46ca-a3f7-d7ed254eb93e"),
                    Name = "Waikato",
                    Code = "WKO",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("13f6df00-5176-4f16-84c6-16bb68a64732"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("ebef9e55-bab4-4cb7-8830-c1163cc1fda1"),
                    Name = "Gisborne",
                    Code = "GIS",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("e5727df3-dd72-48ce-a1e3-43a8d0fb78d6"),
                    Name = "Hawke's Bay",
                    Code = "HKB",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("4d864403-cd39-41ea-9de0-2722be1d2889"),
                    Name = "Taranaki",
                    Code = "TKI",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("7e57aa5e-0e80-4bb7-8b68-8c2717bc1ea7"),
                    Name = "Manawatū-Whanganui",
                    Code = "MWT",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("6e9663ef-18ec-4e35-afda-2402ee6475aa"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("cf803131-4c4e-4611-aebc-2969786ca2fe"),
                    Name = "Tasman",
                    Code = "TSM",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("0ba74158-9b74-425d-aa08-6697129820d2"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("39b78159-3b00-4605-bd72-37cdd5b40a1f"),
                    Name = "Marlborough",
                    Code = "MBH",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("ba555ee1-d31b-4561-abb7-de08b74985ea"),
                    Name = "West Coast",
                    Code = "WTC",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("65abc285-2e72-45ac-8aa7-1166b069ed34"),
                    Name = "Canterbury",
                    Code = "CAN",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("4ce06d01-c392-46c7-b73e-9d677659cfa2"),
                    Name = "Otago",
                    Code = "OTA",
                    RegionImageUrl = "https://picsum.photos/200/200"
                },
                new Region{
                    Id = Guid.Parse("e7975595-fe45-4cd4-843b-fd955bbe5503"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://picsum.photos/200/200"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
