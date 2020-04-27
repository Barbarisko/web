using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using lab1.Models;
using DataLayer;
using DataLayer.Entities;

namespace lab1.Controllers
{
    public class FiirstController : Controller
    {
        public EFDBContext context;
        public FiirstController(EFDBContext eFDBContext)
        {
            context = eFDBContext;
        }
        public IActionResult Index()
        {
            //Shop _model = new Shop();
            List<Product> products = context.Products.ToList();
            return View(products);
        }

        // 
        // GET: /HelloWorld/

        //public string Index()
        //{
        //    return "This is my default action...";
        //}

        // 
        // GET: /HelloWorld/Welcome/ 

        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}

        //localhost:{PORT}/Fiirst/Welcome?name=Rick&numtimes=4
        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //}

        //localhost:{PORT}/Fiirst/Welcome/3?name=Rick
        public IActionResult Welcome( )
        {
            ViewData["uzhas"] = "Сколько нужно ложек ужаса? - ";
            Random rnd = new Random();
            int ID = rnd.Next(0, 100);
            ViewData["ID"] = ID;
            string model = $"the number of lozhek uzhasa: {ID}";
            return View("Welcome", model);
        }

        public IActionResult Info([FromQuery]string effectivness)
        {
            ViewData["company"] ="Кинокомпания ";
            ViewData["name"] = "ДВАДЦАТыЙ ВЕК ФОКС интертеинмент";
            string model = $"c {effectivness} oruzhiem";
            return View("Info", model);
        }
    }
}