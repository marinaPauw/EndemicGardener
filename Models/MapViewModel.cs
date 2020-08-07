using System.Collections.Generic;
using EndemicGardening.Data;
using EndemicGardening.Controllers;

namespace EndemicGardening.Models
{
    public class MapViewModel
    {
        public IEnumerable<BioPolygon> biomes{get;set;}

    }
}