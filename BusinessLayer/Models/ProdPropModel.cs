using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ProdPropModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int PropertiesId { get; set; }
        public PropertyModel Properties { get; set; }
    }
}
