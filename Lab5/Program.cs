using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Linq;

public class Student
{
    public string Imie { get; set; } = "";
    public string Nazwisko { get; set; } = "";
    public List<int> Oceny { get; set; } = new List<int>();
}

class Program
{
    static void Main()
    {
        // Uruchamiaj co potrzebujesz:
        //WriteTextToFile();
        //ReadTextFile();
        //AppendTextToFile();
        //SerializeStudentsToJson();
        //DeserializeStudentsFromJson();
        //SerializeStudentsToXml();
        //DeserializeStudentsFromXml();
        //ReadCsvIris();
        //ReadCsvIrisWithAverages();
        //FilterIrisCsv();
    }

    static void WriteTextToFile()
    {
        string file = "dane.txt";
        List<string> lines = new List<string>();

        Console.WriteLine("Podaj 5 linii tekstu:");

        for (int i = 0; i < 5; i++)
        {
            string? input = Console.ReadLine();
            lines.Add(input ?? "");
        }

        File.WriteAllLines(file, lines);
        Console.WriteLine("Zapisano do pliku dane.txt");
    }

    static void ReadTextFile()
    {
        string file = "dane.txt";

        if (!File.Exists(file))
        {
            Console.WriteLine("Plik dane.txt nie istnieje!");
            return;
        }

        foreach (var line in File.ReadAllLines(file))
            Console.WriteLine(line);
    }

    static void AppendTextToFile()
    {
        string file = "dane.txt";

        Console.WriteLine("Podaj tekst do dopisania:");
        string? input = Console.ReadLine();

        File.AppendAllText(file, (input ?? "") + Environment.NewLine);
        Console.WriteLine("Dopisano.");
    }

    static void SerializeStudentsToJson()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Imie="Jan", Nazwisko="Kowalski", Oceny=new List<int>{5,4,3}},
            new Student { Imie="Anna", Nazwisko="Nowak", Oceny=new List<int>{5,5,4}}
        };

        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("studenci.json", json);

        Console.WriteLine("Zapisano JSON.");
    }

    static void DeserializeStudentsFromJson()
    {
        if (!File.Exists("studenci.json"))
        {
            Console.WriteLine("Brak pliku JSON!");
            return;
        }

        string json = File.ReadAllText("studenci.json");
        List<Student>? students = JsonSerializer.Deserialize<List<Student>>(json);

        if (students == null)
        {
            Console.WriteLine("Błąd: deserializowano null.");
            return;
        }

        foreach (var s in students)
            Console.WriteLine($"{s.Imie} {s.Nazwisko} - Oceny: {string.Join(", ", s.Oceny)}");
    }

    static void SerializeStudentsToXml()
    {
        List<Student> students = new List<Student>()
        {
            new Student { Imie="Jan", Nazwisko="Kowalski", Oceny=new List<int>{5,4,3}},
            new Student { Imie="Anna", Nazwisko="Nowak", Oceny=new List<int>{5,5,4}}
        };

        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

        using FileStream fs = new FileStream("studenci.xml", FileMode.Create);
        serializer.Serialize(fs, students);

        Console.WriteLine("Zapisano XML.");
    }

    static void DeserializeStudentsFromXml()
    {
        if (!File.Exists("studenci.xml"))
        {
            Console.WriteLine("Brak pliku XML!");
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

        using FileStream fs = new FileStream("studenci.xml", FileMode.Open);
        List<Student>? students = serializer.Deserialize(fs) as List<Student>;

        if (students == null)
        {
            Console.WriteLine("Błąd deserializacji XML.");
            return;
        }

        foreach (var s in students)
            Console.WriteLine($"{s.Imie} {s.Nazwisko} - Oceny: {string.Join(", ", s.Oceny)}");
    }

    static void ReadCsvIris()
    {
        string file = "iris.csv";

        if (!File.Exists(file))
        {
            Console.WriteLine("Brak pliku iris.csv");
            return;
        }

        foreach (var line in File.ReadAllLines(file))
            Console.WriteLine(line);
    }

    static void ReadCsvIrisWithAverages()
    {
        string file = "iris.csv";

        if (!File.Exists(file))
        {
            Console.WriteLine("Brak pliku iris.csv");
            return;
        }

        var lines = File.ReadAllLines(file).Skip(1);

        List<double[]> data = new List<double[]>();

        foreach (var line in lines)
        {
            var p = line.Split(',');

            data.Add(new double[]
            {
                double.Parse(p[0]),
                double.Parse(p[1]),
                double.Parse(p[2]),
                double.Parse(p[3])
            });
        }

        Console.WriteLine("Średnie wartości kolumn:");
        Console.WriteLine($"sepal length = {data.Average(r => r[0])}");
        Console.WriteLine($"sepal width  = {data.Average(r => r[1])}");
        Console.WriteLine($"petal length = {data.Average(r => r[2])}");
        Console.WriteLine($"petal width  = {data.Average(r => r[3])}");
    }

    static void FilterIrisCsv()
    {
        string file = "iris.csv";

        if (!File.Exists(file))
        {
            Console.WriteLine("Brak pliku iris.csv");
            return;
        }

        var result = File.ReadAllLines(file)
            .Skip(1)
            .Select(l => l.Split(','))
            .Where(p => double.Parse(p[0]) < 5)
            .Select(p => $"{p[0]},{p[1]},{p[4]}")
            .ToList();

        result.Insert(0, "sepal length,sepal width,class");

        File.WriteAllLines("iris_filtered.csv", result);

        Console.WriteLine("Zapisano iris_filtered.csv");
    }
}
