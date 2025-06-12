using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class KuliahMahasiswa2211104018
{
    public List<Course> courses { get; set; }

    public class Course
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public void ReadJSON()
    {
        string jsonFilePath = "tp7_2_2211104018.json";
        string jsonString = File.ReadAllText(jsonFilePath);
        KuliahMahasiswa2211104018 data = JsonSerializer.Deserialize<KuliahMahasiswa2211104018>(jsonString);

        Console.WriteLine("Daftar mata kuliah yang diambil:");
        for (int i = 0; i < data.courses.Count; i++)
        {
            Console.WriteLine($"MK {i + 1} <{data.courses[i].code}> - <{data.courses[i].name}>");
        }
    }
}
