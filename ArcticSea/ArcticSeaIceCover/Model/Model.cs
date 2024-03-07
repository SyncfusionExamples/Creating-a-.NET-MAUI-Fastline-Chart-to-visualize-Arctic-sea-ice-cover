using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcticSeaIceCover
{
    public class Model
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public string Date { get; set; }
        public double Value { get; set; }

        public Model(string month, string year, string date, double value)
        {
            Month = month;
            Year = year;
            Date = date;
            Value = value;
        }
    }
}
