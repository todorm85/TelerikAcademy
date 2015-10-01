using System;

public class Dog
{
    private string name;
    private string breed;
    private int? age;

    public Dog ()
    {
        this.name = "[Unnamed Dog]";
        this.breed = "[Undefined Breed]";
        this.age = 0;
    }

    public Dog (string name, string breed)
    {
        this.name = name ?? "[Unnamed Dog]";
        this.breed = breed ?? "[Undefined Breed]";
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Breed
    {
        get { return this.breed; }
        set { this.breed = value; }
    }

    public int? Age
    {
        get { return this.age; }
        set { this.age = value ?? 0; }
    }

    public void Bark()
    {
        Console.WriteLine("{0} said: BauBau!", this.name);
    }
}
