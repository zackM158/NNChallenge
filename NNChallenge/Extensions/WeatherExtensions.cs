using NNChallenge.Dtos;
using NNChallenge.Interfaces;
using NNChallenge.Models;
using NNChallenge.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NNChallenge.Extensions
{
    public static class WeatherExtensions
    {
        public static IEnumerable<IHourWeatherForecastVO> ConvertToHourWeatherForecastVOs(this WeatherForecastResponse response)
        {
            if (!response.IsSuccessful || response.Forecast == null || response.Forecast.ForecastDay == null || response.Forecast.ForecastDay.Length < 1)
                return null;

            var forecasts = response.Forecast.ForecastDay.SelectMany(f => f.Hour).Select(h => h.ConvertToHourWeatherForecastVO());
            return forecasts.OrderBy(f => f.Date);
        }

        public static IHourWeatherForecastVO ConvertToHourWeatherForecastVO(this HourDto hourDto)
        {
            if(hourDto == null) return null;

            HourWeatherForecastVO forecast = new HourWeatherForecastVO(hourDto.Time, hourDto.Temp_c, hourDto.Temp_f, hourDto.Condition.Icon)
            {
                Condition = hourDto.Condition.Text
            };
            return forecast;
        }
    }
}
