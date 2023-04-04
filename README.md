# LayerMask Explained
Use **NameToLayer**() to get a layer's index.  
It is used to set an object's layer. 
```cs
int layerIndex = LayerMask.NameToLayer("Default");
gameObject.layer = layerIndex;
```
The other methods in Unity, such as Raycast(), require a LayerMask.  
A LayerMask contains a 1 or 0 for all 32 layers.  

Use **GetMask**() to create a LayerMask which includes all the layers specified.  
Or use it to create masks with single layers, and use addition (+) to create combinations between them.  
```cs
LayerMask a = LayerMask.GetMask("Default");
LayerMask b = LayerMask.GetMask("Water");
LayerMask c = LayerMask.GetMask("Default", "Water");

LayerMask raycastLayers = a + b;  // The same as 'c'
```

<details>
<summary>Raycast script example</summary>

```cs
using UnityEngine;

public class Example : MonoBehaviour
{
    public float distance;

    private Ray ray;
    private LayerMask raycastLayers;

    private void Awake()
    {
        ray = new Ray(transform.position, transform.forward);

        LayerMask a = LayerMask.GetMask("Default");
        LayerMask b = LayerMask.GetMask("Water");
        LayerMask c = LayerMask.GetMask("Default", "Water");

        raycastLayers = a + b;  // The same as 'c'
    }

    private void Update()
    {
        if (Physics.Raycast(ray, distance, raycastLayers))
        {
            Debug.Log("Hit something on a layer included in the mask!");
        }
    }
}
```
</details>

<br>

That is all which is needed to work with LayerMasks in Unity.  
Further reading is optional.

# Advanced

**BitMask** is a data science concept for storing data in a binary format,  
which is very efficient because it is the native language of digital computers. 

**LayerMask** is a type of BitMask, designed to represent a set of layers in Unity.  
It is fixed at 32 bits, the same number of max layers in the game engine.

**Bit Shifting** is used to convert a single layer index into a mask, or the other way around.  
by shifting the binary position **1** to the \<Left or Right\> for index/mask number of times.
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
Debug.Log(binary);  // 00000000000000000000000000010000
```
Each bit in the binary sequence represents a layer index.  
The sequence runs from Right to Left.  
Adding layer index 4 to a LayerMask, sets the bit at index 4 to 1,  
which when converted from binary to decimal is 16. (2^4)
