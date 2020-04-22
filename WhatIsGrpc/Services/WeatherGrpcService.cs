using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsGrpc.Services
{
  public class WeatherGrpcService : WeatherService.WeatherServiceBase
  {
    public override Task<WeatherResponse> GetWeather(WeatherRequest request, ServerCallContext context)
    {
      var res = GenerateResult();

      return Task.FromResult(res);
    }

    private static WeatherResponse GenerateResult()
    {
      var rnd = new Random();

      var res = new WeatherResponse()
      {
        Temperature = (float)(rnd.NextDouble() * 100.0),
        WindSpeed = (float)(rnd.NextDouble() * 50.0),
        RainAmount = (float)(rnd.NextDouble() * 10.0)
      };
      return res;
    }

    public async override Task StreamWeather(WeatherRequest request, IServerStreamWriter<WeatherResponse> responseStream, ServerCallContext context)
    {
      for (var x = 0; x < 5; ++x)
      {
        await responseStream.WriteAsync(GenerateResult());
      }
    }
  }

}
