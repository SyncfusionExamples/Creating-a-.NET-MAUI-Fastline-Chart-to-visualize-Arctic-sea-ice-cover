using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArcticSeaIce
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
            Stream inputStream = executingAssembly.GetManifestResourceStream("ArcticSeaIce.Resources.Raw.Sea_Ice_Data.csv");
            string line;
            List<string> lines = new List<string>();
            if (inputStream != null)
            {
                using StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            lines.RemoveAt(0);
            return lines.Select(line => {
                string[] data = line.Split(',');
                string year = null;
                if (value == 2)
                {
                    year = "2000";
                }
                else if (value == 3)
                {
                    year = "2005";
                }
                else if (value == 4)
                {
                    year = "2010";
                }
                else if (value == 5)
                {
                    year = "2015";
                }
                else if (value == 6)
                {
                    year = "2020";
                }
                else if (value == 7)
                {
                    year = "2021";
                }
                else if (value == 8)
                {
                    year = "2022";
                }
                else if (value == 9)
                {
                    year = "2023";
                }

                var month = data[0];
                var date = data[1];
                var seaIceData = Convert.ToDouble(data[value]);
                return new Model(month, year, date, seaIceData);
            });
        }
    }
}
