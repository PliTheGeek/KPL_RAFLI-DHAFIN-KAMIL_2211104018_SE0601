using System;
using MatematikaLibraries;

class Program
{
    static void Main()
    {
        int hasilFPB = Matematika.FPB(60, 45);
        Console.WriteLine($"FPB(60, 45) = {hasilFPB}");

        int hasilKPK = Matematika.KPK(12, 8);
        Console.WriteLine($"KPK(12, 8) = {hasilKPK}");

        string hasilTurunan = Matematika.Turunan(new int[] { 1, 4, -12, 9 });
        Console.WriteLine($"Turunan: {hasilTurunan}");

        string hasilIntegral = Matematika.Integral(new int[] { 4, 6, -12, 9 });
        Console.WriteLine($"Integral: {hasilIntegral}");
    }
}
