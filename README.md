# GregsToolbox
Tools for 3D Printer communication
This app is a collection of tools for 3D printing.  It was developed with an Ender 3 Pro with Marlin firmware.  It requires a USB connection to a printer.
Multiple printers can be controlled from a single instance of the app.  There is support for up to 4 extruders.  For the most part, the app sends commands to the printer and parses the responses.  Printing via the SD card is controlled by the app.  All on-the-fly print tuning is done from the app as is manual bed leveling.  Adjustments to the printer settings (PID, E-step calibration, Home Offsets, etc.) are done from the app.  There are several post-processors that work on existing gcode files by opening a file, making the requested changes, and writing to a new file.   
