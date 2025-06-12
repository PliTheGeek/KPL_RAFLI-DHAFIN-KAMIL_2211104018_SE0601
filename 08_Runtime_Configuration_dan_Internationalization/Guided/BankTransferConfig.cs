using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;

namespace modul8_2211104018
{
    public class BankTransferConfig
    {
        public string Lang { get; set; } = "en";
        public TransferConfig Transfer { get; set; } = new TransferConfig();
        public List<string> Methods { get; set; } = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
        public ConfirmationConfig Confirmation { get; set; } = new ConfirmationConfig();

        public class TransferConfig
        {
            public int Threshold { get; set; } = 25000000;
            public int Low_Fee { get; set; } = 6500;
            public int High_Fee { get; set; } = 15000;
        }

        public class ConfirmationConfig
        {
            public string En { get; set; } = "yes";
            public string Id { get; set; } = "ya";
        }

        public static BankTransferConfig LoadConfig(string filePath)
        {
            if (!File.Exists(filePath))
                return new BankTransferConfig();

            var json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var config = JsonSerializer.Deserialize<BankTransferConfig>(json, options);

            // If any section is null, use defaults
            if (config == null) config = new BankTransferConfig();
            if (config.Transfer == null) config.Transfer = new TransferConfig();
            if (config.Methods == null) config.Methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            if (config.Confirmation == null) config.Confirmation = new ConfirmationConfig();

            return config;
        }
    }
}
