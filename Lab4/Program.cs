using System;
using System.Collections.Generic;
using System.Linq;

public interface IModular
{
    public double Module();
}

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular, IComparable<ComplexNumber>
{
    private double re;
    private double im;
    public double Re { get => re; set => re = value; }
    public double Im { get => im; set => im = value; }

    public ComplexNumber(double re, double im)
    {
        this.re = re; this.im = im;
    }

    public override string ToString()
    {
        string sign = im >= 0 ? "+" : "-";
        return $"{re} {sign} {Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re + b.re, a.im + b.im);

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re - b.re, a.im - b.im);

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        => new ComplexNumber(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);

    public static ComplexNumber operator -(ComplexNumber a)
        => new ComplexNumber(a.re, -a.im);

    public object Clone() => new ComplexNumber(re, im);

    public bool Equals(ComplexNumber other)
    {
        if (other == null) return false;
        return re == other.re && im == other.im;
    }

    public override bool Equals(object obj)
        => obj is ComplexNumber other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(re, im);

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
        => a?.Equals(b) ?? b is null;

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
        => !(a == b);

    public double Module()
        => Math.Sqrt(re * re + im * im);

    public int CompareTo(ComplexNumber other)
        => this.Module().CompareTo(other.Module());
}

public class Program
{
    public static void Main()
    {

        ComplexNumber[] arr =
        {
            new ComplexNumber(3, 4),
            new ComplexNumber(1, -7),
            new ComplexNumber(0, 2),
            new ComplexNumber(-5, 12),
            new ComplexNumber(9, -1)
        };

        Console.WriteLine("=== 2a. Tablica - foreach ===");
        foreach (var z in arr) Console.WriteLine(z);

        Array.Sort(arr);

        Console.WriteLine("\n=== 2b. Posortowane po module ===");
        foreach (var z in arr) Console.WriteLine(z);

        Console.WriteLine($"\n=== 2c. Min === {arr.Min()}");
        Console.WriteLine($"=== 2c. Max === {arr.Max()}");

        Console.WriteLine("\n=== 2d. Filtr: Im >= 0 ===");
        foreach (var z in arr.Where(z => z.Im >= 0))
            Console.WriteLine(z);

        List<ComplexNumber> list = new()
        {
            new ComplexNumber(2,3),
            new ComplexNumber(9,-4),
            new ComplexNumber(-1,5),
            new ComplexNumber(3,3),
            new ComplexNumber(0,-2)
        };

        Console.WriteLine("\n=== 3. Lista - sortowanie ===");
        list.Sort();
        list.ForEach(z => Console.WriteLine(z));

        Console.WriteLine("\n3a. Usuwam drugi element:");
        list.RemoveAt(1);
        list.ForEach(z => Console.WriteLine(z));

        Console.WriteLine("\n3b. Usuwam najmniejszy:");
        list.Remove(list.Min());
        list.ForEach(z => Console.WriteLine(z));

        Console.WriteLine("\n3c. Usuwam wszystkie:");
        list.Clear();
        list.ForEach(z => Console.WriteLine(z));


        HashSet<ComplexNumber> set = new()
        {
            new ComplexNumber(6,7),
            new ComplexNumber(1,2),
            new ComplexNumber(6,7),
            new ComplexNumber(1,-2),
            new ComplexNumber(-5,9)
        };

        Console.WriteLine("\n=== 4a. HashSet zawartość ===");
        foreach (var z in set) Console.WriteLine(z);

        Console.WriteLine("\n=== 4b. HashSet - min/max ===");
        Console.WriteLine($"Min: {set.Min()}");
        Console.WriteLine($"Max: {set.Max()}");

        Console.WriteLine("\nSortowanie HashSet:");
        foreach (var z in set.OrderBy(z => z))
            Console.WriteLine(z);

        Console.WriteLine("\nFiltrowanie HashSet (Im >= 0):");
        foreach (var z in set.Where(z => z.Im >= 0))
            Console.WriteLine(z);

        // ============================
        // 5. SŁOWNIK
        // ============================

        Dictionary<string, ComplexNumber> dict = new()
        {
            { "z1", new ComplexNumber(6,7) },
            { "z2", new ComplexNumber(1,2) },
            { "z3", new ComplexNumber(6,7) },
            { "z4", new ComplexNumber(1,-2) },
            { "z5", new ComplexNumber(-5,9) }
        };

        Console.WriteLine("\n=== 5a. Słownik (klucz, wartość) ===");
        foreach (var kv in dict) Console.WriteLine($"{kv.Key}: {kv.Value}");

        Console.WriteLine("\n=== 5b. Klucze ===");
        foreach (var k in dict.Keys) Console.WriteLine(k);

        Console.WriteLine("\n=== 5b. Wartości ===");
        foreach (var v in dict.Values) Console.WriteLine(v);

        Console.WriteLine("\n=== 5c. Czy istnieje z6? ===");
        Console.WriteLine(dict.ContainsKey("z6") ? "Tak" : "Nie");

        Console.WriteLine("\n=== 5d. Min i Max wartości ===");
        Console.WriteLine($"Min: {dict.Values.Min()}");
        Console.WriteLine($"Max: {dict.Values.Max()}");

        Console.WriteLine("\n=== 5d. Filtrowanie Im >= 0 ===");
        foreach (var z in dict.Values.Where(z => z.Im >= 0))
            Console.WriteLine(z);

        Console.WriteLine("\n=== 5e. Usuwam z3 ===");
        dict.Remove("z3");
        foreach (var kv in dict) Console.WriteLine($"{kv.Key}: {kv.Value}");

        Console.WriteLine("\n=== 5f. Usuwam drugi element ===");
        string secondKey = dict.Keys.Skip(1).First();
        dict.Remove(secondKey);
        foreach (var kv in dict) Console.WriteLine($"{kv.Key}: {kv.Value}");

        Console.WriteLine("\n=== 5g. Czyszczenie słownika ===");
        dict.Clear();
        Console.WriteLine("Liczba elementów: " + dict.Count);
    }
}
