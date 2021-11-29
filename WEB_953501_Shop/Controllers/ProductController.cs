using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953501_Shop.Entities;
using WEB_953501_Shop.Models;
using WEB_953501_Shop.Data;
using WEB_953501_Shop.Exstensions;
using Microsoft.AspNetCore.Mvc;

namespace WEB_953501_Shop.Controllers
{
    public class ProductController : Controller
    {
        //List<Dish> _dishes;
        //List<DishGroup> _dishGroups;
        
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            //var dishesFiltered = _dishes.Where(d => !group.HasValue || d.DishGroupId == group.Value);
            var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);

            // Поместить список групп во ViewData
            //ViewData["Groups"] = _dishGroups;
            ViewData["Groups"] = _context.DishGroups;

            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;

            //return View(_dishes);
            //return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
        
    }
}
