using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace TestConsoleApp
{
    internal class ParseJson
    {
        public Dictionary<string, string> Attributes { get; set; } = new();

        public void ConvertJsonToDictionary()
        {
            var json = @"{
                  ""attributes"": {
                    ""Engagement Type"": ""Review"",
                    ""ISP Data Classification"": ""Confidential"",
                    ""Engagement Leader Email"": ""1000145558"",
                    ""Engagement Manager Email"": ""1015576639"",
                    ""US_Market"": ""New York Metro"",
                    ""US_ProduceCodes"": ""US315 FS General Partnerships"",
                    ""Specialty/Business Unit"": ""Consumer Markets"",
                    ""Tax Year Type"": ""Fiscal Year"",
                    ""Year"": ""2026""
                  }
                }";



            using var doc = JsonDocument.Parse(json);

            var list = doc.RootElement
                .GetProperty("attributes")
                .EnumerateObject()
                .ToDictionary(p => p.Name, p => p.Value.ToString());


            Console.Write(list["Engagement Leader Email"]);
            Console.WriteLine("Completed");
        }
    }
}
