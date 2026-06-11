using UnityEngine;
using System.Collections.Generic;

public class GameManagerColor : MonoBehaviour
{
    public static List<Color> colorIndex = new List<Color>();

    void Awake()
    {
        colorIndex.Add(Color.paleVioletRed);
        colorIndex.Add(Color.paleGreen);
    }

    public static void setColor(int index, Color spritecolor)
    {
        colorIndex[index] = spritecolor;
    }

    public static Color getColor(int num)
    {
        return colorIndex[num];
    }
}
