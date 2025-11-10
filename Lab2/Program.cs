using System;

class Zwierze
{
    protected string nazwa;

    public Zwierze(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public virtual void DajGlos()
    {
        Console.WriteLine("...");
    }
}

class Pies : Zwierze
{
    public Pies(string nazwa) : base(nazwa) { }

    public override void DajGlos()
    {
        Console.WriteLine($"{nazwa} robi woof woof!");
    }
}

class Kot : Zwierze
{
    public Kot(string nazwa) : base(nazwa) { }

    public override void DajGlos()
    {
        Console.WriteLine($"{nazwa} robi miau miau!");
    }
}

class Waz : Zwierze
{
    public Waz(string nazwa) : base(nazwa) { }

    public override void DajGlos()
    {
        Console.WriteLine($"{nazwa} robi ssssssss!");
    }
}

class Program
{
    public static void PowiedzCos(Zwierze zwierze)
    {
        zwierze.DajGlos();
        Console.WriteLine($"Typ obiektu: {zwierze.GetType().Name}\n");
    }

    static void Main(string[] args)
    {
        Zwierze zwierze = new Zwierze("Zwierzak");
        Pies pies = new Pies("Reksio");
        Kot kot = new Kot("Mruczek");
        Waz waz = new Waz("Kaa");

        PowiedzCos(zwierze);
        PowiedzCos(pies);
        PowiedzCos(kot);
        PowiedzCos(waz);

        Piekarz piekarz = new Piekarz();
        piekarz.Pracuj();


        Console.WriteLine();

        Console.WriteLine("Tworzenie A:");
        A a = new A();

        Console.WriteLine("\nTworzenie B:");
        B b = new B();

        Console.WriteLine("\nTworzenie C:");
        C c = new C();
    }
}

abstract class Pracownik
{
    public abstract void Pracuj();
}

class Piekarz : Pracownik
{
    public override void Pracuj()
    {
        Console.WriteLine("Trwa pieczenie...");
    }
}

class A
{
    public A()
    {
        Console.WriteLine("To jest konstruktor A");
    }
}

class B : A
{
    public B() : base()
    {
        Console.WriteLine("To jest konstruktor B");
    }
}

class C : B
{
    public C() : base()
    {
        Console.WriteLine("To jest konstruktor C");
    }
}
