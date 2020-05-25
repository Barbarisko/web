using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Product:IDentity
    {
        private string name;
        public string Name { get { return name; } set { if (value != null) name = value;  } }
        //
        private int price;
        public int Price { get { return price; } set { if (value >= 0) price = value;  } }
        //
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
