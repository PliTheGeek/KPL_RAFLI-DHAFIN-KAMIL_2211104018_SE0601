// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        var pusatData = PusatDataSingleton.GetDataSingleton();

        pusatData.AddSebuahData("Belajar Singleton");
        pusatData.AddSebuahData("Design Pattern");
        pusatData.AddSebuahData("C# .NET 8");

        Console.WriteLine("Semua Data:");
        pusatData.PrintSemuaData();

        pusatData.HapusSebuahData(1);

        Console.WriteLine("\nSetelah menghapus data index 1:");
        pusatData.PrintSemuaData();
    }
}
