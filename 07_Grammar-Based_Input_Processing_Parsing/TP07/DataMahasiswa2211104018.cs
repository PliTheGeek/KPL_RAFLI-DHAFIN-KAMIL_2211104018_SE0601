using System;
using System.IO;
using System.Text.Json;

public class DataMahasiswa2211104018
{
	public Nama nama { get; set; }
	public long nim { get; set; }
	public string fakultas { get; set; }

	public class Nama
	{
		public string depan { get; set; }
		public string belakang { get; set; }
	}

	public void ReadJSON()
	{
		string jsonFilePath = "tp7_1_2211104018.json";
		string jsonString = File.ReadAllText(jsonFilePath);
		DataMahasiswa2211104018 data = JsonSerializer.Deserialize<DataMahasiswa2211104018>(jsonString);

		Console.WriteLine($"Nama {data.nama.depan} {data.nama.belakang} dengan nim {data.nim} dari fakultas {data.fakultas}");
	}
}
