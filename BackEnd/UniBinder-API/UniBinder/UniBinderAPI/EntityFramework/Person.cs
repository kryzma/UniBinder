using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniBinderAPI.EntityFramework
{
    public class Person
    {
        [Key]
        public int PersobID { get; set; }
        public string PersonName { get; set; }
    }
}