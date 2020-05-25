using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
   public  class OrderModel
    {
        public int Id { get; set; }
        private DateTime paydate;
        public DateTime Paydate { get { return paydate; } set {  paydate = value; } }
        //

        public List<ProductModel> products { get; set; }

        public int CustomerId { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
