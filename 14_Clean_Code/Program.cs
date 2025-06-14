using System;
using modul8_2211104018;

class Program
{
    static void Main()
    {
        var config = BankTransferConfig.LoadConfig("bank_transfer_config.json");

        int amount = PromptForAmount(config);
        int fee = CalculateFee(config, amount);
        int total = amount + fee;

        DisplayFeeAndTotal(config, fee, total);

        int methodIndex = PromptForMethod(config);

        if (ConfirmTransaction(config))
        {
            PrintMessage(config, "The transfer is completed", "Proses transfer berhasil");
        }
        else
        {
            PrintMessage(config, "Transfer is cancelled", "Transfer dibatalkan");
        }
    }

    static int PromptForAmount(BankTransferConfig config)
    {
        PrintMessage(config, "Please insert the amount of money to transfer: ", "Masukkan jumlah uang yang akan di-transfer: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int amount))
                return amount;
            PrintMessage(config, "Invalid input.", "Input tidak valid.");
        }
    }

    static int CalculateFee(BankTransferConfig config, int amount)
    {
        return amount <= config.Transfer.Threshold
            ? config.Transfer.Low_Fee
            : config.Transfer.High_Fee;
    }

    static void DisplayFeeAndTotal(BankTransferConfig config, int fee, int total)
    {
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
    }

    static int PromptForMethod(BankTransferConfig config)
    {
        PrintMessage(config, "Select transfer method:", "Pilih metode transfer:");
        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        while (true)
        {
            PrintMessage(config, "Enter method number: ", "Masukkan nomor metode: ");
            if (int.TryParse(Console.ReadLine(), out int methodIndex) &&
                methodIndex >= 1 && methodIndex <= config.Methods.Count)
            {
                return methodIndex;
            }
            PrintMessage(config, "Invalid method.", "Metode tidak valid.");
        }
    }

    static bool ConfirmTransaction(BankTransferConfig config)
    {
        string confirmValue = config.Lang == "en" ? config.Confirmation.En : config.Confirmation.Id;
        if (config.Lang == "en")
            Console.Write($"Please type \"{confirmValue}\" to confirm the transaction: ");
        else
            Console.Write($"Ketik \"{confirmValue}\" untuk mengkonfirmasi transaksi: ");

        string userConfirm = Console.ReadLine();
        return userConfirm.Trim().Equals(confirmValue, StringComparison.OrdinalIgnoreCase);
    }

    static void PrintMessage(BankTransferConfig config, string enMsg, string idMsg)
    {
        Console.Write(config.Lang == "en" ? enMsg : idMsg);
    }
}
