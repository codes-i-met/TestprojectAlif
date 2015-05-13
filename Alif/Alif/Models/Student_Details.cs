using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alif.Models
{
    public class Student_Details
    {
       public int Student_Details_id {get;set;}
       public string Student_Name { get; set; }
       public string Guardian_Name { get; set; }
       public int Center_Id { get; set; }
       public int Guardian_Contact_Number { get; set; }
    }
}