using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

[DataContract]
public struct Subject
{
    public Subject(string name1)
    {
        this.Name = name1;
    }
    [DataMember]
    public string Name { get; set; }
}