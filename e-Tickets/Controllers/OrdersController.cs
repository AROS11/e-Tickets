using e_Tickets.Data.Services;
using eTickets.Data.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eTickets.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public OrdersController(IMoviesService moviesService ,ShoppingCart shoppingCart) {
               _moviesService
        
        }
    }
}