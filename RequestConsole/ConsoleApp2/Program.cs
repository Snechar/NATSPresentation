using NATS.Client;
using System;
using System.Text;
using System.Text.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory cf = new ConnectionFactory();
            Options opts = ConnectionFactory.GetDefaultOptions();

            opts.Url = "nats://localhost:4444";

            IConnection c = cf.CreateConnection(opts);
            RequestDTO request = new RequestDTO("RequestConsole","Ping");
            while (true)
            {

            string message = Console.ReadLine();
            Console.WriteLine($"Sent {message} ");

            var responseData = c.RequestAsync("worker", Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request)));
            var receivedOrder = Encoding.UTF8.GetString(responseData.Result.Data);

            Console.WriteLine($"Received {receivedOrder}");

            }
        }
    }
}
