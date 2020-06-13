using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;

        public string Message { get; set; }

        //[BindProperty(SupportsGet = true)] - To use this we must remove the searchTerm in the OnGet method
        //(I hve no clue what this model binding means.)
        public string SearchTerm { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            _config = config;
            _restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;
            Message = _config["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}