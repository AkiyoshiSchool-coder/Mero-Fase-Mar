using UnityEngine;
using System.Collections.Generic;

public class GameManagerColor : MonoBehaviour
{
    public List<UnityEngine.Color> colorIndex = new List<UnityEngine.Color>();

    void Awake()
    {
        colorIndex[0] = Color.orangeRed;
        colorIndex[1] = Color.green;
    }

    public void getColor(int index, Color spritecolor)
    {
        colorIndex[index] = spritecolor;
    }

    public Color sendColor(int num)
    {
        return colorIndex[num];
    }
}
