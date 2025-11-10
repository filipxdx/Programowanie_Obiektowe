using System;

public interface IModular
{
    double Module();
}

public class ComplexNumber : ICloneable, IEquatable<ComplexNumber>, IModular
{
    private double re;
    private double im;

    public double Re
    {
        get { return re; }
        set { re = value; }
    }

    public double Im
    {
        get { return im; }
        set { im = value; }
    }

    public ComplexNumber(double re, double im)
    {
        this.re = re;
        this.im = im;
    }

    public override string ToString()
    {
        string znak = im >= 0 ? "+" : "-";
        return $"{re} {znak} {Math.Abs(im)}i";
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.re + b.re, a.im + b.im);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.re - b.re, a.im - b.im);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double real = a.re * b.re - a.im * b.im;
        double imag = a.re * b.im + a.im * b.re;
        return new ComplexNumber(real, imag);
    }

    public static ComplexNumber operator -(ComplexNumber a)
    {
        return new ComplexNumber(a.re, -a.im);
    }

    public object Clone()
    {
        return new ComplexNumber(this.re, this.im);
    }

    public bool Equals(ComplexNumber other)
    {
        if (other == null) return false;
        return this.re == other.re && this.im == other.im;
    }

    public override bool Equals(object obj)
    {
        if (obj is ComplexNumber other)
            return Equals(other);
        return false;
    }

    public override int GetHashCode()
    {
        return re.GetHashCode() ^ im.GetHashCode();
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        if (ReferenceEquals(a, b)) return true;
        if ((object)a == null || (object)b == null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }

    public double Module()
    {
        return Math.Sqrt(re * re + im * im);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Test klasy ComplexNumber ===\n");

        ComplexNumber z1 = new ComplexNumber(3, 4);
        ComplexNumber z2 = new ComplexNumber(1, -2);

        Console.WriteLine($"z1 = {z1}");
        Console.WriteLine($"z2 = {z2}\n");

        ComplexNumber suma = z1 + z2;
        Console.WriteLine($"z1 + z2 = {suma}");

        ComplexNumber roznica = z1 - z2;
        Console.WriteLine($"z1 - z2 = {roznica}");

        ComplexNumber iloczyn = z1 * z2;
        Console.WriteLine($"z1 * z2 = {iloczyn}");

        ComplexNumber sprzezenie = -z1;
        Console.WriteLine($"Sprzężenie z1 = {sprzezenie}");

        Console.WriteLine($"|z1| = {z1.Module():F2}");

        ComplexNumber kopia = (ComplexNumber)z1.Clone();
        Console.WriteLine($"Kopia z1 = {kopia}");

        ComplexNumber z3 = new ComplexNumber(3, 4);
        Console.WriteLine($"z1 == z3 ? {z1 == z3}");
        Console.WriteLine($"z1 != z2 ? {z1 != z2}");
        Console.WriteLine($"z1.Equals(z3)? {z1.Equals(z3)}");
    }
}
