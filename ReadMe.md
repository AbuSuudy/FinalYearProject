The purpose of this project is to place the system into a care home where care home workers could decide if the general populous is having enough exercise. This is because if there are many people living in one location it can be hard to track if people are having the right amount of exercise. I've developed code for the Kinect and Arduino to gather motion data. Also created interactive visualisation using D3.js and embedded it to an ASP.NET website using the MVC framework.

## Using the Kinect 
I take a reading of the X, Y, Z position of the head each second and place this into a CSV file and another C# file reads each coordinate in the file and calculates the distance between each coordinate. This would quantify the amount the movement taking places in given area.

## Using the Arduino
Using a PIR sensor to detect motion by using Infrared radiation. The date and time when motion is detected would be written to a CSV file on an SD card.

I have also used a years’ worth of public Fitbit data that I could create visualisation from so I could see how the system would look when it's put in practice.

## ASP.NET
This site allows staff to create an announcement and can comment underneath the announcement in the comment section. The resident in the care home could only comment underneath and announcement once it has been created. The purpose of this to start a dialogue between the staff and the residents. I used AJAX to update the comment section without needing to refresh the page to see the new comments.
