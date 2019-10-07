using System;

public class Subject
{
    public string Name;

    public string SubjectName { get => Name; set => Name = value; }

    public Subject(string name)
    {
        this.Name = name;
    }
}