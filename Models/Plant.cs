namespace EndemicGardening.Models
{
    public class Plant
    {
        public int PlantId {get;set;}
        public string PlantName {get;set;}
        public string PicUrl {get;set;}
        public int BiomeID {get;set;}
        public string Tips {get;set;}
        public string Descript {get;set;}
        public bool Bird {get;set;}
        public bool Butterfly {get; set;}
        public bool Bee {get;set;}
        public bool Edible {get;set;}
        public bool Flower {get;set;}
        public string ConservationStatus {get; set;}
        public string CS = "Unknown";

    }
}