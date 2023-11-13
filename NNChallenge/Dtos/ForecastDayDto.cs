using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Dtos
{
    public class ForecastDayDto
    {
       public DateTime Date { get; set; }
       //public Day Day { get; set; }
       public HourDto[] Hour { get; set; }

    }
}
