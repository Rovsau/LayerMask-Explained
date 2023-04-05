# Advanced

**BitMask** is a data science concept for storing data in a binary format,  
which is very efficient because it is the native language of digital computers. 

**LayerMask** is a type of BitMask, designed to represent a set of layers in Unity.  
It is fixed at 32 bits, the same number of max layers in the game engine.

**Bit Shifting** is used to convert a single layer index into a mask, or the other way around.  
by shifting the binary position **1** to the \<Left or Right\> for index or mask number of times.
```cs
int index = 4;

LayerMask mask = 1 << index;
int sameIndex = 1 >> mask;

Debug.Log(mask.value);  // Output: 16
Debug.Log(sameIndex);  // Output: 4
```
<br>

This is used for example when adding a layer to an existing mask, by layer index.
```cs
LayerMask mask = mask | (1 << index);
```

<br>

The value of the mask is only shown as an integer, and the binary sequence itself is not exposed,  
but it is possible to convert the integer value into binary and have a look. 
```cs
int layerIndex = LayerMask.NameToLayer("Water");  // layerIndex == 4
LayerMask layerMask = 1 << layerIndex;  // layerMask.value == 16
string binary = Convert.ToString(layerMask, 2).PadLeft(32, '0');
Debug.Log(binary);  
// 00000000000000000000000000010000
```
Each bit in the binary sequence represents a layer index.  
The sequence runs from Right to Left.  
Adding layer index 4 to a LayerMask, sets the bit at index 4 to 1,  
which when converted from binary to decimal is 16. (2^4)

The bit to the far Left is known as the Most Significant Bit (MSB)  
The bit to the far Right is known as the Least Significant Bit (LSB)
