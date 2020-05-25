using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace DataLayer.Entities
{
    public class Shop:IDentity
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        public List<Customer> customers { get; set; }
        public Shop()
        {
            customers = new List<Customer>();
        }
    }
}
