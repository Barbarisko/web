using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopApi.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService productService;
        OrderModel order;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return productService.GetAllProducts(order);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult GetProduct(int id)
        {
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductModel> AddProduct(ProductModel product)
        {
            productService.AddProductToOrder(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id}, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductModel product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            productService.EditProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            productService.DeleteProductFromOrder(productService.GetProduct(id));
            return NoContent();
        }
    }
}
