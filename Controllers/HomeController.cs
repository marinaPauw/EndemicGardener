﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EndemicGardening.Models;
using EndemicGardening.Data;

namespace EndemicGardening.Controllers
{
    public class HomeController : Controller
    {
        private PlantContext _context;

        public HomeController(PlantContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult BioPolygonToPlants(string name)
        {       
                var biopolygon = _context.BioPolygon.SingleOrDefault(b=> b.Name == name);
                var plants = _context.BioPolygon.Where(b=> b.Name == name).SelectMany(btp => btp.BioPolygonToPlants.Select(b=>b.Plant)).ToList();
                               
                var bm = new BiomePlantsViewModel 
                {
                    BioPolygon = biopolygon,
                    Plants = plants
                };
                return View(bm);
        }

        public IActionResult PlantCatalogue()
        {
            var plants =_context.Plants.ToList();
            if(plants == null)
            {
                Console.WriteLine("Uh-Oh plants is null!");
            }    
            else
            {
                foreach(Plant plant in plants)
                {
                    AllocateCS(plant);
                }
            }
            return View(plants);
        }
        
        public void AllocateCS(Plant plant )
        {
            if(plant.ConservationStatus == "NT")
                {
                    plant.CS = "Conservation status: Near threatened";
                }
            else if(plant.ConservationStatus == "N")
                {
                    plant.CS = "Conservation status: Not threatened";
                }
            else if(plant.ConservationStatus == "T")
                {
                    plant.CS = "Conservation status:Threatened";
                }
            else if(plant.ConservationStatus == "LC")
                {
                    plant.CS = "Conservation status:Least Concern";
                }
            else
                {
                    plant.CS = "Conservation status:Unknown";
                }
        }
        public IActionResult Details(int Id)
        {
            var plant = _context.Plants.SingleOrDefault(p => p.PlantId == Id);
            var vm = new DetailsViewModel {
                Plant = plant
            };

            if (plant != null)
            {
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Maps()
        {
            return View(new MapViewModel());
            
        }
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
