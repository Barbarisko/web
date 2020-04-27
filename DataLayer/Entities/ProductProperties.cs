using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class ProductProperties
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
    }
}
