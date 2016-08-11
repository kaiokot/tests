using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;

namespace cnova.console
{

    public class FriendFinder
    {
        public const double DEFAULT_DISTANCE_IN_METERS = 500;

        private List<Person> Friends { get; set; }

        private GeoCoordinate VisitLocation { get; set; }

        public FriendFinder(List<Person> friends)
        {
            Friends = friends;
        }

        public void Visit(double lat, double lon)
        {
            VisitLocation = new GeoCoordinate(lat, lon);
        }

        public void Visit(Person person)
        {
            VisitLocation = new GeoCoordinate(person.Location.Latitude, person.Location.Longitude);
        }

        public void Visit(string friendName)
        {
            if (Friends == null)
                throw new ArgumentNullException("Friends");

            var friend = Friends.FirstOrDefault(_ => _.Name.ToLower() == friendName.ToLower());

            if (friend == null)
                throw new Exception("Friend not found");

            VisitLocation = new GeoCoordinate(friend.Location.Latitude, friend.Location.Longitude);
        }
        
        public List<Person> GetFriendsCloseToMe(double defaultDistanceInMeters = DEFAULT_DISTANCE_IN_METERS)
        {
            if (Friends == null)
                throw new ArgumentNullException("Friends");

            if (VisitLocation == null)
                throw new ArgumentNullException("VisitLocation");


            return Friends.Where(_ => _.Location != VisitLocation
                                        && VisitLocation.GetDistanceTo(_.Location) <= defaultDistanceInMeters)
                                        .Take(3).ToList();

        }

        public double GetDefaultDistanceInMeters()
        {
            return DEFAULT_DISTANCE_IN_METERS;
        }
    }
}
