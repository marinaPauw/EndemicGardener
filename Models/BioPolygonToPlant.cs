using System.Collections.Generic;

namespace EndemicGardening.Models
{
    public class BioPolygonToPlants
    {
        public string Name {get; set;}
        public int PlantID {get;set;}

        public BioPolygon BioPolygon {get; set;}

        public Plant Plant {get;set;}
    }
}