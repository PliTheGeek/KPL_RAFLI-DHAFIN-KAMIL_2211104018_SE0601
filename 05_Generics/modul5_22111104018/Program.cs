using System;
using System.Collections.Generic;

public class Penjumlahan
{
    public T JumlahTigaAngka<T>(T angka1, T angka2, T angka3)
    {
        dynamic temp1 = angka1;
        dynamic temp2 = angka2;
        dynamic temp3 = angka3;
        return temp1 + temp2 + temp3;
    }
}

public class SimpleDataBase<T>
{
    public List<T> storedData { get; private set; }
    public List<DateTime> inputDates { get; private set; }

    public SimpleDataBase()
    {
        storedData = new List<T>();
        inputDates = new List<DateTime>();
    }

    public void AddNewData(T data)
    {
        storedData.Add(data);
        inputDates.Add(DateTime.UtcNow);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Penjumlahan penjumlahan = new Penjumlahan();
        int hasil = penjumlahan.JumlahTigaAngka(22, 11, 18);
        Console.WriteLine($"Hasil penjumlahan: {hasil}");

        SimpleDataBase<int> dataBase = new SimpleDataBase<int>();
        dataBase.AddNewData(22);
        dataBase.AddNewData(11);
        dataBase.AddNewData(18);
        dataBase.PrintAllData();
    }
}
