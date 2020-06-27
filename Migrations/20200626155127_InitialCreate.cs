using Microsoft.EntityFrameworkCore.Migrations;

namespace EndemicGardening.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BioPolys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioPolys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(nullable: true),
                    PicUrl = table.Column<string>(nullable: true),
                    BiomeID = table.Column<int>(nullable: false),
                    Tips = table.Column<string>(nullable: true),
                    Descript = table.Column<string>(nullable: true),
                    Bird = table.Column<bool>(nullable: false),
                    Butterfly = table.Column<bool>(nullable: false),
                    Bee = table.Column<bool>(nullable: false),
                    Edible = table.Column<bool>(nullable: false),
                    Flower = table.Column<bool>(nullable: false),
                    ConservationStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantId);
                });

            migrationBuilder.InsertData(
                table: "BioPolys",
                columns: new[] { "ID", "GroupName", "Name" },
                values: new object[] { 1, "Limestone Fynbos", "Agulhas Limestone Fynbos" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "PlantId", "Bee", "BiomeID", "Bird", "Butterfly", "ConservationStatus", "Descript", "Edible", "Flower", "PicUrl", "PlantName", "Tips" },
                values: new object[,]
                {
                    { 1, true, 2, false, true, "NT", "A beautiful dwarf perennial with blue, cinnamon-scented flowers in spring, that is an attractive garden subject and can be planted in a sunny rockery.", true, true, "https://cdn.pixabay.com/photo/2019/10/26/05/31/flower-4578712_960_720.jpg", "Babiana fragrans", "Seeds must be sown in autumn (March), planted in a sifted mixture of soil/sand and compost (50/50), and covered with soil that is equal in depth to the diameter of the seed. It must be planted in a deep seed tray because, as the seedling grows, it will pull itself down. To maximize percentage germination, the seeds can be leached, scarified or soaked. Soil must be kept moist until germination, which will take 6 weeks or longer." },
                    { 2, false, 3, true, true, "N", "Aloe marlothii is a striking, robust, large, single-stemmed aloe with a majestic presence. ", false, true, "https://cdn.pixabay.com/photo/2020/05/25/12/50/aloe-5218483_960_720.jpg", "Aloe marlothii", "Aloe marlothii will grow easily and with very little care in most South African gardens and is recommended for gardens where the species occurs naturally." },
                    { 3, false, 5, true, true, "LC", "Gloriosa superba is a deciduous, summer-growing climber up to 1.5 m tall, with tuberous roots.", false, true, "https://cdn.pixabay.com/photo/2015/11/10/09/23/south-africa-1036552_960_720.jpg", "Gloriosa superba", "Gloriosa superba has weak stems and uses other plants for support, climbing by means of the tendrils at its leaf tips, which cling to shrubs and trees that they touch." },
                    { 4, false, 5, true, true, "N", "Silk Acacia", false, true, "https://cdn.pixabay.com/photo/2013/01/05/13/17/acacia-flowers-73866_960_720.jpg", "Acacia Tree", "Do not overwater." },
                    { 5, false, 1, true, true, "N", "Mandela's gold", false, true, "https://cdn.pixabay.com/photo/2013/12/30/22/24/flower-236008__340.jpg", "Strelitzia reginae", "Ideal conditions are full sun, rich, well-drained loam soil with a pH of approximately 7.5, regular deep watering in summer and liberal applications of fertilizer in early summer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioPolys");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
