using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }
        public void EnsureSeedData()
        {
            if (!_context.Trips.Any())
            {
                //add new data
                var usTrip = new Trip()
                {
                    Name = "Us Trip",
                    Created=DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                      new Stop() {Name="Atlanta, GA",Arrival=new DateTime(2016,2,3),Latitude = 33.74857,Longitude = -84.38669,Order=0},
                      new Stop() {Name="New York, NY",Arrival=new DateTime(2016,2,10),Latitude = 40.71278,Longitude = -74.00594,Order=1},
                      new Stop() {Name="Boston,MA",Arrival=new DateTime(2016,2,20),Latitude = 42.36008,Longitude = -71.05888,Order=2},
                      new Stop() {Name="Chicago,IL",Arrival=new DateTime(2016,3,3),Latitude = 41.87811,Longitude = -87.62980,Order=3},
                      new Stop() {Name="Seattle,WA",Arrival=new DateTime(2016,3,13),Latitude = 47.60621,Longitude = -122.3320,Order=4},
                      new Stop() {Name="Atlanta, GA",Arrival=new DateTime(2016,3,30),Latitude = 33.74857,Longitude = -84.38669,Order=5}
                    }
                };

                var worldrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.UtcNow,
                    UserName = "",
                    Stops = new List<Stop>()
                    {
                      new Stop() {Name="Atlanta, Georgia",Arrival=new DateTime(2016,2,3),Latitude = 33.74857,Longitude = -84.38669,Order=0},
                      new Stop() {Name="Paris, France",Arrival=new DateTime(2016,2,10),Latitude = 40.71278,Longitude = -74.00594,Order=1},
                      new Stop() {Name="Brussels,Belgium",Arrival=new DateTime(2016,2,20),Latitude = 42.36008,Longitude = -71.05888,Order=2},
                      new Stop() {Name="Bruges,Belgium",Arrival=new DateTime(2016,3,3),Latitude = 41.87811,Longitude = -87.62980,Order=3},
                      new Stop() {Name="Paris,France",Arrival=new DateTime(2016,3,13),Latitude = 47.60621,Longitude = -122.3320,Order=4},
                      new Stop() {Name="London,UK",Arrival=new DateTime(2016,3,30),Latitude = 33.74857,Longitude = -84.38669,Order=5},
                      new Stop() {Name="Atlanta, Georgia",Arrival=new DateTime(2016,2,3),Latitude = 33.74857,Longitude = -84.38669,Order=6}
                    }
                };

                _context.Trips.Add(usTrip);
                _context.Stops.AddRange(usTrip.Stops);

                _context.Trips.Add(worldrip);
                _context.Stops.AddRange(worldrip.Stops);

                _context.SaveChanges();
            }


        }
    }
}
