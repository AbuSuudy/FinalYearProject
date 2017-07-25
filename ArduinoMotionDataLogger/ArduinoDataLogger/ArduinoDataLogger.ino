#include <SPI.h>
#include <SD.h>
#include <DS3231.h>

DS3231  rtc(SDA, SCL);

int ledPin = 7;
int pirPin = 3;
int val;

File myFile;

void setup() {
  Serial.begin(9600);
  pinMode(pirPin, INPUT);
  pinMode(10, OUTPUT);
  pinMode(ledPin, OUTPUT);
  digitalWrite(ledPin, LOW);

  Serial.println("Initialising the SD card...");

   if (!SD.begin(10)) {
     Serial.println("SD card not initalised.");
     return;
   }

   Serial.println("SD card initalised");
  
   rtc.begin();

  rtc.setTime(13, 28, 00); 
  rtc.setDate(29, 04, 2017);

}

void loop() {
  val = digitalRead(pirPin);
  
  if (val == HIGH){
    digitalWrite(ledPin, HIGH);
    delay(3500);
    
     myFile = SD.open("Data.csv", FILE_WRITE);
  
    if(myFile){
      Serial.print("Motion Detected at: ");
      Serial.print(rtc.getDateStr()); 
      Serial.print(" -- ");
      Serial.println(rtc.getTimeStr());
      myFile.print(rtc.getTimeStr());
      myFile.print(", ");
      myFile.println(rtc.getDateStr());
      myFile.close();
    } 
    else {
      Serial.println("Error opening file.");
    }

  }else{
    digitalWrite(ledPin, LOW);
  }
} 
