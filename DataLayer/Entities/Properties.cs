using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Properties
    {
        public int Id { get; set; }

        private int mass;
        public int Mass { get { return mass; } set {  mass = value; } }
        //if (value > 0)

        private string mainIngr;
        public string MainIng { get { return mainIngr; } set { mainIngr = value; } }
        // if (value != null)

        private DateTime dateOfCreate;
        public DateTime DateOfCreate { get { return dateOfCreate; } set {  dateOfCreate = value; } }
        //if (value < DateTime.Now && value > DateTime.MinValue)

        private DateTime expireDate;
        public DateTime ExpireDate { get { return expireDate; } set {  expireDate = value; } }
        //if (value >= DateTime.Now)


    }
}
