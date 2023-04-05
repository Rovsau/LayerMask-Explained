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
Or use it to create masks with single layers, and use the OR **|** operator to create combinations between them.  
```cs
LayerMask a = LayerMask.GetMask("Default");
LayerMask b = LayerMask.GetMask("Water");
LayerMask c = LayerMask.GetMask("Default", "Water");

LayerMask raycastLayers = a | b;  // The same as 'c'
```

<details>
<summary>Raycast script example</summary>

```cs
using UnityEngine;

public class LayerMaskScriptExample : MonoBehaviour
{
    public float distance;
    private LayerMask raycastLayers;

    private void Awake()
    {
        LayerMask a = LayerMask.GetMask("Default");
        LayerMask b = LayerMask.GetMask("Water");
        LayerMask c = LayerMask.GetMask("Default", "Water");

        raycastLayers = a + b;  // The same as 'c'
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, distance, raycastLayers))
        {
            Debug.Log("Hit something on a layer included in the mask!");
        }
    }
}
```
</details>

<br>

That is all which is needed to work with LayerMask in Unity.  
Further reading is optional.

[LayerMask Functions](LayerMaskFunctions.cs)  

[Advanced (BitMask, Bit Shifting)](Advanced.md)

[LayerMask Utilities](LayerMaskUtilities.cs)
