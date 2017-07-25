using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;
using System.IO;

namespace DistanceData
{
    class Program
    {
        static void Main(string[] args)
        {
            string datetimeString = string.Format("{0:dd-MM-yyyy}.csv", DateTime.Now);

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\ashra\Desktop\FinalYearProject\Data\" + datetimeString);
            char[] delimiterChars = { ',' };

            string[] values;
            List<String> dataToTextFile = new List<String>();
            List<String> time = new List<string>();
            List<String> Date = new List<string>();
            List<float> manipulatedValues = new List<float>();
            DateTime objTime = DateTime.Now;

            List<Point3D> list = new List<Point3D>();

            foreach (string line in lines)
            {
                values = line.Split(delimiterChars);

                float xd = float.Parse(values[0].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                float yd = float.Parse(values[1].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                float zd = float.Parse(values[2].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                time.Add(values[3]);
                Date.Add(values[4]);

                list.Add(new Point3D(xd, yd, zd));
            }

            for (int i = 0; i <= list.Count() - 2; i++)
            {
                float newValue = (float)Math.Sqrt(Math.Pow(list[i].X - list[i + 1].X, 2) + Math.Pow(list[i].Y - list[i + 1].Y, 2) + Math.Pow(list[i].Z - list[i + 1].Z, 2));
                manipulatedValues.Add(newValue);

                Console.WriteLine("Movement: " + manipulatedValues[i] + " Date:" + Date[i + 1] + " Time: " + time[i + 1]);

                String newVal = manipulatedValues[i] + ", " + time[i + 1] + ", " + Date[i + 1];

                dataToTextFile.Add(newVal);

                using (System.IO.StreamWriter file =
                              new System.IO.StreamWriter(@"C:\Users\ashra\Desktop\FinalYearProject\Data\DataManipulated_" + datetimeString, true))

                file.WriteLine(dataToTextFile[i].ToString());
            }

            Console.Read();
        }
    }
}