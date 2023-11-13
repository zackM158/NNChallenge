using System;
using System.Collections.Generic;
using System.Text;

namespace NNChallenge.Dtos
{
    public class HourDto
    {
        public DateTime Time { get; set; }
        public float Temp_c { get; set; }
        public float Temp_f { get; set; }
        public float Feelslike_c { get; set; }
        public float Feelslike_f { get; set; }
        public ConditionDto Condition {get;set;}
        public float Wind_mph { get; set; }
        public float Wind_kph { get; set; }
        public int Humidity { get; set; }

    }
}
