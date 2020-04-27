using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        private string name;
        public string Name { get { return name; } set {  name = value; } }
        //if (value != null)

        private DateTime dateOfBirth;
        public DateTime DateOfBirth { get { return dateOfBirth; } set {  dateOfBirth = value; } }
        //if (value < DateTime.Now)


    }
}
