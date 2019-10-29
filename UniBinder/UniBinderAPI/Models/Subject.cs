using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UniBinderAPI.Models
{
    [DataContract]
    public class Subject
    {
        public Subject(string name1)
        {
            this.Name = name1;
        }
        [DataMember]
        public string Name { get; set; }
    }
}