using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Kinect;
using System.Collections;

namespace KinectData
{
    public class Program
    {
        private float x, y, z;
        private KinectSensor kinect = null;
        private BodyFrameReader reader = null;
        private Body[] objBod = null;

        public void KinectSettings()
        {
            kinect = KinectSensor.GetDefault();

            if (kinect != null)
            {
                kinect.Open();
            }

            reader = kinect.BodyFrameSource.OpenReader();

            if (reader != null)
            {
                reader.FrameArrived += Reader_FrameArrived;
            }
        }
        private void Reader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            bool data = false;

            using (BodyFrame frame = e.FrameReference.AcquireFrame())
                if (frame != null)
                {
                    if (objBod == null)
                    {
                        objBod = new Body[frame.BodyCount];
                    }
                    frame.GetAndRefreshBodyData(this.objBod);
                    data = true;
                }
            if (data)
            {
                foreach (Body body in objBod)
                {
                    if (body.IsTracked)
                    {
                        IReadOnlyDictionary<JointType, Joint> jointData = body.Joints;
                        Dictionary<JointType, PointF> jointPoint = new Dictionary<JointType, PointF>();

                        Joint headPostion = jointData[JointType.Head];

                        x = headPostion.Position.X;
                        y = headPostion.Position.Y;
                        z = headPostion.Position.Z;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            Program cs = new Program();

            DateTime time = DateTime.Now;

            List<String> dataToTextFile = new List<string>();
            cs.KinectSettings();

            string datetimeString = string.Format("{0:dd-MM-yyyy}.csv", DateTime.Now);

            int counter = 0;
            while (true)
            {
                DateTime time2 = DateTime.Now;
                Console.Write("X: " + cs.x);
                Console.Write(" Y: " + cs.y);
                Console.Write(" Z: " + cs.z);
                Console.Write(" Date: " + time2.ToString("d"));
                Console.WriteLine(" Time: " + time2.ToString("HH:mm:ss"));


                String data = cs.x.ToString() + ", " + cs.y.ToString() + "," + cs.z.ToString() + ", " + time2.ToString("d") + ", " + time2.ToString("HH:mm:ss");

                dataToTextFile.Add(data);
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"C:\Users\ashra\Desktop\FinalYearProject\Data\Data_" + datetimeString, true))
                    file.WriteLine(dataToTextFile[counter].ToString());

                counter++;

                Thread.Sleep(1000);
            }
        }
    }
}