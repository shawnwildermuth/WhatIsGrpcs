using Grpc.Net.Client;
using System;

namespace WhatIsGrpc.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var channel = GrpcChannel.ForAddress("https://localhost:44361");
      var client = new WeatherService.WeatherServiceClient(channel);

      while (true)
      {
        var request = new WeatherRequest() { StationId = 0 };

        var response = client.GetWeather(request);

        Console.WriteLine($"{response}");
        Console.ReadKey();
      }

    }
  }
}
