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
      var rnd = new Random();

      var res = new WeatherResponse()
      {
        Temperature = (float)(rnd.NextDouble() * 100.0),
        WindSpeed = (float)(rnd.NextDouble() * 50.0),
        RainAmount = (float)(rnd.NextDouble() * 10.0)
      };

      return Task.FromResult(res);
    }
  }

}
