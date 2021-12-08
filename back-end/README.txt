1. Order products
	- https://www.amazon.com/Arduino-A000066-ARDUINO-UNO-R3/dp/B008GRTSV6/ref=sr_1_5?keywords=flashtree+FPM11A+Green+Light+Optical+Fingerprint+Reader+Sensor+Module+6+Pins+for+Arduino+Mega2560+UNO+R3&qid=1638750881&s=electronics&sr=1-5
	- https://www.amazon.com/FlashTree-Optical-Fingerprint-Arduino-Mega2560/dp/B07G6L7YDX/ref=sr_1_2?keywords=flashtree+FPM11A+Green+Light+Optical+Fingerprint+Reader+Sensor+Module+6+Pins+for+Arduino+Mega2560+UNO+R3&qid=1638750988&s=electronics&sr=1-2

2. Using Arduino 1.8.16 to register fingerprint
	- Download Arduino 1.8.16 at https://www.arduino.cc/en/software
	- Connect the board to the personal computer via the USB port
	- Extract arduino-1.8.16-windows.zip and double-click to arduino.exe
	
	# Check connected to the board
	- Tools > check Board: "Arduino Uno" and Port: "COM4 Arduino Uno"
	
	# Register fingerprint
	- File > Open... > point the path to the "register_fingerprint" folder and select the file "register_fingerprint.ino" > Open
	- Click Serial Monitor in the right corner
	- Click Upload
	- Touch finger to fingerprint to register finger
	- Close Serial Monitor and file "register_fingerprint.ino"
	
	# Read fingerprint
	- File > Open... > point the path to the "read_fingerprint" folder and select the file "read_fingerprint.ino" > Open
	- Click Upload
	
3. Using SQL Server Management Studio to store data
	- New Query
	- Copy content of file "fingerprint.sql" to New Query > Execute
	
4. Using Visual Studio 2017 to read finger from fingerprint
	- File > Open > Project/Solution... > point the path to the "Fingerprint" folder > choose Fingerprint.sln > Open
	- Start