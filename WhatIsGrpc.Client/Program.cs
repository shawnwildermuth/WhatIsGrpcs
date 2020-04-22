using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatIsGrpc.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      GetResponse().Wait();

    }

    private static async Task GetResponse()
    {
      var channel = GrpcChannel.ForAddress("https://localhost:5001");
      var client = new WeatherService.WeatherServiceClient(channel);

      while (true)
      {
        var request = new WeatherRequest() { StationId = 0 };

        var response = await client.GetWeatherSamplesAsync(request);

        Console.WriteLine($"Samples Gathered: {response.Time.ToDateTime().ToLongTimeString()}");
        foreach (var res in response.Samples)
        {
          Console.WriteLine($"{res}");
        }
        Console.WriteLine(new String('-', 80));
        Console.ReadKey();
      }
    }
  }
}
