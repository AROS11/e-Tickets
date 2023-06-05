<<<<<<< HEAD
﻿using e_Tickets.Data.Services;
using eTickets.Data.Cart;
=======
﻿using eTickets.Data.Cart;
>>>>>>> 6a5faca65390ae0996ba7ec5f6c136cd99eb2bf4
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