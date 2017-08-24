The purpose of this project is to place the system into a care home where care home workers could decide if the general populous is having enough exercise. This is because if there are many people living in one location it can be hard to track if people are having the right amount of exercise. I've developed code for the Kinect and Arduino to gather motion data. Also created interactive visualisation using D3.js and embedded it to an ASP.NET website using the MVC framework.

## Using the Kinect 
I take a reading of the X, Y, Z position of the head each second and place this into a CSV file and another C# file reads each coordinate in the file and calculates the distance between each coordinate. This would quantify the amount the movement taking places in given area.

## Using the Arduino
Using a PIR sensor to detect motion by using Infrared radiation. The date and time when motion is detected would be written to a CSV file on an SD card.

## Using the FitBit
I have also used a years’ worth of public Fitbit data that I could create visualisation from so I could see how the system would look when it's put in practice. A FitBit would be used to gather data specific to that person instead of the given area like the Kinect and Arduino.

## ASP.NET
This site allows staff to create an announcement and can comment underneath the announcement in the comment section. The resident in the care home could only comment underneath and announcement once it has been created. The purpose of this to start a dialogue between the staff and the residents. I used AJAX to update the comment section without needing to refresh the page to see the new comments.

## Visualisations 

### Parrallel Coordinates 
Each line represents a day of Fitbit data that is gathered. The total number days represented in this visualisation is 366 days. At first glance, it does not seem to show too much information due to the overlapping of strokes makes seeing trends and connection difficult.

![chrome_2017-08-24_13-33-08](https://user-images.githubusercontent.com/15980314/29666653-1bfe3248-88d1-11e7-9849-b623c2c10898.png)


You are able to select areas within the dimensions and the lines that pass through that specific areawould be put into focus and other would be faded as context. This would allow the user to break down the visualisation to as many small pieces the user wants and making the data more easy to be understood. 

![chrome_2017-08-24_13-38-06](https://user-images.githubusercontent.com/15980314/29666734-7bb6594a-88d1-11e7-9841-2b0415495bdb.png)
