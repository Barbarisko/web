using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
   public  class PropertyModel
    {
        public int Id { get; set; }

        private int mass;
        public int Mass { get { return mass; } set { mass = value; } }
        //

        private string mainIngr;
        public string MainIng { get { return mainIngr; } set {  mainIngr = value; } }
        //

        private DateTime dateOfCreate;
        public DateTime DateOfCreate { get { return dateOfCreate; } set { dateOfCreate = value; } }
        //

        private DateTime expireDate;
        public DateTime ExpireDate { get { return expireDate; } set {  expireDate = value; } }
    }
}
