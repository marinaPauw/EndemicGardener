using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using EndemicGardening.Models;

namespace EndemicGardening.Data {
    public class PlantContext : DbContext {
        public PlantContext (DbContextOptions<PlantContext> options) : base (options) { }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<BioPolygon> BioPolys {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Plant>().HasKey(
                t => new { t.PlantId}
            );
            
            modelBuilder.Entity<Plant>().HasData(
                new Plant{
                    PlantId = 1,
                    PlantName = "Babiana fragrans",
                    PicUrl = "https://cdn.pixabay.com/photo/2019/10/26/05/31/flower-4578712_960_720.jpg",
                    BiomeID = 2,
                    Tips = "Seeds must be sown in autumn (March), planted in a sifted mixture of soil/sand and compost (50/50), and covered with soil that is equal in depth to the diameter of the seed. It must be planted in a deep seed tray because, as the seedling grows, it will pull itself down. To maximize percentage germination, the seeds can be leached, scarified or soaked. Soil must be kept moist until germination, which will take 6 weeks or longer.",
                    Descript = "A beautiful dwarf perennial with blue, cinnamon-scented flowers in spring, that is an attractive garden subject and can be planted in a sunny rockery.",
                    Bird = false,
                    Butterfly = true,
                    Bee = true,
                    Edible = true,
                    Flower = true,
                    ConservationStatus = "NT"
                },
                new Plant{
                    PlantId = 2,
                    PlantName = "Aloe marlothii",
                    PicUrl = "https://cdn.pixabay.com/photo/2020/05/25/12/50/aloe-5218483_960_720.jpg",
                    BiomeID = 3,
                    Tips = "Aloe marlothii will grow easily and with very little care in most South African gardens and is recommended for gardens where the species occurs naturally.",
                    Descript = "Aloe marlothii is a striking, robust, large, single-stemmed aloe with a majestic presence. ",
                    Bird = true,
                    Butterfly = true,
                    Bee = false,
                    Edible = false,
                    Flower = true,
                    ConservationStatus = "N"
                },
                new Plant{
                    PlantId = 3,
                    PlantName = "Protea cynaroides",
                    PicUrl = "https://cdn.pixabay.com/photo/2015/11/10/09/23/south-africa-1036552_960_720.jpg",
                    BiomeID = 5,
                    Tips = "Don't touch it's roots.",
                    Descript = "Protea cynaroides is a woody shrub with thick stems and large dark green, glossy leaves. ",
                    Bird = true,
                    Butterfly = true,
                    Bee = false,
                    Edible = false,
                    Flower = true,
                    ConservationStatus = "LC"
                },
                new Plant{
                    PlantId = 4,
                    PlantName = "Acacia Tree",
                    PicUrl = "https://cdn.pixabay.com/photo/2013/01/05/13/17/acacia-flowers-73866_960_720.jpg",
                    BiomeID = 5,
                    Tips = "Do not overwater.",
                    Descript = "Silk Acacia",
                    Bird = true,
                    Butterfly = true,
                    Bee = false,
                    Edible = false,
                    Flower = false,
                    ConservationStatus = "N"
                },
                new Plant{
                    PlantId = 5,
                    PlantName = "Strelitzia reginae",
                    PicUrl = "https://cdn.pixabay.com/photo/2013/12/30/22/24/flower-236008__340.jpg",
                    BiomeID = 1,
                    Tips = "Ideal conditions are full sun, rich, well-drained loam soil with a pH of approximately 7.5, regular deep watering in summer and liberal applications of fertilizer in early summer",
                    Descript = "Mandela's gold",
                    Bird = true,
                    Butterfly = true,
                    Bee = false,
                    Edible = false,
                    Flower = true,
                    ConservationStatus = "N"
                }
            );

            modelBuilder.Entity<BioPolygon>().HasKey
                (
                    t => new { t.ID}
                );
            
            modelBuilder.Entity<BioPolygon>().HasData
            (
                new BioPolygon
                {
                    ID= 1,
                    Name = "Agulhas Limestone Fynbos",
                    GroupName = "Limestone Fynbos"
                }
            );
        }
    }
}
