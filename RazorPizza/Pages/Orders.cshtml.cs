using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Data;
using RazorPizza.Models;

namespace RazorPizza.Pages
{
    public class OrdersModel : PageModel
    {

        public List<PizzaOrder> PizzaOrders = new List<PizzaOrder>();

        //accessing the DB using dependency injection
        private readonly ApplicationDbContext _context;
        public OrdersModel(ApplicationDbContext context)                    //constructor for dependency injection
        {
            _context = context;
        }


        public void OnGet()
        {
            PizzaOrders=_context.PizzaOrders.ToList();                    //accessing the entries from the DB and put them into a list

        }
    }
}
