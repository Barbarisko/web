using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        private string name;
        public string Name { get { return name; } set { if (value != null) name = value; } }
        private int price;
        public int Price { get { return price; } set {  price = value; } }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
