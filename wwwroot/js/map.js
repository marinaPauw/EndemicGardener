import 'ol/ol.css';
import Map from 'ol/Map';
import OSM from 'ol/source/OSM';
import TileLayer from 'ol/layer/Tile';
import View from 'ol/View';
import VectorLayer from 'ol/layer/Vector';
import VectorSource from 'ol/source/Vector';
import GeoJSON from 'ol/format/GeoJSON';
import {Fill, Stroke, Style, Text} from 'ol/style';
import Group from 'ol/layer';
//Searchbar:
import 'ol-ext/control/Search.css';
import SearchNominatim from 'ol-ext/control/SearchNominatim';
import LayerSwitcher from 'ol-ext/control/LayerSwitcher';

var style = new Style({
  
  fill: new Fill({
    color: 'rgba(255, 255, 255, 0.6)',
  }),
  stroke: new Stroke({
    color: '#319FD3',
    width: 1,
  }),
  text: new Text({

    font: '12px Calibri,sans-serif',
    fill: new Fill({
      color: '#000',
    }),
    stroke: new Stroke({
      color: '#fff',
      width: 3,
    }),
  }),
});


var biomeSource = new VectorSource({
   
  url: '/js/SimplifiedGEOJSON.json',
  format: new GeoJSON({"dataProjection" : 'EPSG:4326', "featureProjection": 'EPSG:4326'})


})

var biomes = new VectorLayer({
  name: "Vegetation map",
  source: biomeSource,
  visible: false,
  style: function (feature) {
    style.getText().setText(feature.get('NAME'));
    return style;
  },
 
})



var osm = new TileLayer({
  source: new OSM(),
  displayInLayerSwitcher:false,
  name: 'Open street map'
})

var map = new Map({
  layers: [
    osm,biomes
    ],
  target: 'map',
  view: new View({
    projection: 'EPSG:4326',
    center: [19.5,-34.0],
    zoom: 7,
  }),
});

//Highlighting biomes

var highlightStyle = new Style({
  stroke: new Stroke({
    color: '#f00',
    width: 1,
  }),
  fill: new Fill({
    color: 'rgba(255,0,0,0.1)',
  }),
  text: new Text({
    font: '12px Calibri,sans-serif',
    fill: new Fill({
      color: '#000',
    }),
    stroke: new Stroke({
      color: '#f00',
      width: 3,
    }),
  }),
});


var featureOverlay = new VectorLayer({
  source: new VectorSource(),
  map: map,
  style: function (feature) {
    highlightStyle.getText().setText(feature.get('NAME'));
    return highlightStyle;
  },
});

var highlight;
var displayFeatureInfo = function (pixel) {
  var feature = map.forEachFeatureAtPixel(pixel, function (feature) {
    return feature;
  });

  var info = document.getElementById('info');
  var closeModal = document.getElementById('closeModal');
  var homebiome = document.getElementById("homebiome");
  var BiomeModal = document.getElementById("BiomeModal");
  if (feature) {
    info.innerHTML = feature.get('NAME');
    homebiome.innerHTML = feature.get('NAME');
    map.on('click', function (evt) {
      BiomeModal.style.display = "block";
    });
  } else {
    info.innerHTML = '&nbsp;';
    homebiome = "Biome not found";
  }

  if (feature !== highlight) {
    if (highlight) {
      featureOverlay.getSource().removeFeature(highlight);
    }
    if (feature) {
      featureOverlay.getSource().addFeature(feature);
    }
    highlight = feature;
  }
};

map.on('pointermove', function (evt) {
  if (evt.dragging) {
    return;
  }
  var pixel = map.getEventPixel(evt.originalEvent);
  displayFeatureInfo(pixel);
});

// Search control
const search = new SearchNominatim();
search.on('select', function (e) {
    map.getView().animate({
        center: e.coordinate,
        zoom: Math.max(map.getView().getZoom(), 16)
    });
});
map.addControl(search);


//Modal

closeModal.onclick = function() 
  {
    BiomeModal.style.display = "none";
  }

window.onclick = function(event) {
  if (event.target == BiomeModal) {
    BiomeModal.style.display = "none";
  }
}


//Layerswitcher
const osmcheck = document.querySelector('.sidebar > input[name = osmcheckbox]');
const vegcheck = document.querySelector('.sidebar > input[name = vegcheckbox]');
osmcheck.addEventListener('change', function(){
  osm.setVisible(!osm.getVisible());
 })
vegcheck.addEventListener('change', function(){
  biomes.setVisible(!biomes.getVisible());
  })
