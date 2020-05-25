using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Properties
    {
        public int Id { get; set; }

        private int mass;
        public int Mass { get { return mass; } set { if (value > 0)  mass = value; } }
        //

        private string mainIngr;
        public string MainIng { get { return mainIngr; } set { if (value != null) mainIngr = value; } }
        //

        private DateTime dateOfCreate;
        public DateTime DateOfCreate { get { return dateOfCreate; } set { if (value < DateTime.Now && value > DateTime.MinValue) dateOfCreate = value; } }
        //

        private DateTime expireDate;
        public DateTime ExpireDate { get { return expireDate; } set { if (value >= DateTime.Now) expireDate = value; } }
        //


    }
}
