using NNChallenge.Models;
using System;
using System.Threading.Tasks;

namespace NNChallenge.Interfaces
{
    public interface IWeatherForcastService
    {
        Task<ForecastsWithCurrent> GetForecastForCityAsync(string city);
    }
}
