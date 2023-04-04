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

[LayerMask Functions](LayerMaskFunctions.cs)  

[Advanced (BitMask, Bit Shifting)](Advanced.md)

[LayerMask Utilities](LayerMaskUtilities.cs)
