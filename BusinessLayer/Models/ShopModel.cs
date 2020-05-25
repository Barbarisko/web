using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ShopModel
    {
        public int Id { get; set; }
        public List<CustomerModel> customers { get; set; }
    }
}
