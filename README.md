# dotnetopro coding dojo - How large is the resistance

Develop a program that can decode the electronic color code of a resistor.

The input is the color code of a resistor and the output is the associated value of resistance in Ohm (both in german). Furthermore the tolerance in percent.

https://de.wikipedia.org/wiki/Widerstand_(Bauelement)#Farbkodierung_auf_Widerst%C3%A4nden

Limit yourself to the color coding with 4 rings. The first two rings describe the unit position and the decade. The third ring is a multiplicator. It is used to multiply the value determined from the first two rings. The fourth ring gives information about the tolerance of the resistor.

To create is a console application. The expected parameters are the colors of the four rings in german. The output is the associated value of resistance plus the tolerance. Are the parameters not correct an error message takes place. The colors silver and gold are for example only allowed for the third and fourth ring.