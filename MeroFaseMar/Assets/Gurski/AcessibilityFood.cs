using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcessibilityFood : MonoBehaviour
{
    private Color[] colorList = {Color.yellow, Color.orangeRed, Color.cyan, 
        Color.green, Color.blue, Color.hotPink, Color.brown};
    public GameObject gameManager;
    public GameManagerColor colorManager;
    public int index;
    public int imageIndex; // inspector
    private int limit;
    public Color cor;

    public Image sprite;

    void Start()
    {
        sprite.color = colorList[index];
        limit = colorList.Length;
        colorManager = gameManager.GetComponent<GameManagerColor>();
        cor = colorManager.sendColor(imageIndex);
        sprite.color = cor;
    }

    public void changeColor()
    {
        index++;
        if(index == limit)
        {
            index = 0;
        }
        sprite.color = colorList[index];
        colorManager.getColor(imageIndex, colorList[index]);
    }
}