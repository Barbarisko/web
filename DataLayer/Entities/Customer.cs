//using DataLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer:IDentity
    {

        private string name;
        public string Name { get { return name; } set { if (value != null) name = value; } }
        //

        //private DateTime dateOfBirth;
        //public DateTime DateOfBirth { get { return dateOfBirth; } set { if (value < DateTime.Now) dateOfBirth = value; } }
        ////
        public List<Order> orders { get; set; }

        public int ShopId { get; set; }
        public Shop shop { get; set; }
        
    }
}
