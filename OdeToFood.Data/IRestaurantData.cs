using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "La Nopalera", Location = "Jacksonville", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 3, Name = "Curry is Love", Location = "Middleburg", Cuisine = CuisineType.Indian},
            };


        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in _restaurants
                orderby r.Name
                select r;
        }
    }
}
