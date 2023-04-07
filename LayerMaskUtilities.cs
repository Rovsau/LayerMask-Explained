using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class LayerMaskUtilities
{
    public static string MaskToHexadecimalString(LayerMask layerMask)
    {
        return string.Format($"0x{layerMask.value:X}");
    }

    public static string MaskToBinaryString(LayerMask layerMask)
    {
        const char zeroChar = '0';
        int mask = layerMask.value;
        char[] bits = new char[32];

        for (int i = 0; i < bits.Length; i++) 
        {
            bits[bits.Length - 1 - i] = (char)(zeroChar + (mask >> i & 1));
        }
        
        return new string(bits);
    }

    public static IEnumerable<char> MaskToBinaryStringNonAlloc(LayerMask layerMask)
    {
        const char zeroChar = '0';
        for (int i = 0; i < 32; i++)
        {
            char bitCharacter = (char)(zeroChar + (layerMask >> i & 1));
            yield return bitCharacter;
        }
    }
    
    public static string MaskToBinaryStringConvert(LayerMask layerMask) 
    {
        // uses System, not System.Text
        return System.Convert.ToString(layerMask, 2).PadLeft(32, '0');
    }

    public static int[] GetLayerIndexesFromMask(LayerMask layerMask)
    {
        int[] layerIndexes = new int[32];
        int index = default;
        for (int i = 0; i < layerIndexes.Length; i++)
        {
            if (((1 << i) & layerMask) != 0)
            {
                layerIndexes[index++] = i;
            }
        }
        System.Array.Resize(ref layerIndexes, index);
        return layerIndexes;
    }

    public static IEnumerable<int> GetLayerIndexesFromMaskNonAlloc(LayerMask layerMask) 
    {
        for (int i = 0; i < 32; i++) 
        {
            if ((1 << i & layerMask) != 0) 
            {
                yield return i;
            }
        }
    }

#if UNITY_EDITOR
    public static string[] GetProjectLayers()
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset"));
        SerializedProperty layers = tagManager.FindProperty("layers");
        string[] result = new string[layers.arraySize];
        for (int i = 0; i < layers.arraySize; i++)
        {
            result[i] = layers.GetArrayElementAtIndex(i).stringValue;
        }
        return result;
    } 
#endif
}
