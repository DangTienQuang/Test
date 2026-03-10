using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter Reader ID (or press Enter to exit): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Goodbye! Library client is shutting down.");
                    break;
                }

                if (!int.TryParse(input, out int readerId) || readerId <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a valid Reader ID (positive integer).");
                    Console.WriteLine();
                    continue;
                }

                try
                {
                    using TcpClient client = new TcpClient("127.0.0.1", 3000);
                    using NetworkStream stream = client.GetStream();
                    using StreamReader reader = new StreamReader(stream);
                    using StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

                    writer.WriteLine(readerId.ToString());

                    string response = reader.ReadLine();

                    if (response == "\"Reader not found\"" || response == "Reader not found")
                    {
                        Console.WriteLine($"Reader with ID {readerId} does not exist.");
                        Console.WriteLine();
                        continue;
                    }

                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    List<BorrowRecord> records = null;

                    try
                    {
                        records = JsonSerializer.Deserialize<List<BorrowRecord>>(response, options);
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine($"Unexpected response from server: {response}");
                        Console.WriteLine();
                        continue;
                    }

                    if (records == null || records.Count == 0)
                    {
                        Console.WriteLine($"No borrow records found for Reader ID {readerId}.");
                    }
                    else
                    {
                        Console.WriteLine($"=== Borrow History for Reader ID: {readerId}");
                        for (int i = 0; i < records.Count; i++)
                        {
                            var record = records[i];
                            Console.WriteLine($"Book ID: {record.BookId}");
                            Console.WriteLine($"Title: {record.Title}");
                            Console.WriteLine($"Author: {record.Author}");
                            Console.WriteLine($"Borrow Date: {record.BorrowDate:yyyy-MM-dd}");

                            string returnDateStr = record.ReturnDate.HasValue
                                ? record.ReturnDate.Value.ToString("yyyy-MM-dd")
                                : "Not returned yet";
                            Console.WriteLine($"Return Date: {returnDateStr}");
                            Console.WriteLine($"Status: {record.Status}");

                            if (i < records.Count - 1)
                            {
                                Console.WriteLine("---");
                            }
                        }
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("Library server is not running. Please try again later.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }

    public class BorrowRecord
    {
        [JsonPropertyName("BookID")]
        public string BookId { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("BorrowDate")]
        public DateTime BorrowDate { get; set; }

        [JsonPropertyName("ReturnDate")]
        public DateTime? ReturnDate { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
}
