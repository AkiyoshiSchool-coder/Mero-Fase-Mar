using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class AcessibilityFood : MonoBehaviour
{
    private Color[] colorList = {Color.yellow, Color.orange, Color.red, Color.green,
        Color.cyan, Color.blue, Color.hotPink, Color.brown};
    public int index;
    private int limit;

    public Image sprite;

    void Start()
    {
        sprite.color = colorList[index];
        limit = colorList.Length;
    }

    public void changeColor()
    {
        index++;
        if(index == limit)
        {
            index = 0;
        }
        sprite.color = colorList[index];
    }
}