using UnityEditor;
using UnityEngine;

public static class LayerMaskUtilities
{
    public static string MaskToHexadecimalString(LayerMask layerMask)
    {
        return string.Format($"0x{layerMask.value:X}");
    }

    public static string MaskToBinaryString(LayerMask layerMask)
    {
        //return Convert.ToString(layerMask, 2).PadLeft(32, '0');
        // StringBuilder would allow for "easier" conversion post return, but also add the need for System.Text.
        int mask = layerMask.value;
        char[] bits = new char[32];
        for (int i = 0; i < bits.Length; i++)
        {
            bits[bits.Length - 1 - i] = ((mask >> i) & 1) == 1 ? '1' : '0';
        }
        return new string(bits);
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
