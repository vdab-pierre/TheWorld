using System.Collections.Generic;

namespace TheWorld.Models
{
    public interface IWorldRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripswithStops();
        void AddTrip(Trip newtrip);
        bool SaveAll();
        Trip GetTripByName(string tripName,string username);
        void AddStop(string tripName, Stop newStop, string username);
        IEnumerable<Trip> GetUserTripswithStops(string name);
    }
}