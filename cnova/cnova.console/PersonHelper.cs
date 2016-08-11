using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnova.console
{
    public static class PersonHelper
    {
        public static List<Person> GetFriends()
        {
            return new List<Person>
            {
                new Person { Name = "John McClane", Location = new GeoCoordinate(-23.5269853, -46.5119155) },
                new Person { Name = "Tyler Durden", Location = new GeoCoordinate(-23.524446, -46.5094798) },
                new Person { Name = "Darth Vader", Location = new GeoCoordinate(-23.4967233, -46.4969501) },
                new Person { Name = "Michael Corleone", Location = new GeoCoordinate(-23.5026368, -46.4958068) },
                new Person { Name = "Marty McFly", Location = new GeoCoordinate(-23.5028835, -46.49578) },
                new Person { Name = "Ron Burgundy", Location = new GeoCoordinate(-23.5020608, -46.4956968) },
                new Person { Name = "Rick Blaine", Location = new GeoCoordinate( -23.493551,-46.4978389) },
                new Person { Name = "Doc Brown", Location = new GeoCoordinate( -23.5288352,-46.5047805) },
                new Person { Name = "Travis Bickle", Location = new GeoCoordinate(-23.5257377,-46.5027787) }

            };
        }
      
    }
}
