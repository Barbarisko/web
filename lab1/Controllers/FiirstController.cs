using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BusinessLayer.Models;
using DataLayer;
using DataLayer.Entities;
using BusinessLayer;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using lab1.Models;
using BusinessLayer.Interfaces;

namespace lab1.Controllers
{
    public class FiirstController : Controller
    {
        public EFDBContext context;
        private IUnitOfWork _datamanager;
        IProductService productService;
        IOrderService orderService;
        ICustomerService customerService;
        IShopService shopService;


        public FiirstController(IProductService productService, IOrderService orderService, ICustomerService customerService,
            IShopService shopService, IUnitOfWork dataManager)
        {
            _datamanager = dataManager;
            this.productService = productService;
            this.orderService = orderService;
            this.customerService = customerService;
            this.shopService = shopService;
        }

        public ActionResult Index(/*int id*/)
        {
            var shop = shopService.GetShop(1);
            ViewBag.customers = customerService.GetAll(shop);
            return View();
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
        public ActionResult Welcome( )
        {
            ViewData["uzhas"] = "Сколько нужно ложек ужаса? - ";
            Random rnd = new Random();
            int ID = rnd.Next(0, 100);
            ViewData["ID"] = ID;
            string model = $"the number of lozhek uzhasa: {ID}";
            return View("Welcome", model);
        }

        [HttpGet]
        public ActionResult ordersFromCustomer(int id)
        {
            var customer = customerService.GetCustomer(id);
            ViewBag.orders = orderService.GetOrdersFromCustomer(customer);
            ViewBag.CustomerId = id;
            return View();
        }


        [HttpGet]
        public ActionResult productsFromOrder(int idorder, int idcust)
        {
            var customer = customerService.GetCustomer(idcust);
            ViewBag.Customer = customer;
            var order = orderService.GetOrder(idorder);
            ViewBag.Order = order;
            ViewBag.products = productService.GetAllProducts(order);
            return View();
        }

        [HttpGet]
        public ActionResult addProductToOrder(int idorder,int idcust)
        {
            ViewBag.Customer = customerService.GetCustomer(idcust);
            ViewBag.Order = orderService.GetOrder(idorder);
            return View();
        }



        [HttpPost]
        public ActionResult addProductToOrder(int idorder, int idcust, ProductModel prmod)
        {
            try
            {
                prmod.OrderId = idorder;
                ViewBag.Customer = customerService.GetCustomer(idcust);
                var order = orderService.GetOrder(idorder);
                prmod.Order = order;
                ViewBag.Order = order;
                productService.AddProductToOrder(prmod);
                return RedirectToAction(nameof(productsFromOrder),
                    new { idorder = idorder, idcust = ViewBag.Customer.Id });
            }
            catch
            {
                return View(prmod);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int idcust, int idorder, int idproduct)
        {
            ViewBag.Customer = customerService.GetCustomer(idcust);
            ViewBag.Order = orderService.GetOrder(idorder);
            ViewBag.Product = productService.GetProduct(idproduct);
            return View();
        }
        [HttpPost]
        public ActionResult EditProduct(int idcust, int idorder, int idproduct, ProductModel prmod)
        {
            try
            {
                prmod.Id = idproduct;
                prmod.OrderId = idorder;
                ViewBag.Customer = customerService.GetCustomer(idcust);
                var order = orderService.GetOrder(idorder);
                prmod.Order = order;
                ViewBag.Order = order;
                productService.EditProduct(prmod);
                return RedirectToAction(nameof(productsFromOrder), new { idorder = idorder, idcust = ViewBag.Customer.Id });
            }
            catch
            {
                return View(prmod);
            }
        }

        [HttpGet]
        public ActionResult DeleteProductFromOrder(int idcust, int idorder, int idproduct)
        {
            ViewBag.Customer = customerService.GetCustomer(idcust);
            ViewBag.Order = orderService.GetOrder(idorder);
            var pr = productService.GetProduct(idproduct);
            ViewBag.Product = pr;

            return View(pr);
        }

        [HttpPost, ActionName("DeleteProductFromOrder")]
        public ActionResult DeleteConfirmation(int idcust, int idorder, int idproduct)
        {

            ViewBag.Customer = customerService.GetCustomer(idcust);
            var order = orderService.GetOrder(idorder);
            ViewBag.Order = order;
            var product = productService.GetProduct(idproduct);
            ViewBag.Product = product;
            productService.DeleteProductFromOrder(product);

            return RedirectToAction(nameof(productsFromOrder), new { idorder = idorder, idcust = ViewBag.Customer.Id });
        }

        [HttpGet]
        public ActionResult CountOrderSum(int idorder, int idcustomer)
        {
            ViewBag.Customer = customerService.GetCustomer(idcustomer);
            var order = orderService.GetOrder(idorder);
            ViewBag.Order = order;
            ViewBag.OrderSum = orderService.CountSum(order);
            return View();
        }

        public ActionResult Info([FromQuery]string effectivness)
        {
            ViewData["company"] ="Кинокомпания ";
            ViewData["name"] = "ДВАДЦАТыЙ ВЕК ФОКС интертеинмент";
            string model = $"c {effectivness} oruzhiem";
            return View("Info", model);
        }
    }
}