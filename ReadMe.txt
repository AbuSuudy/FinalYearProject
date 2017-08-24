I've developed code for the Kinect and Arduino to gather motion data. Also created inteactive visualisation using D3.js and embedded it to an ASP.NET website using the MVC framwork.

##Using the Kinect 
I take a reading of the X,Y,Z postion of the head each second and place this into a CSV file and another C# file reads each cooridinate in the file and calculates the distance of each coordinate. This would quantify the amound the movement taking places ina given area.

##Using the Arduino
Using a PIR sensor to detect motion by using Infrared radiation. The date and time when motion is detected would be written to a csv file on an SD card.

I have also used a years worth of public fitbit data that I could create visulaisation from so I could see how the system would look when it's put in practice.


The purpose of this project is to place the system into a care home where care home
workers could decide if the general populous is having enough exercise.
