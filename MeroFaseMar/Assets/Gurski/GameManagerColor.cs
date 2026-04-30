using UnityEngine;
using System.Collections.Generic;

public class GameManagerColor : MonoBehaviour
{
    public List<UnityEngine.Color> colorIndex = new List<UnityEngine.Color>();

    void Start()
    {
        
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
