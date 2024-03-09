using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArcticSeaIceCover
{
    public class ViewModel
    {
        public ObservableCollection<Model> Year2000 { get; set; }
        public ObservableCollection<Model> Year2005 { get; set; }
        public ObservableCollection<Model> Year2010 { get; set; }
        public ObservableCollection<Model> Year2015 { get; set; }
        public ObservableCollection<Model> Year2020 { get; set; }
        public ObservableCollection<Model> Year2021 { get; set; }
        public ObservableCollection<Model> Year2022 { get; set; }
        public ObservableCollection<Model> Year2023 { get; set; }
        public ObservableCollection<Brush> PaletteBrushes { get; set; }

        public ViewModel()
        {
            Year2000 = new ObservableCollection<Model>(ReadCSV(2));
            Year2005 = new ObservableCollection<Model>(ReadCSV(3));
            Year2010 = new ObservableCollection<Model>(ReadCSV(4));
            Year2015 = new ObservableCollection<Model>(ReadCSV(5));
            Year2020 = new ObservableCollection<Model>(ReadCSV(6));
            Year2021 = new ObservableCollection<Model>(ReadCSV(7));
            Year2022 = new ObservableCollection<Model>(ReadCSV(8));
            Year2023 = new ObservableCollection<Model>(ReadCSV(9));

            PaletteBrushes = new ObservableCollection<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#2196F3")),
                new SolidColorBrush(Color.FromArgb("#25E739")),
                new SolidColorBrush(Color.FromArgb("#F4890B")),
                new SolidColorBrush(Color.FromArgb("#E2227E")),
                new SolidColorBrush(Color.FromArgb("#116DF9")),
                new SolidColorBrush(Color.FromArgb("#9215F3")),
                new SolidColorBrush(Color.FromArgb("#FCD404")),
                new SolidColorBrush(Color.FromArgb("#FF4E4E"))
            };
        }

        public IEnumerable<Model> ReadCSV(int value)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream? inputStream = executingAssembly.GetManifestResourceStream("ArcticSeaIceCover.Resources.Raw.Sea_Ice_Data.csv");
            string line;
            List<string> lines = new List<string>();
            if (inputStream != null)
            {
                using StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()!) != null)
                {
                    lines.Add(line);
                }
            }

            lines.RemoveAt(0);
            return lines.Select(line => {
                string[] data = line.Split(',');
                var month = data[0];
                var date = data[1];
                var seaIceData = Convert.ToDouble(data[value]);
                return new Model(month, getYear(value), date, seaIceData);
            });
        }

        public string getYear(int value)
        {
            Dictionary<int, string> yearMap = new Dictionary<int, string>
            {
                {2, "2000"},
                {3, "2005"},
                {4, "2010"},
                {5, "2015"},
                {6, "2020"},
                {7, "2021"},
                {8, "2022"},
                {9, "2023"}
            };

            return yearMap.ContainsKey(value) ? yearMap[value] : "";
        }
    }
}
