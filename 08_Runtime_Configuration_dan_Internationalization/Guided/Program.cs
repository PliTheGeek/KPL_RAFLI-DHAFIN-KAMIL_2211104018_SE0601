using System;
using modul8_2211104018;

class Program
{
    static void Main()
    {
        // Load configuration
        var config = BankTransferConfig.LoadConfig("bank_transfer_config.json");

        // Prompt for transfer amount
        if (config.Lang == "en")
            Console.Write("Please insert the amount of money to transfer: ");
        else
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");

        if (!int.TryParse(Console.ReadLine(), out int amount))
        {
            Console.WriteLine(config.Lang == "en" ? "Invalid input." : "Input tidak valid.");
            return;
        }

        // Calculate transfer fee
        int fee = amount <= config.Transfer.Threshold
            ? config.Transfer.Low_Fee
            : config.Transfer.High_Fee;
        int total = amount + fee;

        // Output fee and total
        if (config.Lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        // Prompt for transfer method
        if (config.Lang == "en")
            Console.WriteLine("Select transfer method:");
        else
            Console.WriteLine("Pilih metode transfer:");

        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        int methodIndex = -1;
        while (methodIndex < 1 || methodIndex > config.Methods.Count)
        {
            Console.Write(config.Lang == "en" ? "Enter method number: " : "Masukkan nomor metode: ");
            if (!int.TryParse(Console.ReadLine(), out methodIndex) || methodIndex < 1 || methodIndex > config.Methods.Count)
            {
                Console.WriteLine(config.Lang == "en" ? "Invalid method." : "Metode tidak valid.");
            }
        }

        // Confirmation step
        string confirmValue = config.Lang == "en" ? config.Confirmation.En : config.Confirmation.Id;
        if (config.Lang == "en")
            Console.Write($"Please type \"{confirmValue}\" to confirm the transaction: ");
        else
            Console.Write($"Ketik \"{confirmValue}\" untuk mengkonfirmasi transaksi: ");

        string userConfirm = Console.ReadLine();

        if (userConfirm.Trim().Equals(confirmValue, StringComparison.OrdinalIgnoreCase))
        {
            if (config.Lang == "en")
                Console.WriteLine("The transfer is completed");
            else
                Console.WriteLine("Proses transfer berhasil");
        }
        else
        {
            if (config.Lang == "en")
                Console.WriteLine("Transfer is cancelled");
            else
                Console.WriteLine("Transfer dibatalkan");
        }
    }
}
