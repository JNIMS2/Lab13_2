using Lab13_2_dev_build.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;



namespace Lab13_2_dev_build.Controllers
{
    public class ProductController : Controller
    {

        //index view shows only names and prices
        //in index make a link around each product name. have the link go to the detail action, passing that object's id.

        //changed index to product index. was that ok? or should i have make a new productIndex action?
        public IActionResult Index()
        {
            MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");
            List<Product> prodlist = db.GetAll<Product>().ToList();
            return View(prodlist);
            //how do i also get prices?
        }



        //clicking on a product name take you to a description page

        //detail action/view

        public IActionResult Detail(int pr)
        {
            MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");
            Product prod = db.Get<Product>(pr);
            return View(prod);

        }
    }
}
