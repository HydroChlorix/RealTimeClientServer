using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR.Dev.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<HubConnection> connections = new List<HubConnection>();
            CancellationToken token = new CancellationToken();

            string input = string.Empty;
            while (!input.Equals("q"))
            {
                Console.WriteLine($"\t\t Menu" +
                    $"\n\t 1. Add => Add new client" +
                    $"\n\t 2. Q => Stop" +
                    $"\n\t 3. S => Send");

                input = Console.ReadLine();

                if (input.Equals("a"))
                {
                    HubConnection hub = new HubConnectionBuilder()
                                       .WithUrl("http://localhost:61497/notificationHub")
                                       .Build();

                    hub.Closed += async (error) =>
                    {
                        await Task.Delay(new Random().Next(0, 5) * 1000);
                        await hub.StartAsync();
                    };

                    hub.On<string>("Notify", (message) =>
                    {
                        Console.WriteLine($"message from server : {message}");
                    });

                    connections.Add(hub);

                    Console.WriteLine($"Client added.Total {connections.Count}");
                }
                else if (input.Equals("s"))
                {
                    foreach (var client in connections)
                    {
                        try
                        {
                            if (client.State == HubConnectionState.Disconnected)
                            {
                                await client.StartAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex}");
                        }
                    }

                    Console.WriteLine($"Total {connections.Count} client started");
                }
            }

            foreach (var client in connections)
            {
                await client.StopAsync(token);
            }
        }


    }
}
