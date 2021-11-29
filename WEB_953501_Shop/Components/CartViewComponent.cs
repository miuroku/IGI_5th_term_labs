using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_Shop.Models;
using WEB_953501_Shop.Exstensions;
using Microsoft.AspNetCore.Http;
using WEB_953501_Shop.Extensions;

namespace WEB_953501_Shop.Components
{
    public class CartViewComponent : ViewComponent
    {

        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {            
            return View(_cart);
        }
    }
}
