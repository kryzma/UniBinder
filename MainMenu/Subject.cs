using System;

public struct Subject
{
    private string name;

    public Subject(string name1)
    {
        this.name = name1;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}