using UnityEngine;

public static class LayerMaskFunctions
{
    public static LayerMask Everything => -1;
    public static LayerMask Nothing => 0;

    public static LayerMask AddLayerToMask(LayerMask layerMask, int layerIndex)
    {
        return layerMask | (1 << layerIndex);
    }

    public static LayerMask RemoveLayerFromMask(LayerMask layerMask, int layerIndex)
    {
        return layerMask & ~(1 << layerIndex);
    }

    public static bool HasLayerInMask(LayerMask layerMask, int layerIndex)
    {
        return (layerMask & (1 << layerIndex)) != 0;
    }

    public static LayerMask InvertLayerMask(LayerMask layerMask)
    {
        return ~layerMask;
    }

    public static LayerMask CombineLayerMasks(LayerMask layerMask1, LayerMask layerMask2)
    {
        return layerMask1 | layerMask2;
    }

    // Layers which were found in both masks.
    public static LayerMask IntersectionLayerMasks(LayerMask layerMask1, LayerMask layerMask2)
    {
        return layerMask1 & layerMask2;
    }

    // Layers which were present, but not found in both.
    public static LayerMask SymmetricDifference(LayerMask layerMask1, LayerMask layerMask2)
    {
        return layerMask1 ^ layerMask2;
    }
}
