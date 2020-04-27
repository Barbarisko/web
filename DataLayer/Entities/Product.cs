using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        private string name;
        public string Name { get { return name; } set {   name = value;  } }
        //if (value != null)
        private string price;
        public string Price { get { return price; } set {  price = value;  } }
        //if (value >= 0)
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
