using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlifWebservice.Model
{
    public class User_Details
    {
        public int User_Details_ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Contact_No { get; set; }
        public string Email_ID { get; set; }
        public string Password { get; set; }
        public int Is_Deleted { get; set; }
    }
}