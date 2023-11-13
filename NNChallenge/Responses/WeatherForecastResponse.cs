using NNChallenge.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Responses
{
    public class WeatherForecastResponse
    {
        public HourDto Current { get; set; }
        public ForecastDto Forecast { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
