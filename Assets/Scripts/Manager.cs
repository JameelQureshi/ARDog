using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Material strapMaterial;
    public Material metalMaterial;

    public ColorCombination[] colorCombinations;

    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void NextCombination()
    {
        index++;
        if (index >= colorCombinations.Length)
        {
            index = 0;
        }

        strapMaterial.SetTexture("_MainTex", colorCombinations[index].strapTexture);
        metalMaterial.color = HexToColor(colorCombinations[index].metalColor);
    }
    
    public void OpenURL(string uri)
    {
        Application.OpenURL(uri);
    }

    public static Color HexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }

}

[System.Serializable]
public struct ColorCombination{
    public string metalColor;
    public Texture strapTexture;
}
