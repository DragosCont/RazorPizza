using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizza.Data;
using RazorPizza.Models;

namespace RazorPizza.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
        public string PizzaName { get; set; }
        public float PizzaPrice { get; set; }
        public string ImageTitle { get; set; }

        public readonly ApplicationDbContext _context;
        public CheckoutModel(ApplicationDbContext context)
        {
            //this is the DB
            _context = context;
        }

        public void OnGet()
        {
            //sets the default name of pizza and the default image
            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "CustomPizza";
            }
            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.PizzaName = PizzaName;
            pizzaOrder.BasePrice = PizzaPrice;

            //adds the order into the DB
            _context.PizzaOrders.Add(pizzaOrder);

            //save the DB
            _context.SaveChanges();

        }
    }
}
