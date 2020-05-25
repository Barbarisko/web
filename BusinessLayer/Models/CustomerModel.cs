using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
   public class CustomerModel
    {
        public int Id { get; set; }

        private string name;
        public string Name { get { return name; } set { if (value != null) name = value; } }
        //

        private DateTime dateOfBirth;
        public DateTime DateOfBirth { get { return dateOfBirth; } set { if (value < DateTime.Now) dateOfBirth = value; } }
        //
        public List<OrderModel> orders { get; set; }

        public int ShopId { get; set; }
        public ShopModel Shop { get; set; }
    }
}
