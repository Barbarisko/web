using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Order:IDentity
    {
        public int Id { get; set; }
        private DateTime paydate;
        public DateTime Paydate { get { return paydate; } set { if (value <= DateTime.Now) paydate = value; } }
        //

        public List<Product> products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
            products = new List<Product>();
        }
        
    }
}
