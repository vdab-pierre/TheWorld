using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;

namespace TheWorld.Models
{
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;
        private ILogger<WorldRepository> _logger;

        public WorldRepository(WorldContext context,ILogger<WorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            try
            {
                return _context.Trips.OrderBy(t => t.Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get trips from the database",ex);
                return null;
            }
        }

        public IEnumerable<Trip> GetAllTripswithStops()
        {
            try
            {
                return _context.Trips.OrderBy(t => t.Name).Include(t => t.Stops).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get trips with stops from the database", ex);
                return null;
            }
        }

        public void AddTrip(Trip newtrip)
        {
            _context.Add(newtrip);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges()>0;
        }



        public Trip GetTripByName(string tripName,string username)
        {
            // ReSharper disable once ReplaceWithSingleCallToFirstOrDefault
            return _context.Trips.Include(t => t.Stops)
                .Where(t => t.Name == tripName && t.UserName==username)
                .FirstOrDefault();

        }

        public void AddStop(string tripName,Stop newStop,string username)
        {
            var theTrip = GetTripByName(tripName,username);
            newStop.Order = theTrip.Stops.Max(s => s.Order) + 1;
            theTrip.Stops.Add(newStop);
            _context.Stops.Add(newStop);
        }

        public IEnumerable<Trip> GetUserTripswithStops(string name)
        {
            try
            {
                return _context.Trips
                    .OrderBy(t => t.Name)
                    .Include(t => t.Stops)
                    .Where(t=>t.UserName==name)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get trips with stops from the database", ex);
                return null;
            }
        }
    }
}
