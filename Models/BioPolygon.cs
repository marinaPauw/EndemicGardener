using System.Collections.Generic;
namespace EndemicGardening.Models
{
    public class BioPolygon
    {
        public int PolygonID {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}

        public ICollection<BioPolygonToPlants> BioPolygonToPlants {get;set;}
    }
}