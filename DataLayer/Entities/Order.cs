using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }

        private DateTime paydate;
        public DateTime Paydate { get { return paydate; } set { paydate = value; } }
        //if (value <= DateTime.Now) 

        public List<Product> products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
    }
}
