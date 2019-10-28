using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UniBinderAPI.Models
{
    [DataContract]
    public class P
    {

        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int id { get; set; }
        
        public P(string n, int i)
        {
            name = n;
            id = i;
            
        }
    }
}