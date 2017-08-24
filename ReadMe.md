## Folder Content

**ArduinoMotionDataLogger** -Contains Arduino Sketch

**BatchFiles**	- Restart program so data could be written to a different time stamp file. Time is selected using Task Scheduler.

**Blackboard**	- Contains ASP.NET Site

**KinectData** - Collect coordinate data from kinect

**DistanceData**	- Calculates distance between kinect coordinate

## Introduction
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

### Parallel Coordinates 
Each line represents a day of Fitbit data that is gathered. The total number days represented in this visualisation is 366 days. At first glance, it does not seem to show too much information due to the overlapping of strokes makes seeing trends and connection difficult.

![chrome_2017-08-24_13-33-08](https://user-images.githubusercontent.com/15980314/29666653-1bfe3248-88d1-11e7-9849-b623c2c10898.png)


You are able to select areas within the dimensions and the lines that pass through that specific areawould be put into focus and other would be faded as context. This would allow the user to break down the visualisation to as many small pieces the user wants and making the data more easy to be understood. 

![chrome_2017-08-24_13-38-06](https://user-images.githubusercontent.com/15980314/29666734-7bb6594a-88d1-11e7-9841-2b0415495bdb.png)

### Tree Maps
Each square represents the sum of movement ( the difference between coordinate’s readings) gathered at that hour from the Kinect. The larger and the closer to red the square is the higher the amount of movement taken place in that hour. As you can see the data that I gathered that the most movement has taken place at 11:00 am of 30/04/2017 and largest period of the movement takes place between 16:00 and 21:00 of 29/04/2017. 

![chrome_2017-08-24_13-43-27](https://user-images.githubusercontent.com/15980314/29666945-5f26a54a-88d2-11e7-9fc8-8e7186bd22bb.png)

This visualisation was created using Tableau and you are able to focus on a given area and it would return a sum of movement that given area. In addition, if you hover over one specific square it would give you the numerical value if the comparison between other squares is not detailed enough for you.

![chrome_2017-08-24_13-45-31](https://user-images.githubusercontent.com/15980314/29666985-83f13840-88d2-11e7-8013-6c3a2dfcb3a5.png)

### Coloured Table
This is a coloured table and colour is determined by the amount of movement taking place in that hour the more movement that takes place the closer to red and the inverse it would be closer to blue. This data is gathered from the kinect. This type of visualisation is best for when you are trying to compare different days to each other like how does the movement at 11 am compared to the previous day. In this case, a lot more movement at 11 am on the 30th takes places compared to the 11 am on the 29th. This size of this table would increase rapidly to prevent this I could only display one week of data for the visualisation at a time. The data from this visualisation is gathered from the Kinect.

![chrome_2017-08-24_13-50-36](https://user-images.githubusercontent.com/15980314/29667143-3da2afbc-88d3-11e7-9f4e-131a598896fc.png)

Similar to the tree map there is also has the interactive aspect where you could select multiple areas to gather the sum also get the sum of a specific block, but the second interaction is not useful because the values are placed on the shape.

![chrome_2017-08-24_13-52-05](https://user-images.githubusercontent.com/15980314/29667212-738d30b6-88d3-11e7-969b-91e741e85a68.png)

### Packed Bubble 
This is pretty much the same as treemap as it’s also another hierarchal data visualisation. It is not as space efficient as a treemap but I would say the hierarchy of the data is more apparent. This may make the visualisation easier to understand. The data shows how much movement is detected in each hour of the day from the Arduino. The larger the white circles the larger the amount of movement taking place in that hour. 

![chrome_2017-08-24_13-56-04](https://user-images.githubusercontent.com/15980314/29667358-fb2e3fba-88d3-11e7-99fe-f645e9cd8a09.png)

In addition, when you click on a node it would zoom and show the inner hierarchy. In addition, within each day, there would be hours where no movement is detected usually in the early hours in the morning and if I left it as zero, it would not appear on the graph. I set all the hours that I to have 0 movements to a size 10 circle and add this to an inner hierarchy called zero. So I’m able to view all the hour no movement takes place In one node instead of it all not appearing.

![chrome_2017-08-24_13-56-56](https://user-images.githubusercontent.com/15980314/29667383-1c2c0328-88d4-11e7-9c98-647430f2bc5e.png)
