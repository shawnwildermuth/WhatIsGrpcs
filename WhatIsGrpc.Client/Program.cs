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

        var token = new CancellationToken();
        var response = client.StreamWeather(request, cancellationToken: token);

        while (await response.ResponseStream.MoveNext(token))
        {
          Console.WriteLine($"{response.ResponseStream.Current}");
        }
        Console.ReadKey();
      }
    }
  }
}
